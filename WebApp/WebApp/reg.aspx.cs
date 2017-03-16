using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void send_Click(object sender, EventArgs e)
        {
            

            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
        Server.MapPath("Data.mdb") + ";Persist Security Info=False");
            string query = "INSERT INTO users ([name], [surname], [password], [username], [email]) VALUES ('" + nametxt.Text + "', '"
                + surnametxt.Text + "', '" + passtxt.Text + "', '" + usernametxt.Text + "', '" + emailtxt.Text + "')";
            //string query = "insert into ustable(uname,password,firstname,surename,email) values (@a,@b,@c,@d,@e)";
            OleDbCommand cmd = new OleDbCommand(query, con);


            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Label1.Visible = true;
                Label1.Text = "Records Added Successfully";
                con.Close();
            }
            catch (Exception err) {
                Label1.Text = "Error !!";
            }

            

        }
    }
}