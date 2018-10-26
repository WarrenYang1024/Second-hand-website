using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class backend_pages_changepwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Change_Click(object sender, EventArgs e)
    {
        string newpwd1 = Request["newpwd1"].ToString();//input name
        string newpwd2 = Request["newpwd2"].ToString(); ;//input name
        string user = Session["uName"].ToString();

        if (newpwd1.Equals(newpwd2)) //same password
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
            con.Open();
            string query = "update Users set password ='" + newpwd1 + "' where username = '" + user + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script type=\"text/javascript\">alert('OK');</script>");
        }
        else
        {
            Response.Write("<script type=\"text/javascript\">alert('password not same');</script>");
        }
    }
}