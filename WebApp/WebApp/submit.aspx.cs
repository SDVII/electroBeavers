using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class submit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            DateTime localDate = DateTime.Now;

            //Submitting data to DB
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
            Server.MapPath("Database/BEAVER NEWS.mdb") + ";Persist Security Info=False");
            string query = "INSERT INTO ARTICLE ([TITLE], [DATE], [LIKES], [user_ID], [description], [url]) VALUES ('" + title.Text + "','" + localDate + "' ,'0','1','" + txt.Text + "','" + URL.Text + "')";
            OleDbCommand cmd = new OleDbCommand(query, con);

            //Validation for the execution
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Label1.Visible = true;
                Label1.Text = "Your Article was Added Successfully";
                con.Close();
            }
            catch (Exception err)
            {
                Label1.Visible = true;
                Label1.Text = "Error !!";
            }



        }
    }
}