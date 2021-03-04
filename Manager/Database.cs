using System.Data.SqlClient;
using System.Data;
using System;
using System.Xml.Serialization;
using System.Text;

namespace Manager
{
    public class SqlConnData
    {
        public string Server;
        public bool AuthSQL;
        public string User;
        public string Pwd;
        public string Database;
        [XmlIgnore]
        public string PwdDecrypted
        {
            get { return GM.DESDecrypt(Pwd); }
            set { Pwd = GM.DESEncrypt(value); }
        }

        public bool IsValid()
        {
            return (!String.IsNullOrEmpty(Server) && !String.IsNullOrEmpty(Database) && (!AuthSQL || !String.IsNullOrEmpty(User)));
        }
        public SqlConnData()
        {
            Reset();
        }
        public SqlConnData(string server, string database, string user, string pwd, bool authSQL)
        {
            this.Server = server;
            this.Database = database;
            this.User = user;
            this.Pwd = pwd;
            this.AuthSQL = authSQL;
        }
        public void CopyFrom(SqlConnData src)
        {
            Server = src.Server;
            AuthSQL = src.AuthSQL;
            User = src.User;
            Pwd = src.Pwd;
            Database = src.Database;
        }
        public void Reset()
        {
            Server = "."; // "(local)";
            AuthSQL = false;
            User = "";
            Pwd = "";
            Database = "";
        }
        public string GetConnectionString(bool inclDB = true)
        {
            String connStr = "Data Source=" + Server + ";";
            if (AuthSQL)
                connStr += "User ID=" + User + ";Password=" + PwdDecrypted + ";";
            else
                connStr += "Integrated Security=SSPI;";

            if (inclDB)
                connStr += "Initial Catalog=" + Database + ";";
            return connStr;
        }
    }

    public class DB
    {
        public static int INVALID_ID = -1;
        public static int ALL_ID = -2;

        public static SqlConnData ConnData = new SqlConnData();

        public static SqlConnection OpenConnection(bool inclDB = true)
        {
            SqlConnection conn = new SqlConnection(ConnData.GetConnectionString(inclDB)); ;
            conn.Open();

            return conn;
        }
        // helper method - requires closing connection after usage. For safety reasons keep it private!!!
        private static SqlCommand CreateCommand(string cmdText = "", SqlTransaction trn = null)
        {
            SqlCommand cmd = new SqlCommand(cmdText, null);
            if (trn == null)
                cmd.Connection = DB.OpenConnection();
            else
            {
                cmd.Connection = trn.Connection;
                cmd.Transaction = trn;
            }
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();

            return cmd;
        }

        public static DataTable GetDataTable(string selectCmd)
        {
            return GetDataTable("", selectCmd);
        }
        public static DataTable GetDataTable(string tblName, string selectCmd)
        {
            DataTable tbl = new DataTable(tblName);
            using (SqlConnection conn = OpenConnection())
                (new SqlDataAdapter(selectCmd, conn)).Fill(tbl);
            return tbl;
        }
        public static void ExecuteNoQuery(string cmdText, params object[] paramList)
        {
            ExecuteNoQuery(null, cmdText, paramList);
        }
        public static void ExecuteNoQuery(SqlTransaction trn, string cmdText, params object[] paramList)
        {
            using (SqlCommand cmd = CreateCommand(cmdText, trn))
                try
                {
                    if (paramList != null)
                        for (int i = 0; i + 1 < paramList.Length; i += 2)
                            cmd.Parameters.AddWithValue((string)paramList[i], paramList[i + 1]);

                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                finally { if (trn == null) { cmd.Connection.Dispose(); cmd.Connection = null; } }
        }
        public static object ExecuteScalar(string cmdText, params object[] paramList)
        {
            return ExecuteScalar(null, cmdText, paramList);
        }
        public static object ExecuteScalar(SqlTransaction trn, string cmdText, params object[] paramList)
        {
            using (SqlCommand cmd = CreateCommand(cmdText, trn))
                try
                {
                    for (int i = 0; i + 1 < paramList.Length; i += 2)
                        cmd.Parameters.AddWithValue((string)paramList[i], paramList[i + 1]);

                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();
                    return cmd.ExecuteScalar();
                }
                finally { if (trn == null) { cmd.Connection.Dispose(); cmd.Connection = null; } }
        }
        public static Object UpdateOrInsert(string tableName, string columnID, int ID, params object[] paramList)
        {
            return UpdateOrInsert(null, tableName, columnID, ID, paramList);
        }

        public static Object UpdateOrInsert(SqlTransaction trn, string tableName, string columnID, int ID, params object[] paramList)
        {
            StringBuilder sb = new StringBuilder();
            String paramName;

            SqlParameter retParam;
            using (SqlCommand cmd = CreateCommand("", trn))
                try
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    retParam = cmd.Parameters["@ID"];

                    if (ID == INVALID_ID) // add new record
                    {
                        StringBuilder sbValues = new StringBuilder();
                        sb.AppendFormat("INSERT INTO [{0}] (", tableName);
                        for (int i = 0; i + 1 < paramList.Length; i += 2)
                        {
                            if (paramList[i + 1] == null)
                                paramName = "NULL"; // use this way as AddWithValue(..., DBNull.Value) throws exception e.g. for blob (varbinary(max))
                            else
                            {
                                paramName = String.Format("@p{0}", i / 2);
                                cmd.Parameters.AddWithValue(paramName, (paramList[i + 1] == null) ? DBNull.Value : paramList[i + 1]);
                            }

                            if (i > 0)
                            {
                                sb.Append(',');
                                sbValues.Append(',');
                            }
                            sb.AppendFormat("[{0}]", (string)paramList[i]);
                            sbValues.AppendFormat(paramName);
                        }
                        sb.AppendFormat(") VALUES ({0})" +
                                        ";SELECT @ID = @@IDENTITY",
                                        sbValues.ToString());

                        retParam.Direction = ParameterDirection.Output;
                        retParam.SourceColumn = columnID;
                    }
                    else                    // update existing
                    {
                        sb.AppendFormat("UPDATE [{0}] SET ", tableName);
                        for (int i = 0; i + 1 < paramList.Length; i += 2)
                        {
                            if (paramList[i + 1] == null)
                                paramName = "NULL"; // use this way as AddWithValue(..., DBNull.Value) throws exception e.g. for blob (varbinary(max))
                            else
                            {
                                paramName = String.Format("@p{0}", i / 2);
                                cmd.Parameters.AddWithValue(paramName, paramList[i + 1]); //(paramList[i+1]==null)?DBNull.Value:paramList[i+1]);
                            }

                            if (i > 0)
                                sb.Append(',');
                            sb.AppendFormat("[{0}]={1}", (string)paramList[i], paramName);
                        }

                        sb.AppendFormat(" WHERE [{0}]=@ID", columnID);
                    }

                    // execute
                    cmd.CommandText = sb.ToString();
                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                finally { if (trn == null) { cmd.Connection.Dispose(); cmd.Connection = null; } }

            return retParam.Value;
        }
    }
}
