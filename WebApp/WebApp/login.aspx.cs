using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Entered_userName = usernameTXT.Text;
            string Entered_passowrd = passwordTXT.Text;
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + Server.MapPath("Data.mdb") + ";Persist Security Info=False");
            string query = "SELECT * FROM users WHERE name ='" + Entered_userName + "' and password ='" + Entered_passowrd + "' ";

            OleDbCommand cmd1 = new OleDbCommand(query, con);
            con.Open();
            OleDbDataReader reader = cmd1.ExecuteReader();

            if (!reader.HasRows)
            {
                Label123.Visible = true;
                Label123.Text = "Username or Password Incorrect.";
            }
            else
            {
                reader.Read();
                Label123.Visible = true;
                Label123.Text = "Login successful.";
                Response.Redirect("homepage.aspx");

            }


            //  Session["User_name"] = usernameTXT.Text;
        
        }
    }
}