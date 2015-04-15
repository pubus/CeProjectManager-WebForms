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
    public partial class About : Page
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
        }
    }
}