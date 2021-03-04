using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Manager
{
    public static class GM
    {
#region Message boxes
        public static void ShowErrorMessageBox(IWin32Window wndOwner, String text, Exception ex = null)
        {
            if (string.IsNullOrEmpty(text))
                text = "Error occured!";
            if (ex != null)
            {
                text += string.Format("{0}{0}{1}", Environment.NewLine, ex.Message);
                for (Exception subEx = ex.InnerException; subEx != null; subEx = subEx.InnerException)
                    text += string.Format("{0}{1}", Environment.NewLine, subEx.Message);

//                text += string.Format("{0}{0}{1}", Environment.NewLine, ex.ToString());
            }

            MessageBox.Show(wndOwner, text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void ShowInfoMessageBox(IWin32Window wndOwner, String text)
        {
            MessageBox.Show(wndOwner, text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult ShowQuestionMessageBox(IWin32Window wndOwner, String text)
        {
            return MessageBox.Show(wndOwner, text, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
#endregion

#region DES crypting
        private static byte[] desKey = Encoding.ASCII.GetBytes("123456789012345678901234");
        private static byte[] desIV = Encoding.ASCII.GetBytes("12345678");
        public static string DESEncrypt(string data)
        {
            if (string.IsNullOrEmpty(data))
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
            if (string.IsNullOrEmpty(data))
                return "";

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, TripleDES.Create().CreateDecryptor(desKey, desIV), CryptoStreamMode.Write))
                {
                    byte[] pwdBuf = Convert.FromBase64String(data);
                    cs.Write(pwdBuf, 0, pwdBuf.Length);
                } // !!! call ms.ToArray() till after closing cs, otherwise cs could be unflushed and ms contained uncomplete data
                return Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        #endregion

#region XML methods
        public static XElement GetXElement(XElement parent, params XName[] path)
        {
            return GetXElement(parent, true, path);
        }
        public static XElement GetXElement(XElement parent, bool required, params XName[] path)
        {
                XElement elHlp = parent;
            foreach (XName name in path)
            {
                if (elHlp == null)
                    break;
                elHlp = elHlp.Element(name);
            }

            if (elHlp == null && required)
                throw new Exception(String.Format("Tag '{0}' doesn't contain subtag '{1}'", (parent==null)?"NULL":parent.Name, path));

            return elHlp;
        }
        public static string GetXElementValue(XElement parent, params XName[] path)
        {
            XElement elHlp = GetXElement(parent, path);

            return (elHlp == null) ? "" : elHlp.Value;
        }
#endregion
    }
}
