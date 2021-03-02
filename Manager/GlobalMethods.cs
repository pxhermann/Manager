using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Reflection;

namespace Manager
{
    public static class GM
    {
#region Error reporting
        public static void ReportError(IWin32Window owner, Exception ex)
        {
            ReportError(owner, ex, "");
        }
        public static void ReportError(IWin32Window owner, Exception ex, string text)
        {
            string s;
            if (text == null || text.Length < 1)
                s = string.Format("Error occured!{0}{0}{1}", Environment.NewLine, ex.Message);
            else
                s = string.Format("{0}{1}{1}{2}", text, Environment.NewLine, ex.Message);

            MessageBox.Show(owner, s, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        } 
#endregion

#region DES crypting
        private static byte[] desKey = Encoding.ASCII.GetBytes("123456789012345678901234");
        private static byte[] desIV = Encoding.ASCII.GetBytes("12345678");
        public static string DESEncrypt(string data)
        {
            if (data == null || data.Length < 1)
                return "";

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, TripleDES.Create().CreateEncryptor(desKey, desIV), CryptoStreamMode.Write))
                {
                    byte[] buf = Encoding.Unicode.GetBytes(data);
                    cs.Write(buf, 0, buf.Length);
                } // !!! call ms.ToArray() till after closing cs, otherwise cs could be unflushed and ms contained uncomplete data
                return Convert.ToBase64String(ms.ToArray());  // do not use Convert.ToString because ms buffer can contain unreadable characters
            }
        } 
        public static string DESDecrypt(string data)
        {
            if (data == null || data.Length < 1)
                return "";

			using ( MemoryStream ms = new MemoryStream() )
            {
			    using ( CryptoStream cs = new CryptoStream(ms, TripleDES.Create().CreateDecryptor(desKey, desIV), CryptoStreamMode.Write) )
                {
    			    byte[] pwdBuf = Convert.FromBase64String(data);
                    cs.Write(pwdBuf, 0, pwdBuf.Length);
                } // !!! call ms.ToArray() till after closing cs, otherwise cs could be unflushed and ms contained uncomplete data
                return Encoding.Unicode.GetString(ms.ToArray());
            }
        } 
#endregion

#region general helper methods
        // usage e.g.: foreach (MessageBoxIcon mbi in GetEnumValues(typeof(MessageBoxIcon)))
        public static System.Enum[] GetEnumValues(Type enumType)
        {
            if (enumType.BaseType != typeof(System.Enum))
                return new System.Enum[0];

            //get the public static fields (members of the enum)
            System.Reflection.FieldInfo[] fi = enumType.GetFields(BindingFlags.Static | BindingFlags.Public);

            //create a new enum array
            System.Enum[] values = new System.Enum[fi.Length];

            //populate with the values
            for (int iEnum = 0; iEnum < fi.Length; iEnum++)
                values[iEnum] = (System.Enum)fi[iEnum].GetValue(null);

            return values;
        }
#endregion
    }
}
