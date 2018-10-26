using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class account_register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Btn_register_Click(object sender, EventArgs e)
    {
        //get value from input tag (user)
        string username = Request["username"].ToString(); //with runat="server", use Request[]
        string password = Request["inputPassword"].ToString();
        string password2 = Request["confirmPassword"].ToString();
        string email = Request["inputEmail"].ToString();

        //Validation
        //1: compare  2 passwords
        if (password != password2)//passwords are different
        {
            Response.Write("<script type=\"text/javascript\">alert('ensure password is same!');</script>");
        }
        //2: avoid empty input
        else if (username.Equals("") || (email.Equals("")) || (password.Equals("") || (password2.Equals("")) ))
        {
            Response.Write("<script type=\"text/javascript\">alert('ensure there is not empty');</script>");
        }
        //3: email format
        else if (IsEmail(email) == false)
        {
            Response.Write("<script type=\"text/javascript\">alert('Please check email format');</script>");
        }

        else//all ok, continue
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
            try
            {
                con.Open();

                //check exist email in database
                string query = "select count(*) from Users where email ='" + email + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                //check exist username in database
                string queryy = "select count(*) from Users where username ='" + username + "'";
                SqlCommand cmdd = new SqlCommand(queryy, con);
                int checkk = Convert.ToInt32(cmdd.ExecuteScalar().ToString());

                if (check > 0 || checkk > 0)
                {
                    Response.Write("<script type=\"text/javascript\">alert('Email or username already exist.');</script>");
                }
                else//if not exist (new user)
                {
                    string query1 = "insert into Users (username, password, email,type) values (@uname, @pword, @email, @type) ";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.Parameters.AddWithValue("@uname", username);
                    cmd1.Parameters.AddWithValue("@pword", password);
                    cmd1.Parameters.AddWithValue("@email", email);
                    cmd1.Parameters.AddWithValue("@type", "user");
                    cmd1.ExecuteNonQuery();
                    Response.Write("<script type=\"text/javascript\">alert('Registration Successful.');window.location='login.aspx';</script>");
                    //********after alert then redirect to login page.********
                    //if use Response.Redirect(""), it will not show alert and directly show login page

                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
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