using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class backend_pages_profile : System.Web.UI.Page
{
    public string profile_name = "";
    public string profile_email = "";
    public string profile_type = "";

    protected void Page_Load(object sender, EventArgs e)
    {


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        con.Open();

        //get current username
        if (Session["uName"] != null) //to avoid exception from line 26,
        {
            string username = Session["uName"].ToString();//no login, session = null exception
            SqlDataAdapter da = new SqlDataAdapter("select * from Users where username ='" + username + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            profile_name = dt.Rows[0][1].ToString();
            profile_email = dt.Rows[0][3].ToString();
            profile_type = dt.Rows[0][4].ToString();
            con.Close();
        }
        else
        {
            //backmasterpage access validation 
        }
       
    }


    protected void Update_profile_Click(object sender, EventArgs e)
    {
        string new_username = Request["new_username"].ToString();
        string new_email = Request["new_email"].ToString();
        //1: empty check
        if (new_username.Equals("") || (new_email.Equals("")))

        {
            Response.Write("<script type=\"text/javascript\">alert('ensure there is not empty');</script>");
        }
        //2: email format check
        else if (IsEmail(new_email) == false)
        {
            Response.Write("<script type=\"text/javascript\">alert('Please check email format');</script>");
        }
        //3: all ok, do update
        else
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);

            try
            {
                con.Open();
                //check exist email in database
                string query = "select count(*) from Users where email ='" + new_email + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                //check exist username in database
                string queryy = "select count(*) from Users where username ='" + new_username + "'";
                SqlCommand cmdd = new SqlCommand(queryy, con);
                int checkk = Convert.ToInt32(cmdd.ExecuteScalar().ToString());

                if (check > 0 || checkk > 0)
                {
                    Response.Write("<script type=\"text/javascript\">alert('Email or username already exist.');</script>");
                }
                else
                {
                    string queryyy = "update Users set username ='" + new_username + "', email = '" + new_email + "' where username = '" + Session["uName"].ToString() + "'";
                    SqlCommand cmddd = new SqlCommand(queryyy, con);
                    cmddd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Update sucessfully! Please login again!');window.location = '../../account/login.aspx';</script>");
                    Session.Abandon();
                }

            }
            catch
            {

            }
        }
    }

    public static bool IsEmail(string inputEmail)
    {
        string strRegex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)" + @"|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(inputEmail))
            return (true);
        else
            return (false);
    }
}