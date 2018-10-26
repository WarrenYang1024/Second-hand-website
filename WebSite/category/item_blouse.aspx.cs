using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class category_item_blouse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Purchase_Click(object sender, EventArgs e)
    {
        string CurrentUser = Session["uName"].ToString();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        con.Open();
        string query = "UPDATE Products SET p_buyer = '" + CurrentUser + "' WHERE p_name = 'Blouse' ";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Write("<script type=\"text/javascript\">alert('Purchase successfully.');window.location='/Portal.aspx';</script>");
    }
}