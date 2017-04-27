using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class approve : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin_id"] != null && Request.QueryString["id"] != null)
            {
                int user_id = Convert.ToInt32(Session["admin_id"]);
                int id = Convert.ToInt32(Request.QueryString["id"]);

                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                       + Server.MapPath("Database/BEAVER NEWS.mdb") + ";Persist Security Info=False");

                string queryAllowed = "SELECT COUNT(*) FROM [ARTICLE] WHERE [article_ID] = " + id + " AND [article_App] = 1 ";
                OleDbCommand cmd2 = new OleDbCommand(queryAllowed, con);

                con.Open();

                int allowed = Convert.ToInt32(cmd2.ExecuteScalar());

                if (allowed == 0)
                {

                    string query = "UPDATE ARTICLE SET [article_App] = 1 WHERE [article_ID] = "+id+"";
                    OleDbCommand cmd = new OleDbCommand(query, con);

                    //Validation for the execution
                    try
                    {

                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("~/admin.aspx");
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.Write(err);
                        Response.Redirect("~/admin.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/admin.aspx");
                }

            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }
    }
}