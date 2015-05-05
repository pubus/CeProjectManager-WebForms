using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using CeProjectManager.Models;

namespace CeProjectManager.Tools
{
    public static class Tools
    {
        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA1.Create();  // SHA1.Create()
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString().ToLower();
        }

        public static int GetColumnIndexByName(GridViewRow row, string searchColumnName)
        {
            int columnIndex = 0;
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.ContainingField is BoundField)
                {
                    if (((BoundField)cell.ContainingField).DataField.Equals(searchColumnName))
                    {
                        break;
                    }
                }
                columnIndex++;
            }
            return columnIndex;
        }

        public static string ComputeFileHash(FileStream fileStream)
        {
            using (MD5 md5 = MD5.Create())
            {
                return BitConverter.ToString(md5.ComputeHash(fileStream)).Replace("-", "").ToLower();
            }
        }

        public static class AppSettings
        {
            static void Modify(string key, string value)
            {
                if (string.IsNullOrEmpty(key)) return;
                if (string.IsNullOrEmpty(value)) return;

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");
                appSettings.Settings.Remove(key);
                appSettings.Settings.Add(key, value);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }

            static AppSettings()
            {

            }
            
            public static string FileStorage
            {
                get { return ConfigurationManager.AppSettings["storage"]; }
                set { Modify("storage", value); }
            }
        }
    }
    
    public class MySession
    {
        // private constructor
        private MySession()
        {
            CurrentUser = null;
        }

        // Gets the current session.
        public static MySession Current
        {
            get
            {
                MySession session =
                  (MySession)HttpContext.Current.Session["__MySession__"];
                if (session == null)
                {
                    session = new MySession();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
        }

        public User CurrentUser { get; set; }
    }
}