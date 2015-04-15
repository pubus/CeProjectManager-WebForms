﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlAnchor logOutButton = (HtmlAnchor)Master.FindControl("LogOutLink");
            HtmlAnchor adminPanelButton = (HtmlAnchor) Master.FindControl("AdminPanelLink");
            HtmlAnchor newsButton = (HtmlAnchor)Master.FindControl("NewsLink");
            HtmlAnchor messagesButton = (HtmlAnchor)Master.FindControl("MessagesLink");

            if (Request.QueryString["_logout"] != null)
            {
                logOutButton.Visible = false;
                adminPanelButton.Visible = false;
                newsButton.Visible = false;
                messagesButton.Visible = false;
                loginH2.InnerText = "Login Again!";
                //Session.Abandon();

                Tools.MySession.Current.IsLogged = false;
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
            else if (MySession.Current.IsLogged || this.User.Identity.IsAuthenticated)
            {
                /*logOutButton.Visible = true;
                newsButton.Visible = true;
                //messagesButton.Visible = true;
                /*
                if (MySession.Current.CurrentUser != null && MySession.Current.CurrentUser.Privileges.Any(p => p.Name == "Admin"))
                    adminPanelButton.Visible = true;
                else
                    adminPanelButton.Visible = false;
                */
                Response.Redirect("Default.aspx");
            }
        
            adminPanelButton.Visible = false;
            newsButton.Visible = false;
            messagesButton.Visible = false;
            logOutButton.Visible = false;
        }
        
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            using (CeSystemContext db = new CeSystemContext())
            {
                string storedPassword = Tools.Tools.GetHashString(Login1.Password);
                List<User> res = db.Users.Where(u => u.Login == Login1.UserName && u.Password == storedPassword).Include(g => g.Groups).Include(p => p.Privileges).ToList();

                if (res.Count > 0) //password OK, login user
                {
                    res[0].Logged = true;
                    db.SaveChanges();

                    e.Authenticated = true;
                    Tools.MySession.Current.IsLogged = true;
                    Tools.MySession.Current.CurrentUser = res[0];

                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
                }
                else
                {
                    e.Authenticated = false;
                }

            }
        }
    }
}