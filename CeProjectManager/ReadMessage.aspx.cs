using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CeProjectManager.Models;
using CeProjectManager.Tools;

namespace CeProjectManager
{
    public partial class ReadMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["messageId"] != null)
            {
                //Debug.WriteLine(Request.QueryString["messageId"]);
                int messageId;

                if (int.TryParse(Request.QueryString["messageId"], out messageId))
                {
                    using (CeSystemContext db = new CeSystemContext())
                    {
                        Message message = db.Messages.Where(m => m.MessageId == messageId).Include(s => s.Sender).SingleOrDefault();
                        if (message != null)
                        {
                            message.Unread = false;
                            db.SaveChanges();
                        }
                        
                        DataTable dt = new DataTable();
                        DataColumn column = new DataColumn("column", typeof (string));
                        
                        dt.Columns.Add(column);

                        DataRow dr = dt.NewRow();
                        dr[column] = "From: " + message.Sender.Name + " " + message.Sender.Surname + " - " + message.DateTime;
                        dt.Rows.Add(dr);
                        
                        dr = dt.NewRow();
                        dr[column] = "Subject: " + message.Subject;
                        dt.Rows.Add(dr);
                        
                        dr = dt.NewRow();
                        dr[column] = message.Text;
                        dt.Rows.Add(dr);

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
                else
                    Response.Redirect("~/ViewMessages.aspx");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          /*  if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[3].Text.StartsWith("&lt;a href"))
                    e.Row.Cells[3].Text = Server.HtmlDecode(e.Row.Cells[3].Text);

                bool unread = bool.Parse(e.Row.Cells[6].Text);

                foreach (TableCell cell in e.Row.Cells)
                    cell.BackColor = unread ? Color.White : Color.LightGray;
            }

            e.Row.Cells[1].Visible = false;
            e.Row.Cells[6].Visible = false;
           */ 
        }
    }
}