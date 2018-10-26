using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class backend_pages_searchitem : System.Web.UI.Page
{
    //ready to get data 
    public string display_item_name = "";
    public string display_desc = "";
    public string display_price = "";

    public static int temp; //update and delete part
                            //to store the item_id that user searched, restrain condition
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel_display.Visible = false;
    }

    protected void Search_Click(object sender, EventArgs e)
    {

        string s_name = Request["item_name"].ToString();//get whay user type in textbox
                                                        //search from Products where = this

        int Id = Convert.ToInt32(Session["uId"].ToString()); //get current login user Id
        int item_owner_Id;//to get item owner's Id from Products 
                          //to compare with Id
        
        //1: empty validation
        if (s_name.Equals(""))
        {
            lbl_result.Text = "please enter item name!";
        }
        else
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
            con.Open();

            //display item information 
            SqlDataAdapter da = new SqlDataAdapter("select * from Products where p_name='"+ s_name + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            try
            {
                
                string p_id = dt.Rows[0][0].ToString();
                temp= Convert.ToInt32(dt.Rows[0][0].ToString());//used for "update", to find the related item where
                Session["p_id"] = dt.Rows[0][0].ToString();//to handler.ashx use

                display_item_name = dt.Rows[0][1].ToString();
                display_desc = dt.Rows[0][2].ToString();
                display_price = dt.Rows[0][3].ToString();
                item_owner_Id = Convert.ToInt32(dt.Rows[0][6].ToString());
                rdb_category.SelectedValue= dt.Rows[0][7].ToString();
                Img_display.ImageUrl = "ImageHandler.ashx?ID=" + p_id;
                con.Close();

                
                //admin or item belongs to current user
                //can update and delete
                if (Session["uType"].ToString().Equals("admin") || Id == item_owner_Id )
                {
                    btn_update.Disabled = false;

                    btn_delete.Disabled = false;
                }

                else//item owner Id != current user
                    //item not belongs to current user (other users)

                {
                    btn_update.Disabled = true;

                    btn_delete.Disabled = true;
                }
                
                Panel_display.Visible = true;

            }
            catch
            {
                lbl_result.Text = "can't find this item!";
                lbl_result.Visible = true;

            }
        }
    }

    protected void Update_item_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        con.Open();
        string new_item_name = Request["new_item_name"].ToString();//new item name
        string new_item_desc = Request["new_item_desc"].ToString();//new item description
        decimal new_item_price = Convert.ToDecimal(Request["new_item_price"].ToString());//new item price
        int new_category = Convert.ToInt32(rdb_category.SelectedValue);//new category

        //update new data
        string query = "update Products set p_name ='" + new_item_name + "', p_desc = '" + new_item_desc + "', p_price = '" + new_item_price + "', c_id='" + new_category + "' where p_id =" + temp;
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Write("<script>alert('Update sucessfully!')</script>");
    }

    protected void Delete_item_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        con.Open();
        string query = "delete from Products where p_id ='" + temp + "'";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Write("<script>alert('Delete sucessfully!')</script>");
    }


}