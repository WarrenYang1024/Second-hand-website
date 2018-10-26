using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


// need exist check
public partial class backend_pages_publish : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        

    }

    protected void Confirm_PublishClick(object sender, EventArgs e)
    {

        string item_name = Request["item_name"].ToString();//get item name 
        string item_desc = Request["item_desc"].ToString();//get item description
        string item_price = Request["item_price"].ToString();//get item price
        int id = Convert.ToInt32(Session["uId"].ToString());//get user id 

        //1: empty check
        if (item_name.Equals("") || (item_desc.Equals("")) || (item_price.Equals("")))

        {
            lblvalidation.Text = "Ensure there is no empty!";
        }
        //2: email format check

        else if (Item_upload.FileName == "")
        {
            lblvalidation.Text = "Please upload item picture!";
        }


        else
        {
        //3: item name exist validation
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
            con.Open();
            string queryy = "select count(*) from Products where p_name ='" + item_name + "'";
            SqlCommand cmdd = new SqlCommand(queryy, con);
            int check = Convert.ToInt32(cmdd.ExecuteScalar().ToString());
            if (check > 0)
            {
                lblvalidation.Text = "Item name already exist, please revise it !";
            }

         //4: everything is ok→
            else
            {
                try
                {

                    Stream fs = Item_upload.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    byte[] content = br.ReadBytes((Int32)fs.Length);

                    string query = "insert into Products (p_name, p_desc, p_price, p_image, p_buyer, Id, c_id ) values (@pname, @pdesc, @pprice, @pimage, @pbuyer, @id, @c_id)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@pname", item_name);
                    cmd.Parameters.AddWithValue("@pdesc", item_desc);
                    cmd.Parameters.AddWithValue("@pprice", Convert.ToDecimal(item_price));
                    cmd.Parameters.AddWithValue("@pimage", content);
                    cmd.Parameters.AddWithValue("@pbuyer", "");
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@c_id", Convert.ToInt32(rdbCategory.SelectedValue));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblwarning.ForeColor = System.Drawing.Color.Red;
                    lblwarning.Text = "Publish succefully!";


                }

                catch (Exception ex)
                {
                    Response.Write("Error" + ex.ToString());
                }
            }
        }
    }
    
}