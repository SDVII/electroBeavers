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
    public partial class approval : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {

            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
               + Server.MapPath("Database/BEAVER NEWS.mdb") + ";Persist Security Info=False");
            con.Open();

            if (!Page.IsPostBack)
            {
                if (Session["admin_id"] == null)
                {
                    Response.Redirect("~/login.aspx", false);
                }
                else
                {
                    hyperlinkLogout.Visible = true;
                }

                int user_id = Convert.ToInt32(Session["user_id"]);

                //Getting news from DB
                string query = "SELECT * FROM [ARTICLE] WHERE [article_App] = 0 ORDER BY article_Date DESC ";
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

                        if (rd2.Read())
                        {

                            string url = urlMaker(rd[5] + "");

                            table.Append("<li style=\"padding-top:1%; \">");
                            table.Append("<a href=\"approve.aspx?id=" + rd[0] + "\" ><i class=\"fa fa-thumbs-o-up\" style=\"padding-right:10px\" aria-hidden=\"true\"></i></a>");
                            table.Append("<a class=\"title\" href=\"" + rd[5] + "\">" +
                            rd[1] + "</a> <a class=\"site\" href=\"" + url + "\">"
                            + " <span *ngIf=\"item.domain\" class=\"domain\">("
                            + url + ")</span></a>"
                            + "<div>" +rd[4]+ "</div>"
                            + " <div class=\"subtext-laptop\">"
                            + "  <span>By: " + rd2["user_Nick"] + "</span>"
                            + " <span>"
                            + rd[2]
                            + "  </span>"
                            + "</div>"
                            + "</li>");
                        }

                        rd2.Close();
                        rd2.Dispose();
                    }

                    PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });
                    rd.Close();

                    rd.Dispose();
                    con.Close();
                }

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