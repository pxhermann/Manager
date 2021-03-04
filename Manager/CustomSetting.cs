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
        public SqlConnData Sql = new SqlConnData();

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
            LastUserID = DB.INVALID_ID;
            Sql.Reset();
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
                    data.Sql.Pwd = GM.DESDecrypt(data.Sql.Pwd);
				}
				catch(Exception ex)
				{
//					GM.ShowErrorMessageBox(null, "Error occured when loading setup data!", ex);
				}
			}
			return data;
		}
		public void Save()
		{
			string prevPwd = Sql.Pwd;

			try
			{
                // encrypt password
                Sql.Pwd = GM.DESEncrypt(Sql.Pwd);
				// save to cfg file
				using (StreamWriter sw = new StreamWriter(CfgFileName))
				{
					XmlSerializer x = new XmlSerializer(this.GetType());
					x.Serialize(sw, this);
				}
			}
			catch(Exception ex)
			{
//				GM.ShowErrorMessageBox(null, "Error occured when saving setup data!", ex);
			}
            finally
            {
			    Sql.Pwd = prevPwd;
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
//				GM.ShowErrorMessageBox(null, "Error occured when loading setup data!", ex);
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
//				GM.ShowErrorMessageBox(null, "Error occured when saving user setup data!", ex);
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
//				GM.ShowErrorMessageBox(null, "Error occured when loading setup data!", ex);
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
//				GM.ShowErrorMessageBox(null, "Error occured when loading setup data!", ex);
			}

			return sb.ToString();
        }
#endregion
    }
}
