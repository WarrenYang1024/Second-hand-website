<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.SessionState;
//Session transfer data
public class ImageHandler : IHttpHandler,IRequiresSessionState {

    public void ProcessRequest (HttpContext context) {

        string imgID = context.Session["p_id"].ToString();//get product id from search.aspx
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select p_image from Products where p_id =" + imgID , conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        context.Response.BinaryWrite((byte[])dr["p_image"]);
        dr.Close();
        conn.Close();
        context.Session.Remove("p_id");
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}