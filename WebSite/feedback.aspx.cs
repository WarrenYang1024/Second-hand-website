using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class feedback : System.Web.UI.Page
{
    public string fetchData()
    {
        string htmlStr = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        con.Open();
        string query = "select Users.username, Feedback.f_date, Feedback.f_message from Users, Feedback where Users.Id = Feedback.Id";
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string username = reader.GetString(0);
            string date = reader.GetString(1);
            string message = reader.GetString(2);
            htmlStr += "<div class='card'><div class='card-body'><h4 class='card-title'>" + username + "</h4><p class='card-text'>" + message + "</div><div class='card-footer'>" + date +"</div></div>";

        }

        con.Close();
        return htmlStr;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //login validation
        if (Session["uId"]==null)
        {
            Response.Write("<script type=\"text/javascript\">alert('Please login!');window.location='/account/login.aspx';</script>");
        }
    }

    protected void Submit_message_Click(object sender, EventArgs e)
    {
        //get current id, date, message from textarea
        int Id = Convert.ToInt32(Session["uId"].ToString());
        string date= DateTime.Now.ToString("yyyy-MM-dd");
        string message = txt_message.Value;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        con.Open();
        string query = "insert into Feedback (Id, f_date, f_message) values (@Id, @f_date, @f_message) ";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Id", Id);
        cmd.Parameters.AddWithValue("@f_date", date);
        cmd.Parameters.AddWithValue("@f_message", message);
        cmd.ExecuteNonQuery();
        con.Close();

    }
}