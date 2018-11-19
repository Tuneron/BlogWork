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
    public partial class NewPost : System.Web.UI.Page
    {
        DatabaseModel database = new DatabaseModel("Data Source =.\\SQLEXPRESS01; Initial Catalog = BlogDatabase; Integrated Security = True; Pooling = False");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (database.CheckConnection())
            {
                LabelState.Text = "Connection success";
                LabelState.ForeColor = System.Drawing.Color.Green;

                if (Request.Cookies["AuthCookie"] != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(Request.Cookies["AuthCookie"].Value);
                    string userLogin = authTicket.Name;

                    database.StartConnection();
                    if (database.GetUserRank(userLogin) == "User")
                        Response.Redirect("~/WebForms/Default.aspx?CurrentPost=0");
                    database.CloseConnection();
                }
                else
                    Response.Redirect("~/WebForms/Default.aspx?CurrentPost=0");
            }
            else
            {
                LabelState.Text = "Connection Error";
                LabelState.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ButtonAddPost_Click(object sender, EventArgs e)
        {
            database.StartConnection();
            if (FileUploadImage.HasFile)
            {
                database.LoadPosts();
                FileUploadImage.SaveAs("C:/Users/Alex/source/repos/BlogWork/BlogWork/Resources/" + FileUploadImage.FileName);
                Response.Redirect("~/WebForms/Default.aspx?CurrentPost=" + database.LastPostIndex());
                database.CloseConnection();
            }
            else
            {
                database.LoadPosts();
                database.AddPost(TextBoxTheme.Text, TextBoxDescription.Text, PostBody.InnerText,
                null, FormsAuthentication.Decrypt(Request.Cookies["AuthCookie"].Value).Name);
                Response.Redirect("~/WebForms/Default.aspx?CurrentPost=" + database.LastPostIndex());
                database.CloseConnection();
            }
        }
    }
}