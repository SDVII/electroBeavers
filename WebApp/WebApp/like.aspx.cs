using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class like : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user_id"] != null)
            {
                int user_id = Convert.ToInt32(Session["user_id"]);
                int id = Convert.ToInt32(Request.QueryString["id"]);

                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                       + Server.MapPath("Database/BEAVER NEWS.mdb") + ";Persist Security Info=False");

                string queryAllowed = "SELECT COUNT(*) FROM [LIKES] WHERE [article_ID] = " + id + " AND [user_ID] = " + user_id + " ";
                OleDbCommand cmd2 = new OleDbCommand(queryAllowed, con);

                con.Open();

                int allowed = Convert.ToInt32(cmd2.ExecuteScalar());

                if (allowed == 0)
                {
                    
                    string query = "INSERT INTO LIKES ([user_ID], [article_ID]) VALUES ('" + user_id + "','" + id + "')";

                    System.Diagnostics.Debug.Write(query);
                    OleDbCommand cmd = new OleDbCommand(query, con);

                    //Validation for the execution
                    try
                    {
                        
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("~/homepage.aspx?page=1");
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.Write(err);
                        Response.Redirect("~/homepage.aspx?page=1");
                    }
                }
                else
                {
                    Response.Redirect("~/homepage.aspx?page=1");
                }

            }
            else
            {
                Response.Redirect("~/login.aspx");
            }

           
           

        }
    }
}