﻿using System;
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
            command.CommandText = commandString + ConcatenationValues(values);
            command.ExecuteNonQuery();
        }

        public void UpdateAvatar(string value, string columnValue)
        {
            command.CommandText = "UPDATE BLogUser SET Avatar = @value WHERE Name = @columnValue;" ;
            command.Parameters.AddWithValue("@columnValue", columnValue);
            command.Parameters.AddWithValue("@value", value);
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

        public void AddComment(string userName, string commentBody, int postId)
        {
            int userId =Int32.Parse(ExecuteSelectCommand("SELECT BlogUserId FROM BlogUser WHERE Name = '" + userName + "';", "BlogUserId"));
            ExecuteInsertCommand("INSERT INTO Comment(BlogUserId, PostId, Body)", userId.ToString(), postId.ToString(), commentBody);
        }

        public void AddPost(string Theme, string Description, string Body, string Image, string userName)
        {
            ExecuteInsertCommand("INSERT INTO Post(Date, Theme, Description, Body, Image, AuthorId)", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                Theme, Description, Body, Image, ExecuteSelectCommand("SELECT BlogUserId FROM BlogUser WHERE Name = '" + userName + "';", "BlogUserId"));
        }

        public int GetCommentsCount()
        {
            return comments.Count;
        }

        public string GetUserRank(string userName)
        {
            return ExecuteSelectCommand("SELECT Rank FROM BlogUser WHERE Name = '" + userName + "';","Rank");
        }

        public string GetUserAvatar(string userLogin)
        {
            return ExecuteSelectCommand("SELECT Avatar FROM BlogUser WHERE Name = '" + userLogin + "';", "Avatar");
        }

        public string GetPostImage(int postId)
        {
            return ExecuteSelectCommand("SELECT Image FROM Post WHERE PostId = '" + postId + "';", "Image");
        }
    }
}
