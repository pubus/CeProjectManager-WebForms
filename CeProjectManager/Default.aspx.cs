using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CeProjectManager.Models;
using MySql.Data.Entity;
using System.Data.Entity;
using CeProjectManager.Tools;

namespace CeProjectManager
{
    public partial class _Default : Page
    {
        //private List<User> users;

        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogged = MySession.Current.IsLogged;
            
            if(!isLogged)
                Server.Transfer("LoginPage.aspx", true);

            jumbotronHeader.InnerText = "Welcome " + MySession.Current.CurrentUser.Name + "!";
        }
    }
}