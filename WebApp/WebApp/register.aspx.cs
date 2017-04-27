using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        Regex regUser = new Regex(@"^\S{5,20}$");
        Regex regPass = new Regex(@".{5,20}");
        Regex regQ = new Regex("^[a-zA-Z0-9 ].{3,}$");


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] != null)
            {
                Response.Redirect("~/homepage.aspx?page=1");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!regUser.IsMatch(txtUser.Text))
            {
                lblErr1.Text = "Invalid Username";
                lblErr1.Visible = true;
            }
            else if (!regPass.IsMatch(txtPass.Text))
            {
                lblErr1.Text = "Invalid Password";
                lblErr2.Visible = true;
            }
            else if(!regQ.IsMatch(txtQ.Text))
            {
                lblQErr.Visible = true;
            }
            else if (!regQ.IsMatch(txtA.Text))
            {
                lblAErr.Visible = true;
            }
            else
            {
                lblErr1.Visible = false;
                lblErr2.Visible = false;
                lblQErr.Visible = false;
                lblAErr.Visible = false;

                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                Server.MapPath("Database/BEAVER NEWS.mdb") + ";Persist Security Info=False");

                string queryInsert = "INSERT INTO [USER] ([user_Nick], [user_Email], [user_Pass], [user_SQ], [user_SA]) VALUES ('" + txtUser.Text + "','" + txtEmail.Text + "','" + txtPass.Text + "','" + txtQ.Text + "','" + txtA.Text + "')";
                OleDbCommand cmd2 = new OleDbCommand(queryInsert, con);

                string querySelect = "SELECT COUNT(*) FROM [USER] WHERE [user_Nick] = '"+txtUser.Text+"' OR [user_Email] = '"+txtEmail.Text+"' ";
                OleDbCommand cmd1 = new OleDbCommand(querySelect, con);

                //Validation for the execution
                try
                {

                    con.Open();
                    int dr = (int)cmd1.ExecuteScalar();
                    if (dr != 0)
                    {
                        System.Diagnostics.Debug.Write(dr);
                        lblErr1.Visible = true;
                        lblEmailErr.Visible = true;
                        lblErr1.Text = "Used Username";
                    }
                    else
                    {
                        cmd2.ExecuteNonQuery();
                        Response.Redirect("~/login.aspx", false);
                    }

                    con.Close();

                }
                catch (OleDbException)
                {
                    System.Diagnostics.Debug.Write("*******************************************error**************");
                }


            }
        }
    }
}