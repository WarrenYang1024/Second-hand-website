using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uName"] != null)//after login, label to show username
        {
            lbl_display_username.Text = "Hello!" + " " + Session["uName"].ToString();
            lbl_display_username.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Portal.aspx");
    }

   
}
