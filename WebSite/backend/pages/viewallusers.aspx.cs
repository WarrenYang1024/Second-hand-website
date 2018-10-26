using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class backend_pages_viewallusers : System.Web.UI.Page
{
    
    
    public string fetch_Data()
    {
        string htmlStr = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        con.Open();
        string query = "select * from Users";
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string username = reader.GetString(1);
            string password = reader.GetString(2);
            string email = reader.GetString(3);
            string type = reader.GetString(4);
            htmlStr += "<tr><td>" + id + "</td><td>" + username + "</td><td>" + password + "</td><td>" + email + "</td><td>" + type + "</td></tr>";
            
        }

        con.Close();
        return htmlStr;
    }
}