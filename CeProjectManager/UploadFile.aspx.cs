using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeProjectManager
{
    public partial class UploadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                Debug.WriteLine("File name: " + FileUpload1.FileName);
                Debug.WriteLine("File size: " + FileUpload1.FileContent.Length / 1024 + "kB");

                Debug.WriteLine("Server repositorium: " + Tools.Tools.AppSettings.FileStorage);

                string filePath = Path.Combine(Tools.Tools.AppSettings.FileStorage, "Temp", FileUpload1.FileName);
                FileUpload1.SaveAs(filePath);

                //Task directory and/or DateTime
                FileInfo fileInfo = new FileInfo(filePath);


            }
        }
    }
}