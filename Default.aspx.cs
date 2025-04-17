using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sample
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["addproduct"] = "false";
            if (Session["username"] != null)
            {
                Label4.Text = "Logged in as" + Session["username"].ToString();
                HyperLink1.Visible = false;
                Button1.Visible = true;
            }
            else
            {
                Label4.Text = "Hello you can login  here...";
                HyperLink1.Visible = true;
                Button1.Visible = false;
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon(); //IT GOING TO END THE SESSION
            Response.Redirect("Default.aspx");
            Label4.Text = "You have logout successful...";
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-NCFE678; database=Electronics; integrated security=SSPI; persist security info=FALSE; TrustServerCertificate=True;");
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product1 where(ProductName like '%" + TextBox1.Text + "%' ) or (ProductId like '%" + TextBox1.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataList1.DataSourceID = null;
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Session["addproduct"] = "true";
            if (e.CommandName == "AddToCart")
            {
                DropDownList list = (DropDownList)(e.Item.FindControl("DropDownList1"));
                Response.Redirect("AddToCart.aspx?id=" + e.CommandArgument.ToString() + "&quantity=" + list.SelectedItem.ToString());
            }

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}