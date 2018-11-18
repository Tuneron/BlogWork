using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlogWork.Models;
using System.Web.UI.HtmlControls;

namespace BlogWork.WebForms
{
    public partial class ViewPost : System.Web.UI.Page
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
                    PostBodyText.InnerText = database.GetPost(currentPost).Body;
                    LabelDateTime.InnerText = database.GetPost(currentPost).Date;
                    LabelAuthor.InnerText = database.GetPost(currentPost).AuthorId;

                    database.LoadComments();

                    for (int i = 0; i < 3; i++)
                    {
                        if (database.GetComment(i).PostId == currentPost)
                        {
                            HtmlGenericControl div = new HtmlGenericControl("div");
                            div.Controls.Add(new Label() { Text = database.GetComment(i).BlogUserId + "  say: " + "\r\n" });
                            div.Controls.Add(new Label() { Text = database.GetComment(i).Body + "\r\n" });
                            div1.Controls.Add(div);
                        }
                    }

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
    }
}