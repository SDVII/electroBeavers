using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class homepage : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {

            if(!Page.IsPostBack)
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + Server.MapPath("Database/BEAVER NEWS.mdb") + ";Persist Security Info=False");

                //Getting news from DB
                string query = "SELECT * FROM ARTICLE ";
                OleDbCommand cmd1 = new OleDbCommand(query, con);
                con.Open();
       
                OleDbDataReader rd = cmd1.ExecuteReader();
                table.Append("<table border=0>");

                //Itterating through the results for display
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {

                        table.Append("<li style=\"padding-top:1%; \"><a href=\"\"><i class=\"fa fa-heart\" style=\"padding-right:10px\" aria-hidden=\"true\"></i></a><a class=\"title\" href=\"\">" +
                        rd[1]  + "</a> <a class=\"site\" href=\"\">"
                        + " <span *ngIf=\"item.domain\" class=\"domain\">("
                        + rd[6] + ")</span></a>"
                        +" <div class=\"subtext-laptop\">"
                        +" <span>"
                        + rd[3] + " points by"
                        +"  <a href=\"\">UserName</a>"
                        +" </span>"
                        +" <span>"
                        +  rd[2]  
                        +"  <span> |"
                        +"   <span *ngIf=\"item.comments_count !== 0\">"
                        +"    X"
                        +"   <span *ngIf=\"item.comments_count > 1\">comments</span>"
                        +" </span> |"
                        +" <a href=\"\"><span *ngIf=\"item.comments_count === 0\">discuss</span></a> "
                        +"  </span>"
                        +"  </span>"
                        +"</div>"
                        +"</li>");

                    }

                }

                PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });
                rd.Close();
                rd.Dispose();
            }


        }

    
    
    
    }
}

    
