using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Sample
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source= ; Initial Catalog=Electronics ; Integrated Security=True ;");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Register " + "(FirstName, LastName,EmailID,Gender,Address,PhoneNo,Password) values (@FirstName, @LastName,@EmailID,@Gender,@Address,@PhoneNo,@Password)", con);
            cmd.Parameters.AddWithValue("@FirstName", TextBox1.Text);
            cmd.Parameters.AddWithValue("@LastName", TextBox2.Text);
            cmd.Parameters.AddWithValue("@EmailID", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Gender ", DropDownList1.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Address", TextBox4.Text);
            cmd.Parameters.AddWithValue("@PhoneNo", TextBox5.Text);
            cmd.Parameters.AddWithValue("@Password", TextBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Registered Successfully!";

        }

        
    }
}