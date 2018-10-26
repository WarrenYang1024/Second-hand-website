using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class backend_pages_backendMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uType"] == null)//not login
        {
            Response.Write("<script type=\"text/javascript\">alert('No access.');window.location='../../Portal.aspx';</script>");
        }
        else if(Session["uType"].ToString().Equals("user"))//if it is user, display user's interface
        {
            lblwelcome.Text = "Hello!" + " " + Session["uName"].ToString();
            lblwelcome.ForeColor = System.Drawing.Color.Blue;
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
        else//admin → display admin's interface
        {
            lblwelcome.Text = "Hello!" + " " + Session["uName"].ToString();
            lblwelcome.ForeColor = System.Drawing.Color.Red;
            Panel1.Visible = true;
            Panel2.Visible = false;
        }
        
        
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Write("<script type=\"text/javascript\">alert('Logout sucessfully.');window.location='../../Portal.aspx';</script>");
    }
}
