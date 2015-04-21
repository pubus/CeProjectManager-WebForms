using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CeProjectManager.Models;
using CeProjectManager.Tools;

namespace CeProjectManager
{
    public partial class NewMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            HtmlAnchor adminPanelButton = (HtmlAnchor)Master.FindControl("AdminPanelLink");

            if (MySession.Current.CurrentUser == null || MySession.Current.CurrentUser.Privileges.All(p => p.Name != "Admin"))
                adminPanelButton.Visible = false;

            using (CeSystemContext db = new CeSystemContext())
            {
                List<User> users = db.Users.ToList();

                foreach (User u in users)
                    UsersDropDownList.Items.Add(new ListItem(u.Name + " " + u.Surname));
            }
        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            using (CeSystemContext db = new CeSystemContext())
            {
                Message newMessage = new Message()
                {
                    Sender = MySession.Current.CurrentUser,
                    Recipient = db.Users.SingleOrDefault(u => u.Name + " " + u.Surname == UsersDropDownList.SelectedItem.Value),
                    DateTime = DateTime.UtcNow,
                    Subject = MessageSubject.Value,
                    Text = MessageTextBox.Text,
                    Unread = true
                };

                db.Messages.Add(newMessage);
                db.SaveChanges();
            }

            Response.Redirect("~/ViewMessages.aspx");
        }
    }
}