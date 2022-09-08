using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CeProjectManager.Models;
using CeProjectManager.Tools;

/* This is just a meaningless change for the commit */

namespace CeProjectManager
{
    public partial class AddGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
                FormsAuthentication.RedirectToLoginPage();

            if (MySession.Current.CurrentUser == null ||
                MySession.Current.CurrentUser.Privileges.All(p => p.Name != "Admin" && p.Name != "CanCreateGroups"))
                Response.Redirect("Default.aspx");

            using (CeSystemContext db = new CeSystemContext())
            {
                List<Group> groups = db.Groups.ToList();

                foreach (Group g in groups)
                {
                    UsersDropDownList.Items.Add(new ListItem(g.Name));
                }
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            using (CeSystemContext db = new CeSystemContext())
            {
               /* List<Privilege> privileges = db.Privileges.ToList();

                foreach (ListItem i in PrivilegesCheckboxList.Items)
                {
                    if (!i.Selected)
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
                db.SaveChanges();*/
            }

            Response.Redirect("~/Groups.aspx");
        }
    }
}