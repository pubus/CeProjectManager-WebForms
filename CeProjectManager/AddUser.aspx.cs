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
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
                FormsAuthentication.RedirectToLoginPage();

            if (MySession.Current.CurrentUser == null || MySession.Current.CurrentUser.Privileges.All(p => p.Name != "Admin"))
                Response.Redirect("Default.aspx");

            if (!IsPostBack)
            {
                using (CeSystemContext db = new CeSystemContext())
                {
                    List<Privilege> privileges = db.Privileges.ToList();

                    foreach (Privilege p in privileges)
                    {
                        PrivilegesCheckboxList.Items.Add(new ListItem()
                        {
                            Text = p.Name + " - " + p.Description,
                            Value = p.Name,
                        });
                    }
                }
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            using (CeSystemContext db = new CeSystemContext())
            {
                List<Privilege> privileges = db.Privileges.ToList();

                foreach (ListItem i in PrivilegesCheckboxList.Items)
                {
                    if(!i.Selected)
                        privileges.RemoveAll(p => p.Name == i.Value);
                }

                User newUser = new User()
                {
                    Name = UserName.Value,
                    Surname = UserSurname.Value,
                    Login = UserLogin.Value,
                    Password = Tools.Tools.GetHashString(UserPassword1.Value),
                    Email = UserEmail.Value,
                    Privileges = privileges
                };

                db.Users.Add(newUser);
                db.SaveChanges();
            }

            Response.Redirect("~/AdminPanel.aspx");
        }

        protected void loginValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            using (CeSystemContext db = new CeSystemContext())
            {
                List<User> users = db.Users.Where(u => u.Login == args.Value).ToList();

                if (users.Count > 0)
                    args.IsValid = false;
                else
                    args.IsValid = true;
            }
        }
    }
}