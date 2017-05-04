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
            EnableViewState = true;
            rblType.AutoPostBack = true;
            rblType.SelectedIndexChanged += new EventHandler(rblType_SelectedIndexChanged);

            if (Session["user_id"] != null)
            {
                int user_id = Convert.ToInt32(Session["user_id"]);
                hyperLogin.Visible = false;
                hyperlinkLogout.Visible = true;
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            int user_id = Convert.ToInt32(Session["user_id"]);
            DateTime localDate = DateTime.Now;
            int type = Convert.ToInt32(rblType.SelectedValue);

            //Submitting data to DB
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
            Server.MapPath("Database/BEAVER NEWS.mdb") + ";Persist Security Info=False");
            string query = "INSERT INTO ARTICLE ([article_Title], [article_Date], [user_ID], [article_Descrip], [article_Url], [article_Type]) VALUES ('" + title.Text + "','" + localDate + "',"+user_id+",'" + txt.Text + "','" + URL.Text + "','" + type + "')";
            System.Diagnostics.Debug.Write(query);
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

        protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( Convert.ToInt32(rblType.SelectedValue)  == 0)
            {
                title.Enabled = true;
                rfvTitle.Enabled = true;
                URL.Enabled = true;
                rfvUrl.Enabled = true;
                txt.Enabled = true;
                rfvText.Enabled = false;
            }
            else if (Convert.ToInt32(rblType.SelectedValue) == 1)
            {
                title.Enabled = true;
                rfvTitle.Enabled = true;
                URL.Enabled = false;
                rfvUrl.Enabled = false;
                txt.Enabled = true;
                rfvText.Enabled = true;
            }
            else
            {
                title.Enabled = true;
                rfvTitle.Enabled = true;
                URL.Enabled = true;
                rfvUrl.Enabled = false;
                txt.Enabled = true;
                rfvText.Enabled = true;
            }
        }
    }
}