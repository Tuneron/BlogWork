using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BlogWork.Models;

namespace BlogWork
{
    public partial class _Default : Page
    {
        DatabaseModel database = new DatabaseModel("Data Source=.\\SQLEXPRESS01; Initial Catalog = BlogDatabase; Integrated Security = True; Pooling=False");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (database.CheckConnection())
            {
                if (!string.IsNullOrEmpty(Request.QueryString["CurrentPost"]))
                {
                    int currentPost = Int32.Parse(Request.QueryString["CurrentPost"]);

                    LabelState.Text = "Connection success";
                    LabelState.ForeColor = System.Drawing.Color.Green;
                    database.StartConnection();
                    database.LoadPosts();
                    ThemeOfPost.InnerText = database.GetPost(currentPost).Theme;
                    DescriptionOfPost.InnerText = database.GetPost(currentPost).Description;
                    LabelDateTime.InnerText = database.GetPost(currentPost).Date;
                    LabelAuthor.InnerText = database.GetPost(currentPost).AuthorId;
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

        protected void ButtonFirstPost_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/Default.aspx?CurrentPost=0");
        }

        protected void ButtonPrevPost_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(Request.QueryString["CurrentPost"]) - 1 >= 0)
                Response.Redirect("~/WebForms/Default.aspx?CurrentPost=" +
                    (Int32.Parse(Request.QueryString["CurrentPost"]) - 1));
        }

        protected void ButtonNextPost_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(Request.QueryString["CurrentPost"]) + 1 <= database.LastPostIndex())
                Response.Redirect("~/WebForms/Default.aspx?CurrentPost=" +
                    (Int32.Parse(Request.QueryString["CurrentPost"]) + 1));
        }

        protected void ButtonLastPost_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/Default.aspx?CurrentPost=" + database.LastPostIndex());
        }

        protected void ButtonViewPost_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/ViewPost.aspx?CurrentPost=" + Int32.Parse(Request.QueryString["CurrentPost"]));
        }
    }
}