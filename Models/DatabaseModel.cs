using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BlogWork.Models
{
    public class DatabaseModel
    {
        private SqlConnection conncetion;
        private SqlCommand command;
        private SqlDataReader reader;
        private List<PostModel> posts;
        private List<CommentModel> comments;

        public DatabaseModel(string connectionString)
        {
            conncetion = new SqlConnection();
            conncetion.ConnectionString = connectionString;
            command = new SqlCommand();
            command.Connection = conncetion;
        }

        public void LoadPosts()
        {
            posts = new List<PostModel>();
            command.CommandText = "SELECT * FROM Post";
            reader = command.ExecuteReader();

            int i = 0;

            while (reader.Read())
            {
                posts.Add(new PostModel());
                posts[i].PostId = (int)reader["PostId"];
                posts[i].Date = reader["Date"].ToString();
                posts[i].Theme = reader["Theme"].ToString();
                posts[i].Description = reader["Description"].ToString();
                posts[i].Body = reader["Body"].ToString();
                posts[i].Image = reader["Image"].ToString();
                posts[i].AuthorId = reader["AuthorId"].ToString();
                i++;
            }
            reader.Close();

            foreach (PostModel post in posts)
            {
                post.AuthorId = ExecuteSelectCommand("SELECT Name FROM BlogUser WHERE BlogUserId = "
                    + post.AuthorId + " ;", "Name");
            }
        }

        public void LoadComments()
        {
            comments = new List<CommentModel>();
            command.CommandText = "SELECT * FROM Comment";
            reader = command.ExecuteReader();

            int i = 0;

            while (reader.Read())
            {
                comments.Add(new CommentModel());
                comments[i].CommentId = (int)reader["CommentId"];
                comments[i].BlogUserId = reader["BlogUserId"].ToString();
                comments[i].PostId = (int)reader["PostId"];
                comments[i].Body = reader["Body"].ToString();
                i++;
            }
            reader.Close();

            foreach (CommentModel comment in comments)
            {
                comment.BlogUserId = ExecuteSelectCommand("SELECT Name FROM BlogUser WHERE BlogUserId = "
                    + comment.BlogUserId + " ;", "Name");
            }
        }

        public PostModel GetPost(int count)
        {
            return posts[count];
        }

        public CommentModel GetComment(int count)
        {
            return comments[count];
        }

        public int LastPostIndex()
        {
            return posts.Count - 1;
        }

        public bool CheckConnection()
        {
            if (conncetion != null)
                return true;
            else
                return false;
        }

        public void StartConnection()
        {
            conncetion.Open();
        }

        public void CloseConnection()
        {
            conncetion.Close();
        }

        public bool Auntefication(string login, string password)
        {
            command.CommandText = "SELECT Name, Password FROM BlogUser";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (login == reader["Name"].ToString() &&
                    password == reader["Password"].ToString())
                    return true;
            }
            return false;
        }

        public string ExecuteSelectCommand(string commandString, string value)
        {
            command.CommandText = commandString;
            reader = command.ExecuteReader();
            reader.Read();
            string resultValue = reader[value].ToString();
            reader.Close();
            return resultValue;
        }

        public void ExecuteInsertCommand(string commandString, params string[] values)
        {
            string test = (ConcatenationValues(values));
            command.CommandText = commandString + ConcatenationValues(values);
            command.ExecuteNonQuery();
        }

        private string ConcatenationValues(string[] values)
        {
            string result = " VALUES (";
            foreach (string val in values)
            {
                result += "'" + val + "', ";
            }
            return result.Remove(result.Length - 2, 1) + ");";
        }
    }
}
