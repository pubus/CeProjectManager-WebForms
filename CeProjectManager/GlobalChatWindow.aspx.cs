using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CeProjectManager.Tools;

namespace CeProjectManager
{
    public partial class GlobalChatWindow : System.Web.UI.Page
    {
        public string name;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated || MySession.Current.CurrentUser == null)
                FormsAuthentication.RedirectToLoginPage();

            name = MySession.Current.CurrentUser.Name + " " + MySession.Current.CurrentUser.Surname;
        }
    }
}