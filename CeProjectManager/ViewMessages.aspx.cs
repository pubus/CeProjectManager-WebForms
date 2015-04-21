using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CeProjectManager.Models;
using CeProjectManager.Tools;

namespace CeProjectManager
{
    public partial class ViewMessages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
                FormsAuthentication.RedirectToLoginPage();

            if (IsPostBack) return;

            if (MySession.Current.CurrentUser == null) //|| MySession.Current.CurrentUser.Privileges.All(p => p.Name != "Admin"))
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }

            using (CeSystemContext db = new CeSystemContext())
            {
                List<Message> messages = db.Messages.Where(m => m.Recipient.Login == MySession.Current.CurrentUser.Login).Include(s => s.Sender).ToList();
                DataTable dt = new DataTable();
                DataRow dr;

                DataColumn messageIdColumn = new DataColumn("MessageId", typeof(string));
                DataColumn senderColumn = new DataColumn("Sender", typeof(string));
                DataColumn subjectColumn = new DataColumn("Subject", typeof(string));
                DataColumn shortTextColumn = new DataColumn("ShortText", typeof(string));
                DataColumn dateTimeColumn = new DataColumn("DateTime", typeof(string));
                DataColumn readColumn = new DataColumn("Read", typeof(string));

                dt.Columns.Add(messageIdColumn);
                dt.Columns.Add(senderColumn);
                dt.Columns.Add(subjectColumn);
                dt.Columns.Add(shortTextColumn);
                dt.Columns.Add(dateTimeColumn);
                dt.Columns.Add(readColumn);

                foreach (Message message in messages)
                {
                    dr = dt.NewRow();

                    dr[messageIdColumn] = message.MessageId;
                    dr[senderColumn] = message.Sender.Name + " " + message.Sender.Surname;
                    dr[subjectColumn] = "<a href='ReadMessage.aspx?messageId=" + message.MessageId + "'>" + message.Subject + "</a>";
                    dr[shortTextColumn] = message.ShortText;
                    dr[readColumn] = message.Unread.ToString();

                    if (DateTime.Today == message.DateTime.Date)
                        dr[dateTimeColumn] = message.DateTime.TimeOfDay;
                    else
                        dr[dateTimeColumn] = message.DateTime.TimeOfDay;
                    
                    dt.Rows.Add(dr);
                }

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {
                if (e.Row.Cells[3].Text.StartsWith("&lt;a href"))
                    e.Row.Cells[3].Text = Server.HtmlDecode(e.Row.Cells[3].Text);

                bool unread = bool.Parse(e.Row.Cells[6].Text);

                foreach (TableCell cell in e.Row.Cells)
                    cell.BackColor =  unread ? Color.White : Color.LightGray;
            }

            e.Row.Cells[1].Visible = false;
            e.Row.Cells[6].Visible = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (CeSystemContext db = new CeSystemContext())
            {
                int messageId = int.Parse(GridView1.Rows[e.RowIndex].Cells[1].Text);

                Message messageToDelete = db.Messages.SingleOrDefault(m => m.MessageId == messageId);

                db.Messages.Remove(messageToDelete);
                db.SaveChanges();

                Response.Redirect(Request.RawUrl);
            }
        }
    }
}