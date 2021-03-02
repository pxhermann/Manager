using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Security.Cryptography;

namespace Manager
{
#region Helper classes with particular config data
    public class CfgViewData
    {
        public string Name;
        public int SortColIdx;
        public bool SortAsc;
        //	    [XmlElement( typeof(CfgColumnData) )]
        public List<CfgColumnData> Columns = new List<CfgColumnData>();

        public CfgViewData()
        {
            Reset();
        }
        public CfgViewData(string name, int sortColIdx, bool sortAsc)
        {
            Name = name;
            SortColIdx = sortColIdx;
            SortAsc = sortAsc;
        }
        public void Reset()
        {
            Name = "";
            SortColIdx = 0;
            SortAsc = false;

            Columns.Clear();
        }
    }
    public class CfgColumnData
    {
        public int DisplayIndex;
        public int Width;
        public string DataPropertyName;

        public CfgColumnData()
        {
            Reset();
        }
        public CfgColumnData(int displayIndex, int width, string dataPropertyName)
        {
            DisplayIndex = displayIndex;
            Width = width;
            DataPropertyName = dataPropertyName;
        }
        public void Reset()
        {
            DisplayIndex = -1;
            Width = -1;
            DataPropertyName = "";
        }
    }
#endregion

// main class for working with application setting
    public class AppSetting
    {
        public int LastUserID;
#if _DB_MDB
        public MdbConnData Mdb = new MdbConnData();
#elif _DB_SQLCE
        public SqlCeConnData SqlCe= new SqlCeConnData();
#else
        public SqlConnData Sql = new SqlConnData();
#endif

		public AppSetting()
		{
			Reset();
		}
        private static string CfgFileName
        {
            get { return Path.ChangeExtension(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName, ".cfg"); }
        }
		public void Reset()
		{
            LastUserID = GD.INVALID_ID;
#if _DB_MDB
            Mdb.Reset();
#elif _DB_SQLCE
            SqlCe.Reset();
#else
            Sql.Reset();
#endif
        }
        public static AppSetting Load()
		{
			AppSetting data = new AppSetting();
            if(File.Exists(CfgFileName))
			{
				try
				{
                    // load config file
					using ( StreamReader sm = new StreamReader(CfgFileName) )
					{
						XmlSerializer x = new XmlSerializer(typeof(AppSetting));
						data = (AppSetting)x.Deserialize(sm);
                    }
					// decrypt password
#if _DB_MDB
                    data.Mdb.Pwd = GM.DESDecrypt(data.Mdb.Pwd);
#elif _DB_SQLCE
                    data.SqlCe.Pwd = GM.DESDecrypt(data.SqlCe.Pwd);
#else
                    data.Sql.Pwd = GM.DESDecrypt(data.Sql.Pwd);
#endif
				}
				catch(Exception ex)
				{
//					MessageBox.Show(string.Format("Error occured when loading setup data!{0}{0}", Environment.NewLine, ex.Message);
				}
			}
			return data;
		}
		public void Save()
		{
#if _DB_MDB
			string prevPwd = Mdb.Pwd;
#elif _DB_SQLCE
			string prevPwd = SqlCe.Pwd;
#else
			string prevPwd = Sql.Pwd;
#endif

			try
			{
                // encrypt password
#if _DB_MDB
			    Mdb.Pwd = GM.DESEncrypt(Mdb.Pwd);
#elif _DB_SQLCE
			    SqlCe.Pwd = GM.DESEncrypt(SqlCe.Pwd);
#else
                Sql.Pwd = GM.DESEncrypt(Sql.Pwd);
#endif
				// save to cfg file
				using (StreamWriter sw = new StreamWriter(CfgFileName))
				{
					XmlSerializer x = new XmlSerializer(this.GetType());
					x.Serialize(sw, this);
				}
			}
			catch(Exception ex)
			{
//  			MessageBox.Show(string.Format("Error occured when saving setup data!{0}{0}", Environment.NewLine, ex.Message);
			}
            finally
            {
#if _DB_MDB
			    Mdb.Pwd = GM.DESEncrypt(Mdb.Pwd);
#elif _DB_SQLCE
			    SqlCe.Pwd = prevPwd;
#else
			    Sql.Pwd = prevPwd;
#endif
            }
		}
    }

// main class for working with user setting
    public class UserSetting
    {
//	    [XmlElement( typeof(CfgViewData) )]
        public List<CfgViewData> Views = new List<CfgViewData>();

		public UserSetting()
		{
			Reset();
		}
		public void Reset()
		{
            Views.Clear();
        }
        private static string CfgFileName
        {
            get { return string.Format("{0}{1}{2}.cfg", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Path.DirectorySeparatorChar, System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].Name); }
        }

#region load / save to file
		public static UserSetting Load()
		{
			UserSetting data = new UserSetting();
            if(File.Exists(CfgFileName))
			{
				try
				{
                    // load config file
					using ( StreamReader sr = new StreamReader(CfgFileName) )
					{
						XmlSerializer x = new XmlSerializer(typeof(UserSetting));
						data = (UserSetting)x.Deserialize(sr);
                    }
				}
				catch(Exception ex)
				{
//					MessageBox.Show(string.Format("Error occured when loading setup data!{0}{0}", Environment.NewLine, ex.Message);
				}
			}
			return data;
		}
		public void Save()
		{
			try
			{
				// save to cfg file
				using (StreamWriter sw = new StreamWriter(CfgFileName))
				{
					XmlSerializer x = new XmlSerializer(this.GetType());
					x.Serialize(sw, this);
				}
			}
			catch(Exception ex)
			{
//  			MessageBox.Show(string.Format("Error occured when saving setup data!{0}{0}", Environment.NewLine, ex.Message);
			}
		}
#endregion        

#region load / save to XML string
		public static UserSetting LoadXML(string strXML)
        {
			UserSetting data = new UserSetting();
			try
			{
                using ( StringReader sr = new StringReader(strXML) )
				{
					XmlSerializer x = new XmlSerializer(typeof(UserSetting));
					data = (UserSetting)x.Deserialize(sr);
                }
			}
			catch(Exception ex)
			{
//					MessageBox.Show(string.Format("Error occured when loading setup data!{0}{0}", Environment.NewLine, ex.Message);
			}
			return data;
        }
        public string SaveXML()
        {
            StringBuilder sb = new StringBuilder();
			try
			{
				// save to cfg file
				using (StringWriter sw = new StringWriter(sb))
				{
					XmlSerializer x = new XmlSerializer(this.GetType());
					x.Serialize(sw, this);
				}
			}
			catch(Exception ex)
			{
//  			MessageBox.Show(string.Format("Error occured when saving setup data!{0}{0}", Environment.NewLine, ex.Message);
			}

            return sb.ToString();
        }
#endregion
    }
}
