using System;
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
    public partial class ViewNews : System.Web.UI.Page
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

            if (MySession.Current.CurrentUser != null)
            {
                HtmlGenericControl dl = new HtmlGenericControl("dl");
                dl.Attributes.Add("class", "dl-horizontal");

                using (CeSystemContext db = new CeSystemContext())
                {
                    foreach (Group group in MySession.Current.CurrentUser.Groups)
                    {
                        HtmlGenericControl h = new HtmlGenericControl("h2");
                        h.InnerText = group.Name;
                        h.Attributes.Add("class", "text-primary");
                        NewsContener.Controls.Add(h);
                        
                        List<News> news =
                            db.News.Include(g => g.DestinationGroup)
                                .Where(n => n.DestinationGroup.Name == group.Name)
                                .ToList();

                        foreach (News n in news)
                        {
                            HtmlGenericControl dt = new HtmlGenericControl("dt");
                            dt.InnerText = n.Subject;
                            dt.Attributes.Add("class", "text-success");
                            dl.Controls.Add(dt);

                            HtmlGenericControl dd = new HtmlGenericControl("dd");
                            dd.InnerHtml = n.DateTime + "<br/>" + n.Text;
                            dl.Controls.Add(dd);
                        }


                        /*
                HtmlGenericControl anchor = new HtmlGenericControl("a");
                anchor.Attributes.Add("href", "page.htm");
                anchor.InnerText = "TabX";
                */
                    }
                }

                NewsContener.Controls.Add(dl);
            }
        }

    }
}