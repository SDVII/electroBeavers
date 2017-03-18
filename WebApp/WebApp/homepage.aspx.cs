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
                + Server.MapPath("BEAVER NEWS.mdb") + ";Persist Security Info=False");
                string query = "SELECT * FROM ARTICLE ";

                

                OleDbCommand cmd1 = new OleDbCommand(query, con);

                con.Open();
        

                OleDbDataReader rd = cmd1.ExecuteReader();

                table.Append("<table border=0>");

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
                        //for (int i = 0; i < count; i++)  count i want to know the number of rows in the table in the database
                        //table.Append("<tr>");
                        //table.Append("<td>" + rd[0] + "</>");
                        //table.Append("<td>" + rd[1] + "</>");
                        //table.Append("<td>" + rd[2] + "</>");
                        ////table.Append("<td>" + rd[3] + "</>");
                        ////table.Append("<td>" + rd[4] + "</>");
                        //table.Append("</tr>");
                        
                    }

                }
                //table.Append("</table>");
                PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });
                rd.Close();
                rd.Dispose();
            }


        }

    
    
    
    }
}

//            if (!this.IsPostBack)
//    {
//       //Populating a DataTable from database.
//        DataTable dt = this.GetData();
 
//        //Building an HTML string.
//        StringBuilder html = new StringBuilder();
 
//        //Table start.
//        html.Append("<table border = '1'>");
 
//        //Building the Header row.
//        html.Append("<tr>");
//        foreach (DataColumn column in dt.Columns)
//        {
//            html.Append("<th>");
//            html.Append(column.ColumnName);
//            html.Append("</th>");
//        }
//        html.Append("</tr>");
 
//        //Building the Data rows.
//        foreach (DataRow row in dt.Rows)
//        {
//            html.Append("<tr>");
//            foreach (DataColumn column in dt.Columns)
//            {
//                html.Append("<td>");
//               html.Append(row[column.ColumnName]);
//                html.Append("</td>");
//            }
//            html.Append("</tr>");
//        }
 
//        //Table end.
//        html.Append("</table>");
 
//        //Append the HTML string to Placeholder.
//        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
//    }
//}
 
//private DataTable GetData()
//{
//    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
//    using (SqlConnection con = new SqlConnection(constr))
//    {
//        using (SqlCommand cmd = new SqlCommand("SELECT title, txt FROM submit"))
//        {
//            using (SqlDataAdapter sda = new SqlDataAdapter())
//            {
//                cmd.Connection = con;
//                sda.SelectCommand = cmd;
//                using (DataTable dt = new DataTable())
//                {
//                    sda.Fill(dt);
//                    return dt;
//                }
//            }
//        }
//    }
//}

    
