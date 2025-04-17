using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sample
{
    public partial class Add_Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server = DESKTOP-NCFE678; database=Electronics; integrated security = SSPI; persist security info=FALSE; TrustServerCertificate=True;");
            // Ensure the user uploaded an image
            if (imageUpload1.HasFile)
            {
                // Generate the file path for the image
                string filename = imageUpload1.PostedFile.FileName;
                string filepath = "Images/" + filename;

                // Save the file on the server
                imageUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/" + filename));

                // Open the database connection
                con.Open();

                // Use parameterized queries to avoid SQL injection
                string query = "INSERT INTO Product1 (ProductName, ProductDescription, ProductImage, Price, quantity, ProductCategory) " +
                               "VALUES (@ProductName, @ProductDescription, @ProductImage, @Price, @ProductQuantity, @ProductCategory)";

                // Create the SQL command
                SqlCommand cmd = new SqlCommand(query, con);

                // Add the parameters
                cmd.Parameters.AddWithValue("@ProductName", txtName.Text);
                cmd.Parameters.AddWithValue("@ProductDescription", txtDesc.Text);
                cmd.Parameters.AddWithValue("@ProductImage", filepath);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text); // Ensure txtPrice.Text is a valid number
                cmd.Parameters.AddWithValue("@ProductQuantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@ProductCategory", DropDownList1.SelectedItem.Text);

                // Execute the query
                cmd.ExecuteNonQuery();

                // Close the connection
                con.Close();

                // Provide feedback to the user
                Response.Write("<script>alert('Product Added Successfully');</script>");

                // Redirect to the same page to reset the form
                Response.Redirect("Add_Product.aspx");
            }


        }
    }
}