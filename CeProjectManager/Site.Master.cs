using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CeProjectManager.Tools;

namespace CeProjectManager
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*HtmlAnchor logOutButton = (HtmlAnchor)Master.FindControl("LogOutLink");
            HtmlAnchor adminPanelButton = (HtmlAnchor)Master.FindControl("AdminPanelLink");
            HtmlAnchor newsButton = (HtmlAnchor)Master.FindControl("NewsLink");
            HtmlAnchor messagesButton = (HtmlAnchor)Master.FindControl("MessagesLink");
            HtmlAnchor editProfileButton = (HtmlAnchor)Master.FindControl("EditProfileLink");
            HtmlAnchor homeButton = (HtmlAnchor)Master.FindControl("HomeLink");
            Panel chatPanel = (Panel)Master.FindControl("ChatPanel");
            */

            if (MySession.Current.CurrentUser == null)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
            
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                AdminPanelLink.Visible = false;
                NewsLink.Visible = false;
                MessagesLink.Visible = false;
                LogOutLink.Visible = false;
                EditProfileLink.Visible = false;
                HomeLink.Visible = false;
                GroupsLink.Visible = false;
                TasksLink.Visible = false;
                GlobalChat.Visible = false;
                
                LogInLink.Visible = true;
            }
            else
            {
                LogInLink.Visible = false;
            }
            
            if(MySession.Current.CurrentUser.Privileges.All(p => p.Name != "Admin"))
                AdminPanelLink.Visible = false;
        }

        protected void LogOut(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            //Response.Redirect("~/LoginPage.aspx");
            //Response.Clear();
        }

    }
}