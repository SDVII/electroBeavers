using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class login : System.Web.UI.Page
    {
        Regex regUser = new Regex(@"^\S{5,20}$");
        Regex regPass = new Regex(@".{5,20}");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] != null)
            {
                Response.Redirect("~/homepage.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!regUser.IsMatch(txtUser.Text))
            {
                lblErr1.Text = "Invalid Username";
                lblErr1.Visible = true;
            }
            else if(!regPass.IsMatch(txtPass.Text))
            {
                lblErr1.Text = "Invalid Password";
                lblErr2.Visible = true;
            }
            else
            {
                lblErr1.Visible = false;
                lblErr2.Visible = false;

                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + 
                Server.MapPath("Database/BEAVER NEWS.mdb") + ";Persist Security Info=False");

                string query = "SELECT [user_ID] FROM [USER] WHERE [NICKNAME] = '" + txtUser.Text + "' AND [PASSWORD] = '" + txtPass.Text +"'";
                System.Diagnostics.Debug.Write(query);
                OleDbCommand cmd = new OleDbCommand(query, con);
                

                //Validation for the execution
                try
                {
                    con.Open();
                    OleDbDataReader rd = cmd.ExecuteReader();
                    System.Diagnostics.Debug.Write(rd);
                    int count = 0;

                    while(rd.Read())
                    {
                        count++;
                        Session["user_id"] = rd[0];
                    }
                    

                    if (count==0)
                    {
                        lblErr1.Visible = true;
                        lblErr2.Visible = true;
                        lblErr1.Text = "Wrong Username";
                        lblErr2.Text = "Wrong Password";
                    }
                    else
                    {
                        while (rd.Read())
                        {   
                                                    
                        }
                        Response.Redirect("~/homepage.aspx",false);
                        
                    }
                }
                catch (OleDbException)
                {
                    lblErr1.Visible = true;
                    lblErr1.Text = "DB not working";
                }


            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/register.aspx");
        }
    }
}