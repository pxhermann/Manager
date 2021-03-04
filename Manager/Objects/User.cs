using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Manager
{
    public class User
    {
        public int ID;
        //
        public string Name;
        public string Pwd;

        public UserSetting Cfg = new UserSetting();
        // access rights
        public bool ARadmin;
        //
        private bool arUser;
        public bool ARuser { get { return (ARadmin || arUser); } set { arUser = value; } }
        //
        private bool arAddr;
        public bool ARaddr { get { return (ARadmin || arAddr); } set { arAddr = value; } }
        //
        private bool arProd;
        public bool ARprod { get { return (ARadmin || arProd); } set { arProd = value; } }

        public User()
        {
            Reset();
        }
        public override string ToString()
        {
            return Name;
        }
        public bool IsValid()
        {
            return (ID != DB.INVALID_ID);
        }
        public void Reset()
        {
            ID = DB.INVALID_ID; 

            Name = "";
            Pwd  = "";

            Cfg.Reset();

            ARadmin = false;
            ARuser  = false;
            ARaddr  = false;
            ARprod  = false;
        }
        // do not catch exception here, let it fire to parent
        public void Load(DataRow r)
        {
            Reset();

            object o;
            o = r["user_id"];     if ( o != null && o != Convert.DBNull ) ID = Convert.ToInt32(o);

            o = r["user_name"];   if ( o != null && o != Convert.DBNull ) Name = Convert.ToString(o);
            o = r["user_pwd"];    if ( o != null && o != Convert.DBNull ) Pwd  = GM.DESDecrypt(Convert.ToString(o));

            o = r["user_cfgXML"];   if ( o != null && o != Convert.DBNull ) Cfg = UserSetting.LoadXML(Convert.ToString(o));

            o = r["user_ARadmin"];if ( o != null && o != Convert.DBNull ) ARadmin = Convert.ToBoolean(o);
            o = r["user_ARuser"]; if ( o != null && o != Convert.DBNull ) ARuser  = Convert.ToBoolean(o);
            o = r["user_ARaddr"]; if ( o != null && o != Convert.DBNull ) ARaddr  = Convert.ToBoolean(o);
            o = r["user_ARprod"]; if ( o != null && o != Convert.DBNull ) ARprod  = Convert.ToBoolean(o);
        }
        public void Save(DataRow r)
        {
            r.BeginEdit();
            r["user_name"] = Name;
            r["user_pwd"]  = GM.DESEncrypt(Pwd);

            r["user_cfgXML"] = Cfg.SaveXML();

            r["user_ARadmin"] = ARadmin;
            r["user_ARuser"]  = ARuser;
            r["user_ARaddr"]  = ARaddr;
            r["user_ARprod"]  = ARprod;
            r.EndEdit();
        }
    }
}
