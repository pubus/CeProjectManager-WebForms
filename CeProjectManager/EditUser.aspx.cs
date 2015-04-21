using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using CeProjectManager.Models;
using CeProjectManager.Tools;

namespace CeProjectManager
{
    public partial class EditUser : Page
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

            string login = Request.QueryString["userLogin"] ?? MySession.Current.CurrentUser.Login;
            
            if (Request.UrlReferrer != null)
                ViewState["PreviousPageUrl"] = Request.UrlReferrer.ToString();
            else
                ViewState["PreviousPageUrl"] = "~/Default.aspx";
            
            using (CeSystemContext db = new CeSystemContext())
            {
                List<Privilege> privileges = db.Privileges.ToList();
                User user = db.Users.Where(u => u.Login == login).Include(p => p.Privileges).SingleOrDefault();
                bool admin = user.Privileges.Any(p => p.Name == "Admin");

                UserLogin.Value = user.Login;
                UserName.Value = user.Name;
                UserSurname.Value = user.Surname;
                UserEmail.Value = user.Email;

                foreach (Privilege p in privileges)
                {
                    ListItem listItem = new ListItem()
                    {
                        Text = p.Name + " - " + p.Description,
                        Value = p.Name,
                        Selected = user.Privileges.Any(priv => priv.Name == p.Name),
                        Enabled = admin
                    };

                    PrivilegesCheckboxList.Items.Add(listItem);
                }
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string login = Request.QueryString["userLogin"] ?? MySession.Current.CurrentUser.Login;

            using (CeSystemContext db = new CeSystemContext())
            {
                List<Privilege> privileges = db.Privileges.ToList();
                User user = db.Users.Where(u => u.Login == login)
                    .Include(m => m.Messages)
                    .Include(g => g.Groups)
                    .Include(p => p.Privileges)
                    .SingleOrDefault();
                
                foreach (ListItem i in PrivilegesCheckboxList.Items)
                {
                    Privilege privilege = user.Privileges.FirstOrDefault(p => p.Name == i.Value);

                    if (i.Selected)
                    {
                        if (privilege == null)
                            user.Privileges.Add(privileges.First(p => p.Name == i.Value));
                    }
                    else
                        user.Privileges.Remove(privilege);
                }
                
                user.Name = UserName.Value;
                user.Surname = UserSurname.Value;
                user.Login = UserLogin.Value;
                user.Email = UserEmail.Value;

                if (UserPassword1.Value != "")
                {
                    user.Password = Tools.Tools.GetHashString(UserPassword1.Value);
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }

                db.SaveChanges();
            }

            Response.Redirect(ViewState["PreviousPageUrl"].ToString());
        }

        protected void OldPasswordValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string login = Request.QueryString["userLogin"] ?? MySession.Current.CurrentUser.Login;
            string password = Tools.Tools.GetHashString(args.Value);

            using (CeSystemContext db = new CeSystemContext())
            {
                User user = db.Users.SingleOrDefault(u => u.Login == login && u.Password == password);

                args.IsValid = user != null; //because (users.Count > 0) returns bool :)
            }
        }
    }
}