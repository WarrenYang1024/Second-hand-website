using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
public partial class account_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btn_login_Click(object sender, EventArgs e)
    {
        //get value from input tag
        string username = Request["username"].ToString();
        string password = Request["inputPassword"].ToString();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        con.Open();

        //check username and password
        string query = "select count(*) from Users where username ='" + username + "' and password = '" + password + "'";
        SqlCommand cmd = new SqlCommand(query, con);
        int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());

        if (check > 0)//correct
        {
            SqlCommand cmdName = new SqlCommand("select username from Users where username = '" + username + "'", con);
            SqlCommand cmdType = new SqlCommand("select type from Users where username = '" + username + "'", con);
            SqlCommand cmdId = new SqlCommand("select Id from Users where username = '" + username + "'", con);
            string uName = cmdName.ExecuteScalar().ToString().Replace(" ", "");
            string uType = cmdType.ExecuteScalar().ToString();
            string uId= cmdId.ExecuteScalar().ToString();

            //store in Session for other aspx use!!!
            //important!!!
            //use many times
            Session["uName"] = uName;
            Session["uType"] = uType;
            Session["uId"] = uId;
            Response.Redirect("../Portal.aspx");
        }
        else//incorrect
        {
            Response.Write("<script type=\"text/javascript\">alert('password is wrong!');</script>");
        }
        con.Close();
    }
}