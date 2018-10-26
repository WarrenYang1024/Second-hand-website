using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class backend_pages_searchuser : System.Web.UI.Page
{
    public string display_name = "";
    public string display_password = "";
    public string display_email = "";
    public string display_type = "";

    public static string temp = "";//store search textbox value. Get from 
  
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        
        
    }

    protected void Btn_search_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        con.Open();

        
        string s_username = Request["s_content"].ToString();//get what user type in textbox
        temp = Request["s_content"].ToString();//assign to static temp

        
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Users where username ='" + s_username + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                display_name = dt.Rows[0][1].ToString();
                display_password = dt.Rows[0][2].ToString();
                display_email = dt.Rows[0][3].ToString();
                display_type = dt.Rows[0][4].ToString();
                con.Close();
                Panel1.Visible = true;
            }
            catch  // if user not exist
            {
                Response.Write("<script type=\"text/javascript\">alert('can not find this user');</script>");
            }
            

       
       

       
    }

    protected void Update_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        con.Open();
        string new_username = Request["new_username"].ToString();
        string new_password = Request["new_password"].ToString();
        string new_email = Request["new_email"].ToString();

        string query = "update Users set username ='" + new_username+ "', password = '" + new_password + "', email = '" + new_email + "' where username = '" + temp + "'";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Write("<script>alert('Update sucessfully!')</script>");
        
    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        con.Open();
        string query = "delete from Users where username ='" + temp +"'";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Write("<script>alert('Delete sucessfully!')</script>");
    }
}