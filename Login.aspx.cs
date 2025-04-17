using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;
using System.Security.Cryptography;
using iTextSharp.text;

namespace Sample
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
           /*if (Session["username"] != null)
            {
                Response.Redirect("Default.aspx");
            }*/


        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            //string email = TextBox1.Text.Trim();
            //string password = TextBox2.Text.Trim();

            // Ensure the user provides both email and password
            /*if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
             {
                 Label2.ForeColor = System.Drawing.Color.Red;
                 Label2.Text = "Please enter both email and password.";
                 return;
             }*/
            SqlConnection con = new SqlConnection("server=DESKTOP-NCFE678; database=Electronics; integrated security=SSPI; persist security info=FALSE; TrustServerCertificate=True;");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Register WHERE EmailID='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'", con);
            // query = "SELECT * FROM Register WHERE EmailID = @Email AND Password = @Password";
            //SqlDataAdapter sda = new SqlDataAdapter(query, con);

            /* Adding parameters to prevent SQL injection
            sda.SelectCommand.Parameters.AddWithValue("@Email", email);
            sda.SelectCommand.Parameters.AddWithValue("@Password", password);*/

            DataTable dt = new DataTable();
            sda.Fill(dt);

           /*if(dt.Rows.Count == 1)
            {
                // Store the username in the session to mark them as logged in
                Session["username"] = dt.Rows[0]["EmailID"].ToString();
                // Check if the password is "123", then redirect to AddProduct.aspx directly
                if (password == "123")
                {
                    // Redirect to AddProduct.aspx if the user is an admin
                    Response.Redirect("AddProduct.aspx");
                }
                else
                {
                    // Redirect to Default.aspx if it's a regular user
                    Response.Redirect("Default.aspx");
                }


            }*/
          


            if (TextBox1.Text == "Admin@gmail.com" && TextBox2.Text == "123")
            {
                Session["admin"] = TextBox1.Text;  // Save the admin session
                Response.Redirect("AdminHome.aspx");
            }
            // Regular user login
            else if (dt.Rows.Count == 1)
            {
                Session["username"] = TextBox1.Text;
                //Session["Buy Item"] = dt;
                //fillSavedCart();
                Response.Redirect("Default.aspx");
                /* Label2.ForeColor = System.Drawing.Color.Red;
               Label2.Text = "Invalid email or password. Please try again.";*/
            }
            else
            {
                Label2.ForeColor = System.Drawing.Color.Red;
                Label2.Text = "Login failed. Invalid username or password.";
            }



        }



        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
                Response.Redirect("Register.aspx");
            
        }
        
     /*  private void fillSavedCart()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("sno");
            dt.Columns.Add("pid");
            dt.Columns.Add("pname");
            dt.Columns.Add("pimage");
            dt.Columns.Add("pdescription");
            dt.Columns.Add("pprice");
            dt.Columns.Add("pquantity");
            dt.Columns.Add("pcategory");
            dt.Columns.Add("ptotalprice");

            string mycon = "Data Source=DESKTOP-NCFE678;Initial Catalog=Electronics;Integrated Security=True";
            SqlConnection scon = new SqlConnection(mycon);
            string eyquery = "select * from CartDetails where Email='" + Session["username"].ToString() + "' ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = eyquery;
            cmd.Connection = scon;
            SqlDataAdapter da = new SqlDataAdapter(cmd); 
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(dt);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                int i = 0;
                int counter = ds.Tables[0].Rows.Count;
                while (i < counter)
                {

                    dr = dt.NewRow();
                    dr["sno"] = i + 1;
                    dr["pid"] = ds.Tables[0].Rows[i]["ProductId"].ToString();
                    dr["pname"] = ds.Tables[0].Rows[i]["ProductName"].ToString();
                    dr["pimage"] = ds.Tables[0].Rows[i]["ProductImage"].ToString();
                    dr["pdescription"] = ds.Tables[0].Rows[0]["[ProductDescription]"].ToString();
                    dr["pprice"] = ds.Tables[0].Rows[i]["Price"].ToString();
                    dr["pquantity"] = ds.Tables[0].Rows[i]["ProductQuantity"].ToString();
                    dr["pcategory"] = ds.Tables[0].Rows[0]["ProductCategory"].ToString();
                    int price = Convert.ToInt32(dr["pprice"] = ds.Tables[0].Rows[i]["Price"].ToString());
                    int quantity = Convert.ToInt16(dr["pquantity"] = ds.Tables[0].Rows[i]["ProductQuantity"].ToString());
                    int TotalPrice = price * quantity;
                    dr["ptotalprice"] = TotalPrice;
                    dt.Rows.Add(dr);
                    i = i + 1;

                }
                
            }
            else
            {
                Session["Buy Item"] = null;
            }
            Session["Buy Item"] = dt;
        }*/







    }
}
