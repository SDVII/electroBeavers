using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class change_pass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + Server.MapPath("Database/BEAVER NEWS.mdb") + ";Persist Security Info=False");
            con.Open();

            string checkEmail = "SELECT COUNT(*) FROM [USER] WHERE user_Email = '" + txtbxEmail.Text + "' ";
            OleDbCommand cmd = new OleDbCommand(checkEmail, con);
            int user = Convert.ToInt32(cmd.ExecuteScalar());

            if (user != 1 )
            {
                lblerrNotFound.Attributes["style"] = "";
            }
            else
            {
                lblerrNotFound.Attributes["style"] = "display:none";
                rfvAnswer.Enabled = true;
                revAnswer.Enabled = true;

                string getSQ = "SELECT user_SQ FROM [USER] WHERE user_Email = '" + txtbxEmail.Text + "' ";
                OleDbCommand cmd2 = new OleDbCommand(getSQ, con);
                OleDbDataReader rd2 = cmd2.ExecuteReader();

                while (rd2.Read())
                {
                    btnSubmit.Visible = false;
                    hr1.Visible = true;
                    lblQ.Visible = true;
                    lblSQ.Visible = true;
                    txtbxSA.Visible = true;
                    btnAnswer.Visible = true;
                    lblSQ.Text= rd2["user_SQ"]+" ";
                }
                rd2.Dispose();
                rd2.Close();
                con.Close();
            }

        }

        protected void btnAnswer_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
               + Server.MapPath("Database/BEAVER NEWS.mdb") + ";Persist Security Info=False");
            con.Open();

            string checkEmail = "SELECT COUNT(*) FROM [USER] WHERE user_SA = '" + txtbxSA.Text + "' ";
            OleDbCommand cmd = new OleDbCommand(checkEmail, con);
            int answer = Convert.ToInt32(cmd.ExecuteScalar());
            if (answer != 1)
            {
                lblerrWrong.Visible = true;
            }
            else
            {
                lblerrWrong.Visible = false;
                hr2.Visible = true;
                lblPass.Visible = true;
                txtbxPass1.Visible = true;
                txtbxPass2.Visible = true;
                btnChange.Visible = true;
                rfvPass.Enabled = true;
                revpass.Enabled = true;
                btnAnswer.Visible = false;
                con.Close();

            }

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            if (txtbxPass1.Text != txtbxPass2.Text)
            {
                lblMismatch.Visible = true;
            }
            else
            {
                lblMismatch.Visible = false;
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
               + Server.MapPath("Database/BEAVER NEWS.mdb") + ";Persist Security Info=False");
                con.Open();

                string changePass = "UPDATE [USER] SET [user_Pass] = '" + txtbxPass1.Text + "' WHERE [user_SA] = '"+txtbxSA.Text+"' ";
                OleDbCommand cmd = new OleDbCommand(changePass, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("~/homepage.aspx?page=1");
            }

        }
    }
}