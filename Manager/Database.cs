using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
#if _DB_MDB
using System.Data.OleDb;
#elif _DB_SQLCE
using System.Data.SqlServerCe;
#else 
using System.Data.SqlClient;
#endif 
using System.Data;
using System.Data.Common;

namespace Manager
{
    public struct MdbConnData
    {
        public string DbFile;
        public string User;
        public string Pwd;

        public MdbConnData(string dbFile, string user, string pwd)
        {
            DbFile = dbFile;
            User = user;
            Pwd = pwd;
        }
        public void Reset()
        {
            DbFile = "";
            User = "";
            Pwd = "";
        }
        public string GetConnStr()
        {
            string strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='{0}';", DbFile);
            if ( !string.IsNullOrEmpty(User) )
                strConn += string.Format("User ID={0}; Password={1};", User, Pwd);

            return strConn;
        }
    }
    public struct SqlCeConnData
    {
        public string DbFile;
        public string Pwd;
        public SqlCeConnData(string dbFile, string pwd)
        {
            DbFile = dbFile;
            Pwd = pwd;
        }
        public void Reset()
        {
            DbFile = "";
            Pwd = "";
        }
        public string GetConnStr()
        {
            string strConn = string.Format("Data Source='{0}';", DbFile);
            if ( Pwd.Length > 0 )
                strConn += string.Format("Password={0};", Pwd);

            return strConn;
        }
    }
    public struct SqlConnData    // use struct instead on class, so that data can be coppied by assign command
    {
        public string Server;
        public bool AuthSQL;
        public string User;
        public string Pwd;
        public string Database;

        public SqlConnData(string srv, bool authSQL, string user, string pwd, string db)
        {
            Server = srv;
            AuthSQL = authSQL;
            User = user;
            Pwd = pwd;
            Database = db;
        }
        public void Reset()
        {
            Server = "(local)";
            AuthSQL = false;
            User = "";
            Pwd = "";
            Database = "";
        }
        public string GetConnStr(bool inclDB)
        {
            string strConn;
            if (AuthSQL)
                strConn = "Data Source=" + Server + "; User ID=" + User + "; Password=" + Pwd + ";";
            else
                strConn = "Data Source=" + Server + "; Integrated Security=SSPI;";

            if (inclDB)
                strConn += "Initial Catalog=" + Database + ";";

            return strConn;
        }
    }

	public class DB
	{
#if _DB_MDB
        public static MdbConnData ConnData = new MdbConnData();
#elif _DB_SQLCE
        public static SqlCeConnData ConnData = new SqlCeConnData();
#else
        public static SqlConnData ConnData = new SqlConnData();
#endif

        public static DbConnection GetConnection()
        {
#if _DB_MDB
            return new OleDbConnection(ConnData.GetConnStr());
#elif _DB_SQLCE
            return new SqlCeConnection(ConnData.GetConnStr());
#else
            return new SqlConnection(ConnData.GetConnStr(true));
#endif
        }

        public static DataTable GetDataTable(string selectCmdText)
        {
            DataTable dt = new DataTable();
#if _DB_MDB
            using ( OleDbConnection conn = new OleDbConnection(ConnData.GetConnStr()) )
            {
                OleDbDataAdapter da = new OleDbDataAdapter(selectCmdText, conn);
#elif _DB_SQLCE
            using ( SqlCeConnection conn = new SqlCeConnection(ConnData.GetConnStr()) )
            {
                SqlCeDataAdapter da = new SqlCeDataAdapter(selectCmdText, conn);
#else
            using ( SqlConnection conn = new SqlConnection(ConnData.GetConnStr(true)) )
            {
                SqlDataAdapter da = new SqlDataAdapter(selectCmdText, conn);
#endif
                da.Fill(dt);
            }
            return dt;
        }
        public static void ExecuteNoQuery(string cmdText, params object[] paramList)
        {
#if _DB_MDB
            using ( OleDbConnection conn = new OleDbConnection(ConnData.GetConnStr()) )
            {
                OleDbCommand cmd = new OleDbCommand(cmdText, conn);
#elif _DB_SQLCE
            using ( SqlCeConnection conn = new SqlCeConnection(ConnData.GetConnStr()) )
            {
                SqlCeCommand cmd = new SqlCeCommand(cmdText, conn);
#else
            using ( SqlConnection conn = new SqlConnection(ConnData.GetConnStr(true)) )
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
#endif
                for (int i = 0; i+1<paramList.Length; i+=2 )
                    cmd.Parameters.AddWithValue((string)paramList[i], paramList[i+1]);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static object ExecuteScalar(string cmdText, params object[] paramList)
        {
#if _DB_MDB
            using ( OleDbConnection conn = new OleDbConnection(ConnData.GetConnStr()) )
            {
                OleDbCommand cmd = new OleDbCommand(cmdText, conn);
#elif _DB_SQLCE
            using ( SqlCeConnection conn = new SqlCeConnection(ConnData.GetConnStr()) )
            {
                SqlCeCommand cmd = new SqlCeCommand(cmdText, conn);
#else
            using ( SqlConnection conn = new SqlConnection(ConnData.GetConnStr(true)) )
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
#endif
                for (int i = 0; i+1<paramList.Length; i+=2 )
                    cmd.Parameters.AddWithValue((string)paramList[i], paramList[i+1]);

                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}
