using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class backend_pages_user_viewproducts : System.Web.UI.Page
{
    
    public string fetch_Data_onsale()

    {
        string temp = Session["uId"].ToString();//get from Session[]
                                                //to display only belongs to current user (restrain)
        string htmlStr = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        con.Open();
        string query = "SELECT Products.p_id, Products.p_name, Products.p_desc, Products.p_price, Category.c_name, Products.p_buyer FROM Products, Category, Users WHERE Products.c_id = Category.c_id AND Products.Id = Users.Id AND Products.Id ='" + temp + "'";
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int p_id = reader.GetInt32(0);
            string p_name = reader.GetString(1);
            string p_desc = reader.GetString(2);
            decimal p_price = reader.GetDecimal(3);
            string c_name = reader.GetString(4);
            string buyer = reader.GetString(5);

            htmlStr += "<tr><td>" + p_id + "</td><td>" + p_name + "</td><td>" + p_desc + "</td><td>" + p_price + "</td><td>" + c_name + "</td><td>" + buyer + "</td></tr>";

        }

        con.Close();
        return htmlStr;
    }


    public string fetch_Data_purchase()
    {
        string temp = Session["uName"].ToString();//get from login
                                                //to display current user's products
        string htmlStr = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        con.Open();
        string query = "SELECT Products.p_id, Products.p_name, Products.p_desc, Products.p_price, Category.c_name, Users.username FROM Products, Category, Users WHERE Products.c_id = Category.c_id AND Products.Id = Users.Id AND Products.p_buyer ='" + temp + "'";
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int p_id = reader.GetInt32(0);
            string p_name = reader.GetString(1);
            string p_desc = reader.GetString(2);
            decimal p_price = reader.GetDecimal(3);
            string c_name = reader.GetString(4);
            string seller = reader.GetString(5); 

            htmlStr += "<tr><td>" + p_id + "</td><td>" + p_name + "</td><td>" + p_desc + "</td><td>" + p_price + "</td><td>" + c_name + "</td><td>" + seller + "</td></tr>";

        }

        con.Close();
        return htmlStr;
        
    }
    public string Admin_fetch_Data()

    {
        
        string htmlStr = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        con.Open();
        string query = "SELECT Products.p_id, Products.p_name, Products.p_desc, Products.p_price, Products.p_buyer, Users.username, Category.c_name FROM Products, Category, Users WHERE Products.c_id = Category.c_id AND Products.Id = Users.Id";
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int p_id = reader.GetInt32(0);
            string p_name = reader.GetString(1);
            string p_desc = reader.GetString(2);
            decimal p_price = reader.GetDecimal(3);
            string buyer = reader.GetString(4);
            string seller = reader.GetString(5);
            string c_name = reader.GetString(6);
            htmlStr += "<tr><td>" + p_id + "</td><td>" + p_name + "</td><td>" + p_desc + "</td><td>" + p_price + "</td><td>" + seller + "</td><td>" + c_name + "</td><td>" + buyer + "</td></tr>";

        }

        con.Close();
        return htmlStr;
    }



        protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uType"].ToString().Equals("admin"))
        {
            Panel_User.Visible = false;
            Panel_Admin.Visible = true;
        }
        else
        {
            Panel_User.Visible = true;
            Panel_Admin.Visible = false;
        }
    }
}