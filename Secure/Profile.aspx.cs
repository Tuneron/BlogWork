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
                LabelName.Text = database.ExecuteSelectCommand("SELECT Name FROM BlogUser WHERE Name = '" + userLogin + "';", "Name");
                LabelRank.Text = database.ExecuteSelectCommand("SELECT Rank FROM BlogUser WHERE Name = '" + userLogin + "';", "Rank");
                if (database.ExecuteSelectCommand("SELECT Avatar FROM BlogUser WHERE Name = '" + userLogin + "';", "Avatar") != "")
                UserAvatar.ImageUrl = database.ExecuteSelectCommand("SELECT Avatar FROM BlogUser WHERE Name = '" + userLogin + "';", "Avatar");
                database.CloseConnection();
            }
        }

        protected void ButtonUploadAvatar_Click(object sender, EventArgs e)
        {
            if(UploadAvatar.HasFile)
            {
                database.StartConnection();
                UploadAvatar.SaveAs("C:/Users/Alex/source/repos/BlogWork/BlogWork/Resources/" + UploadAvatar.FileName);
                database.UpdateAvatar("~/Resources/" + UploadAvatar.FileName, FormsAuthentication.Decrypt(Request.Cookies["AuthCookie"].Value).Name);
                database.CloseConnection();
                Response.Redirect("~/Secure/Profile.aspx");
            }
        }
    }
}