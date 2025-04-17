using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sample
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-NCFE678; database=Electronics; integrated security=SSPI; persist security info=FALSE; TrustServerCertificate=True;");
            if (FileUpload1.HasFile)
            {
                string filename = FileUpload1.PostedFile.FileName;
                string filepath = "/Images" + FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images") + filename);
                con.Open();
                // Specify the columns explicitly (excluding the identity column)
                SqlCommand cmd = new SqlCommand("INSERT INTO Product1 (ProductName, ProductDescription, ProductImage, Price) " +
                    "VALUES ('" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + filepath + "', '" + TextBox4.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Default.aspx");





            }


        }
    }
}