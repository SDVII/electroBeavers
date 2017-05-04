using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class homepage : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {

            //Pagination
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + Server.MapPath("Database/BEAVER NEWS.mdb") + ";Persist Security Info=False");
            con.Open();

            string limitQuery = "Select COUNT(*) FROM ARTICLE WHERE [article_Type] = 0 ";
            OleDbCommand cmdLimit = new OleDbCommand(limitQuery, con);
            int articlelimit = Convert.ToInt32(cmdLimit.ExecuteScalar());
            int max = articlelimit;
            
            int page = 1;
            if (Request.QueryString["page"] != null || page > 0)
            {
                page = Convert.ToInt32(Request.QueryString["page"]);
                if (page == 0)
                {
                    page = 1;
                }
                max = max / page;
            }
            else
            {
                if (page == 0)
                {
                    page = 1;
                }
                
            }

            if (max<15)
            {
                next.Enabled = false;
                int nextpage = page;
            }
            else
            {
                int nextpage = page + 1;
                next.Enabled = true;
                next.NavigateUrl = "~/homepage.aspx?page=" + nextpage + "";
            }
       
            if (page <= 1)
            {
                prev.Enabled = false;
                int prevpage = page;
            }
            else
            {
                prev.Enabled = true;
                int prevpage = page - 1;
                prev.NavigateUrl = "~/homepage.aspx?page=" + prevpage + "";
            }
            //End of Pagination
            

            if (Session["user_id"] != null)
            {
                int user_id = Convert.ToInt32(Session["user_id"]);
                hyperLogin.Visible = false;
                hyperlinkLogout.Visible = true;
            }
            else
            {
                hyperLogin.Visible = true;
                hyperlinkLogout.Visible = false;
            }

            if (!Page.IsPostBack)
            {
                int user_id = Convert.ToInt32(Session["user_id"]);

                //Getting news from DB
                string query = "SELECT TOP 15 * FROM ( Select TOP " + max + " * FROM [ARTICLE] WHERE [article_Type] = 0 ORDER BY [article_Date] ASC) WHERE [article_App] = true AND [article_Type] = 0 ORDER BY [article_Date] DESC ";
                OleDbCommand cmd1 = new OleDbCommand(query, con);
                
                OleDbDataReader rd = cmd1.ExecuteReader();
                table.Append("<table border=0>");

                //Itterating through the results for display
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        string getUserQuery = "SELECT user_Nick FROM [USER] WHERE user_ID = " + rd[3] + "";
                        OleDbCommand cmd2 = new OleDbCommand(getUserQuery, con);
                        OleDbDataReader rd2 = cmd2.ExecuteReader();

                        string queryLikes = "SELECT COUNT(*) FROM [LIKES] WHERE [article_ID] = " + rd[0] + " ";
                        OleDbCommand cmd3 = new OleDbCommand(queryLikes, con);

                        string queryAllowed = "SELECT COUNT(*) FROM [LIKES] WHERE [article_ID] = " + rd[0] + " AND [user_ID] = "+user_id+" ";
                        OleDbCommand cmd4 = new OleDbCommand(queryAllowed, con);

                        string queryComment = "SELECT COUNT(*) FROM [COMMENTS] WHERE [article_ID] = " + rd[0] + " ";
                        OleDbCommand cmd5 = new OleDbCommand(queryComment, con);

                        string queryVisible = "SELECT COUNT(*) FROM [HIDDEN] WHERE [article_ID] = " + rd[0] + " AND [user_ID] = " + user_id + " ";
                        OleDbCommand cmd6 = new OleDbCommand(queryVisible, con);

                        if (rd2.Read())
                        {
                            int hiddenStat = Convert.ToInt32(cmd6.ExecuteScalar());

                            if (hiddenStat == 0)
                            {

                                string url = urlMaker(rd[5] + "");

                                int likes = Convert.ToInt32(cmd3.ExecuteScalar());
                                int allowed = Convert.ToInt32(cmd4.ExecuteScalar());
                                int comments = Convert.ToInt32(cmd5.ExecuteScalar());

                                table.Append("<li style=\"padding-top:1%; \">");
                                if (allowed == 0)
                                {
                                    table.Append("<a href=\"like.aspx?id=" + rd[0] + "\" ><i class=\"fa fa-heart\" style=\"padding-right:10px\" aria-hidden=\"true\"></i></a>");
                                }
                                table.Append("<a class=\"title\" href=\"" + rd[5] + "\">" +
                                rd[1] + "</a> <a class=\"site\" href=\"" + url + "\">"
                                + " <span *ngIf=\"item.domain\" class=\"domain\">("
                                + url + ")</span></a>"
                                + " <div class=\"subtext-laptop\">"
                                + " <span>"
                                + likes + " points by"
                                + "  <span>" + rd2["user_Nick"] + "</span>"
                                + " </span>"
                                + " <span>"
                                + rd[2]
                                + "  <span> |"
                                + "   <span>" + comments + " Comments</span>"
                                + " </span> |"
                                + " <a href=\"discuss.aspx?id="+rd[0]+"\"><span *ngIf=\"item.comments_count === 0\">discuss</span></a> "
                                + "<span>(<a href=\"hide.aspx?id="+rd[0]+"\">hide</a>)</span>"
                                + "  </span>"
                                + "  </span>"
                                + "</div>"
                                + "</li>");
                            }

                        }
                        rd2.Close();
                        rd2.Dispose();
                    }

                }

                PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });
                rd.Close();
                
                rd.Dispose();
                con.Close();
                
            }


        }

        public string urlMaker(string oldUrl)
        {
            string newUrl = " ";
            int count = 0;

            foreach (char c in oldUrl)
            {
                if (count == 3)
                {
                    break;
                }
                else
                {
                    newUrl = newUrl + c;
                    if (c == '/')
                    {
                        count++;
                    }
                }
            }

            return newUrl;
        }

    }
}

    
