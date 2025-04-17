using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sample
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["buyitems"];  // Use the correct session key
            if (dt != null)
            {
                Label3.Text = dt.Rows.Count.ToString(); // Display number of items in the cart
            }
            else
            {
                Label3.Text = "0"; // If no items in cart
            }




        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Random ram = new Random();
            int i = ram.Next(1, 5);
            Image2.ImageUrl = "~/Images/" + i.ToString() + "jpg";


        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddToCart.aspx");
        }

       
    }
}