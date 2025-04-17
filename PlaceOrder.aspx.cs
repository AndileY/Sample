using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sample
{
    public partial class PlaceOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-NCFE678; database=Electronics; integrated security=SSPI; persist security info=FALSE; TrustServerCertificate=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("Insert into CardDetails" + "(FirstName, LastName, CardNo,ExpireDate,CVV,BillingAddress) values (@FirsName,@LastName, @CardNo,@ExpireDate,@CVV,@BillingAddress )", con);



            cmd.Parameters.AddWithValue("@FirsName", TextBox1.Text);
            cmd.Parameters.AddWithValue("@LastName", TextBox2.Text);
            cmd.Parameters.AddWithValue("@CardNo", TextBox3.Text);
            cmd.Parameters.AddWithValue("@ExpireDate", TextBox4.Text);
            cmd.Parameters.AddWithValue("@CVV", TextBox5.Text);
            cmd.Parameters.AddWithValue("@BillingAddress", TextBox6.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<stript>alert('Payment made successful');</script>");
            Session["address"] = TextBox6.Text;
            Response.Redirect("Pdf_generate.aspx");





        }
    }
}