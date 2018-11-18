using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BlogWork.Models;

namespace BlogWork.Secure
{
    public partial class Profile : System.Web.UI.Page
    {
        private DatabaseModel database;
        private String userLogin;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["AuthCookie"] != null)
            {
                FormsAuthenticationTicket authTicket = null;
                authTicket = FormsAuthentication.Decrypt(Request.Cookies["AuthCookie"].Value);
                userLogin = authTicket.Name;

                database = new DatabaseModel("Data Source =.\\SQLEXPRESS01; Initial Catalog = BlogDatabase; Integrated Security = True; Pooling = False");
                database.StartConnection();
                LabelName.Text = database.ExecuteSelectCommand("SELECT Name FROM Bloguser WHERE Name = '" + userLogin + "';", "Name");
                LabelRank.Text = database.ExecuteSelectCommand("SELECT Rank FROM Bloguser WHERE Name = '" + userLogin + "';", "Rank");
                database.CloseConnection();
            }
        }
    }
}