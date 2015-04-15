using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CeProjectManager.Models;
using MySql.Data.Entity;
using System.Data.Entity;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using CeProjectManager.Tools;

namespace CeProjectManager
{
    public partial class _Default : Page
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
            
            jumbotronHeader.InnerText = "Welcome " + (MySession.Current.CurrentUser != null ? MySession.Current.CurrentUser.Name : Page.User.Identity.Name) + "!";
            
            if (MySession.Current.CurrentUser != null)
            {
                HtmlGenericControl dl = new HtmlGenericControl("dl");

                using (CeSystemContext db = new CeSystemContext())
                {
                    foreach (Group group in MySession.Current.CurrentUser.Groups)
                    {
                        HtmlGenericControl dt = new HtmlGenericControl("dt");
                        dt.InnerText = group.Name;
                        dl.Controls.Add(dt);

                        List<News> news =
                            db.News.Include(g => g.DestinationGroup)
                                .Where(n => n.DestinationGroup.Name == group.Name)
                                .ToList();

                        foreach (News n in news)
                        {
                            HtmlGenericControl dd = new HtmlGenericControl("dd");
                            dd.InnerText = n.Subject;
                            dl.Controls.Add(dd);
                        }
                    }
                }

                NewsContener.Controls.Add(dl);
            }
        }
    }
}