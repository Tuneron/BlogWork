using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlogWork.Models;
using System.Web.UI.HtmlControls;
using System.Web.Security;

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
                    if (database.GetPostImage(database.GetPost(currentPost).PostId) != "")
                    {
                        PostImage.Visible = true;
                        PostImage.ImageUrl = database.GetPostImage(database.GetPost(currentPost).PostId);
                    }
                    else
                        PostImage.Visible = false;


                    database.LoadComments();

                    for (int i = 0; i < database.GetCommentsCount(); i++)
                    {
                        if (database.GetComment(i).PostId == database.GetPost(currentPost).PostId)
                        {
                            HtmlGenericControl div = new HtmlGenericControl("div");
                            if(database.GetUserAvatar(database.GetComment(i).BlogUserId) != "")
                            div.Controls.Add(new Image() { ImageUrl= database.GetUserAvatar(database.GetComment(i).BlogUserId), CssClass="commentAvatar"});
                            else
                                div.Controls.Add(new Image() { ImageUrl = "~/Resources/UnknownUserAvatar.jpg", CssClass = "commentAvatar" });
                            div.Controls.Add(new Label() { Text = (database.GetComment(i).BlogUserId + ": \r\n"), CssClass="commentName"});
                            div.Controls.Add(new Label() { Text = database.GetComment(i).Body + "\r\n"});
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

        protected void ButtonAddComment_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["AuthCookie"] != null)
            {
                database.StartConnection();
                string UserName = (FormsAuthentication.Decrypt(Request.Cookies["AuthCookie"].Value).Name);
                database.AddComment(UserName, CommentTextArea.InnerText, database.GetPost(Int32.Parse(Request.QueryString["CurrentPost"])).PostId);
                database.CloseConnection();
                Response.Redirect("~/WebForms/ViewPost?CurrentPost=" + Int32.Parse(Request.QueryString["CurrentPost"]));
            }
            else
                Response.Redirect("~/WebForms/LogIn.aspx");
        }
    }
}