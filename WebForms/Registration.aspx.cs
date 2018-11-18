using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BlogWork.Models;

namespace BlogWork.WebForms
{
    public partial class Registration : System.Web.UI.Page
    {
        DatabaseModel database;
        protected void Page_Load(object sender, EventArgs e)
        {
            database = new DatabaseModel("Data Source=.\\SQLEXPRESS01;Initial Catalog=BlogDatabase;Integrated Security=True;Pooling=False");
            if (database.CheckConnection())
            {
                LableState.Text = "Connection success";
                LableState.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                LableState.Text = "Connection Error";
                LableState.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            database.StartConnection();
            database.ExecuteInsertCommand("INSERT INTO BlogUser(Name, Password, Mail, Rank)",
                TextBoxName.Text,
                TextBoxPassowrdOne.Text,
                TextBoxMail.Text,
                "User");
            database.CloseConnection();
            Server.Transfer("LogIn.aspx", true);
        }
    }
}