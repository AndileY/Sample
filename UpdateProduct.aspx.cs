using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sample
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
        string sr = "Data Source=DESKTOP-NCFE678;Initial Catalog=Electronics;Integrated Security=True";
        int Productid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null)
                {
                    Response.Redirect("Login.aspx");

                }
                ShowProduct();
            }

        }
        public void ShowProduct()
        {
            SqlConnection conn = new SqlConnection(sr);
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product1", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowProduct();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            DropDownList1.SelectedValue = "Select Category";
            ShowProduct();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            int index = e.NewEditIndex;
            GridViewRow row = (GridViewRow)GridView1.Rows[index];
            Label productId = (Label)row.FindControl("Label1");
            Productid = int.Parse(productId.Text.ToString());
            SqlConnection con = new SqlConnection(sr);
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product1 where ProductId= '" + productId.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

               


        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = Productid;
            GridViewRow row = (GridViewRow)GridView1.Rows[index];

            FileUpload fu = (FileUpload)row.FindControl("FileUpload1");
            if(fu.HasFile)
            {
                Label ProductId = (Label)row.FindControl("Label1");
                TextBox ProductName = (TextBox)row.FindControl("TextBox1");
                TextBox ProductDescription = (TextBox)row.FindControl("TextBox2");
                TextBox Price = (TextBox)row.FindControl("TextBox3");
                TextBox quantity = (TextBox)row.FindControl("TextBox4");
                string ProductCategory = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[6].FindControl("DropDownList2")).Text;

                fu.SaveAs(Server.MapPath("~/Images") + Path.GetFileName(fu.FileName));
                String ProductImage = "Images/" + Path.GetFileName(fu.FileName);

                SqlConnection con = new SqlConnection(sr);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update Product1 set ProductName=@1, ProductDescription=@2 , ProductImage=@3, Price=@4, quantity=@5, ProductCategory=@6 where ProductId=@7 ", con);
                cmd.Parameters.AddWithValue("@1", ProductName.Text);
                cmd.Parameters.AddWithValue("@2", ProductDescription.Text);
                cmd.Parameters.AddWithValue("@3", ProductImage);
                cmd.Parameters.AddWithValue("@4", Price.Text);
                cmd.Parameters.AddWithValue("@5", quantity.Text);
                cmd.Parameters.AddWithValue("@6", ProductCategory);
                cmd.Parameters.AddWithValue("@7", ProductId.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.EditIndex = -1;
                //Response.Redirect("<script>alert('Product Updated Successfully');</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Product Updated Successfully');", true);

                ShowProduct();
                DropDownList1.SelectedValue = "Select Category";

            }
            else
            {
                //Response.Redirect("<script>alert('Please Select Product Image');</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Select Product Image');", true);


            }


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Cname = DropDownList1.SelectedValue.ToString();
            if(Cname == "Select Category")
            {
                ShowProduct();
            }
            else
            {
                SqlConnection con = new SqlConnection(sr);
                SqlDataAdapter sda = new SqlDataAdapter("Select * from Product1 where ProductCategory= '" + Cname + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }

        }
    }
}