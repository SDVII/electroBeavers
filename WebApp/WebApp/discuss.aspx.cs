using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class discuss : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder table = new StringBuilder();
            table.Clear();
            table.Append("<table border=0>");

            if (Session["user_id"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else if (Request.QueryString["id"] == null)
            {
                Response.Redirect("~/homepage.aspx?page=1");
            }

            String userId = Convert.ToString(Session["user_id"]);
            int articleId = Convert.ToInt32(Request.QueryString["id"]);
            string author = "";

            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + Server.MapPath("Database/BEAVER NEWS.mdb") + ";Persist Security Info=False");
            con.Open();
            string query = "SELECT * FROM [ARTICLE] WHERE [article_ID] = "+articleId+"";
            
            try
            {
                OleDbCommand cmd1 = new OleDbCommand(query, con);
                OleDbDataReader rd1 = cmd1.ExecuteReader();
                while (rd1.Read())
                {
                    string userQuery = "SELECT * FROM [USER] WHERE [user_ID] = "+rd1[3]+"";
                    OleDbCommand cmd2 = new OleDbCommand(userQuery, con);
                    OleDbDataReader rd2 = cmd2.ExecuteReader();

                    while (rd2.Read())
                    {
                        author = Convert.ToString(rd2[1]);
                    }

                    rd2.Dispose();
                    cmd2.Dispose();

                    articleLink.NavigateUrl = Convert.ToString(rd1[5]);
                    articleLink.Text = Convert.ToString(rd1[1]);
                    articleDiscription.Text = Convert.ToString(rd1[4]);
                    articleAuthor.Text = author;
                    articleDate.Text = Convert.ToString(rd1[2]);
                }

                string userQuery2 = "SELECT * FROM [USER] WHERE [user_ID] = "+userId+"";
                OleDbCommand cmd3 = new OleDbCommand(userQuery2, con);
                OleDbDataReader rd3 = cmd3.ExecuteReader();
                while (rd3.Read())
                {
                    userID.Text = Convert.ToString(rd3[1]);
                }

                string getCommentsQuerry = "SELECT * FROM [COMMENTS] WHERE [article_ID] = " + articleId + " ORDER BY [comment_ID] DESC";
                System.Diagnostics.Debug.Write(getCommentsQuerry);
                OleDbCommand cmd4 = new OleDbCommand(getCommentsQuerry, con);
                OleDbDataReader rd4 = cmd4.ExecuteReader();


                while (rd4.Read())
                {
                    string getCommentAuthor = "SELECT * FROM [USER] WHERE [user_ID] = "+rd4[2]+"";
                    string commentAuth = "";      
                    OleDbCommand cmd5 = new OleDbCommand(getCommentAuthor,con);
                    OleDbDataReader rd5 = cmd5.ExecuteReader();

                    string commentText = Convert.ToString(rd4[3]);
                    commentText = commentText.Replace("<br />","\r\n");

                    while (rd5.Read())
                    {
                        commentAuth = Convert.ToString(rd5[1]);
                    }

                    table.Append("<li style=\"padding-top:1%; \">");
                    table.Append("<div><b>" + commentAuth + "</b></div>" +
                        "<div>" + commentText + "</div>" + "</li>");
                    
                }
                PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });
                rd1.Dispose();
                rd3.Dispose();
                rd4.Dispose();
                cmd1.Dispose();
                cmd3.Dispose();
                cmd4.Dispose();
                con.Close();

            }
            catch (OleDbException)
            {
                
                throw;
            }

        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            String userId = Convert.ToString(Session["user_id"]);
            int articleId = Convert.ToInt32(Request.QueryString["id"]);
            string comment = commText.Text.Replace("\r\n", "<br />");

            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + Server.MapPath("Database/BEAVER NEWS.mdb") + ";Persist Security Info=False");
            con.Open();
            string query = "INSERT INTO [COMMENTS] ([article_ID] , [user_ID] , [comment_Text]) VALUES (" + articleId + " , " + userId + " , '" + comment + "')";

            try
            {
                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.ExecuteNonQuery();
                Response.Redirect(Page.Request.RawUrl, false);
            }
            catch (OleDbException)
            {
                
                throw;
            }
            
        }
    }
}