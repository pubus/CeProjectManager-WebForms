using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CeProjectManager.Models;

namespace CeProjectManager
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            using (CeSystemContext db = new CeSystemContext())
            {
                List<User> users = db.Users.Include(p => p.Privileges).ToList();

                GridView1.DataSource = users;
                GridView1.DataBind();
            }
        }
    }
}