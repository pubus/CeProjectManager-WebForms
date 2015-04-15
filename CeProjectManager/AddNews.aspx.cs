using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CeProjectManager.Models;

namespace CeProjectManager
{
    public partial class AddNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (CeSystemContext db = new CeSystemContext())
            {
                List<Group> groups = db.Groups.ToList();
                
                foreach (Group g in groups)
                {
                    GroupDropDownList.Items.Add(new ListItem(g.Name));    
                }
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            using (CeSystemContext db = new CeSystemContext())
            {
                News newNews = new News()
                {
                    Subject = NewsSubject.Value,
                    Text = NewsTextBox.Text,
                    //Get group by name
                    DestinationGroup = db.Groups.Where(g => g.Name == GroupDropDownList.SelectedItem.Value).ToList()[0],
                    DateTime = DateTime.UtcNow
                };

                db.News.Add(newNews);
                db.SaveChanges();
            }

            Response.Redirect("ViewNews.aspx");
        }
    }
}