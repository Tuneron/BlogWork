using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using BlogWork.Models;

namespace BlogWork.WebForms
{
    public partial class LogIn : System.Web.UI.Page
    {
        DatabaseModel database;
        protected void Page_Load(object sender, EventArgs e)
        {
            database = new DatabaseModel("Data Source=.\\SQLEXPRESS01; Initial Catalog = BlogDatabase; Integrated Security = True; Pooling=False");

            if (database.CheckConnection())
            {
                LabelState.Text = "Connection success";
                LabelState.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                LabelState.Text = "Connection Error";
                LabelState.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ButtonLogIn_Click(object sender, EventArgs e)
        {
            LabelLogin.Text = "User is not found";
            LabelLogin.ForeColor = System.Drawing.Color.Red;

            database.StartConnection();
            if (database.Auntefication(TextBoxName.Text, TextBoxPassword.Text))
            {
                FormsAuthentication.SetAuthCookie(TextBoxName.Text, true);
                LabelLogin.Text = "Authentication successful";
                LabelLogin.ForeColor = System.Drawing.Color.Green;
                //Server.Transfer("~/Secure/Profile.aspx", true);
                Page.Response.Redirect("~/Secure/Profile.aspx", true);
            }
            database.CloseConnection();
        }
    }
}