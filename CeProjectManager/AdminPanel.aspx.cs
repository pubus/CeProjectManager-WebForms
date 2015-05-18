using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CeProjectManager.Models;
using CeProjectManager.Tools;

namespace CeProjectManager
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
                FormsAuthentication.RedirectToLoginPage();

            if (MySession.Current.CurrentUser == null || MySession.Current.CurrentUser.Privileges.All(p => p.Name != "Admin"))
                Response.Redirect("Default.aspx");
            
            using (CeSystemContext db = new CeSystemContext())
            {
                List<User> users = db.Users.Include(p => p.Privileges).ToList();

                foreach (User u in users)
                    u.CreatePrivilegesString();

                GridView1.DataSource = users;
                GridView1.DataBind();
            }
        }
        
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.Cells[0].Controls[2] as LinkButton;
                //Debug.WriteLine(e.Row.Cells[0].Controls.Count);
                del.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this user?');");
            }
            
            e.Row.Cells[e.Row.Cells.Count - 2].Visible = false;
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            List<DataControlField> columns = GridView1.Columns.Cast<DataControlField>().ToList();

            DataControlField privColumn = columns[columns.Count - 1];
            columns.RemoveAt(columns.Count - 1);
            columns.Insert(columns.Count - 2, privColumn);

            foreach (DataControlField c in columns)
                GridView1.Columns.Add(c);
        }

        protected void GridView1_RowEdit(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("~/EditUser.aspx?userLogin=" + GridView1.Rows[e.NewEditIndex].Cells[Tools.Tools.GetColumnIndexByName(GridView1.Rows[e.NewEditIndex], "Login")].Text);
        }

        protected void GridView1_RowDelete(object sender, GridViewDeleteEventArgs e)
        {
            using (CeSystemContext db = new CeSystemContext())
            {
                string login = GridView1.Rows[e.RowIndex].Cells[Tools.Tools.GetColumnIndexByName(GridView1.Rows[e.RowIndex], "Login")].Text;

                User user = db.Users.SingleOrDefault(u => u.Login == login);

                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    Response.Redirect("~/AdminPanel.aspx");
                }
            }
        }
    }
}