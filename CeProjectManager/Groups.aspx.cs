using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CeProjectManager.Models;
using CeProjectManager.Tools;

namespace CeProjectManager
{
    public partial class Groups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
                FormsAuthentication.RedirectToLoginPage();

            if (MySession.Current.CurrentUser == null ||
                MySession.Current.CurrentUser.Privileges.All(p => p.Name != "Admin" && p.Name != "CanCreateGroups"))
                Response.Redirect("Default.aspx");

            using (CeSystemContext db = new CeSystemContext())
            {
                List<Group> groups = db.Groups.ToList();
                
                GridView1.DataSource = groups;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.Cells[0].Controls[0] as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this event?');");
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
           
        }
    }
}