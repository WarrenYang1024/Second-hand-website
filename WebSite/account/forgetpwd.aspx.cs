using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
public partial class account_forgetpwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        string email = Request["inputEmail"].ToString();
        string username = "";
        string password = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select username,password from Users where email =@email", con);
        cmd.Parameters.AddWithValue("@email", email);
        con.Open();
        using (SqlDataReader sdr = cmd.ExecuteReader())
        {
            if(sdr.Read())
            {
                username = sdr["username"].ToString();
                password = sdr["password"].ToString();
            }
        }
        con.Close();

        if (!string.IsNullOrEmpty(password))
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("yzcwebsitefpwd@gmail.com");
            msg.To.Add(email);
            msg.Subject = "Recover your Password";
            msg.Body = ("<h1><font face='verdana'>Dear customer:</h1></font><hr /><br/><br/><font face='Calibri' size='5'>Your username: " + username + "<br/><br/>" + "Your password: " + password + "</font><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><hr /><p align=center'><font face='Lucida Calligraphy' color='red'><b>WAPP Resale</b> @2018 All rights reserved<br/><br/>Contact us daily from 9:00am to 9:00pm;<br/><br/>+60 165543211;<br/><br/>Web Manager: WarrenYang<br/><p></font>");
            msg.IsBodyHtml = true;

            SmtpClient smt = new SmtpClient();
            smt.Host = "smtp.gmail.com";
            System.Net.NetworkCredential ntwd = new System.Net.NetworkCredential();
            ntwd.UserName = "yzcwebsitefpwd@gmail.com";
            ntwd.Password = "Wapp123123";
            smt.UseDefaultCredentials = true;
            smt.Credentials = ntwd;
            smt.Port = 587;
            smt.EnableSsl = true;
            smt.Send(msg);
            Response.Write("<script type=\"text/javascript\">alert('Your username and password are sent to your email!');window.location='login.aspx';</script>");


        }
    }
}