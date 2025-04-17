using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Sample
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["buyitems"] == null)
                {
                    Button1.Enabled = false;

                }
                else
                {
                    Button1.Enabled = true;
                }

                //Adding product to GridView
                Session["AddProduct"] = "false";
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("sno");
                dt.Columns.Add("pid");
                dt.Columns.Add("pname");
                dt.Columns.Add("pimage");
                dt.Columns.Add("pprice");
                dt.Columns.Add("pquantity");
                dt.Columns.Add("ptotalprice");

                if (Request.QueryString["id"] != null)
                {
                    if (Session["Buyitems"] == null)
                    {
                        dr = dt.NewRow();
                        SqlConnection conn = new SqlConnection("server=DESKTOP-NCFE678; database=Electronics; integrated security=SSPI; persist security info=FALSE; TrustServerCertificate=True;");
                        SqlDataAdapter da = new SqlDataAdapter("select * from Product1 where ProductId=" + Request.QueryString["id"], conn);

                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dr["sno"] = 1;
                        dr["pid"] = ds.Tables[0].Rows[0]["ProductId"].ToString();
                        dr["pname"] = ds.Tables[0].Rows[0]["ProductName"].ToString();
                        dr["pimage"] = ds.Tables[0].Rows[0]["ProductImage"].ToString();
                        dr["pprice"] = ds.Tables[0].Rows[0]["Price"].ToString();


                        dr["pquantity"] = Request.QueryString["quantity"];

                        int price = Convert.ToInt32(ds.Tables[0].Rows[0]["Price"].ToString());
                        int Quantity = Convert.ToInt16(Request.QueryString["quantity"].ToString());
                        int TotalPrice = price * Quantity;
                        dr["ptotalprice"] = TotalPrice;


                        dt.Rows.Add(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buyitems"] = dt;
                        Button1.Enabled = true;

                        GridView1.FooterRow.Cells[5].Text = "Total Amount";
                        GridView1.FooterRow.Cells[6].Text = grandtotal().ToString();
                        Response.Redirect("AddToCart.aspx");



                    }
                    else
                    {
                        dt = (DataTable)Session["buyitems"];
                        int sr;
                        sr = dt.Rows.Count;

                        dr = dt.NewRow();
                        SqlConnection scon = new SqlConnection("Data Source=DESKTOP-NCFE678;Initial Catalog=Electronics;Integrated Security=True");
                        SqlDataAdapter da = new SqlDataAdapter("select * from Product1 where ProductId=" + Request.QueryString["id"], scon);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        dr["sno"] = sr + 1;
                        dr["pid"] = ds.Tables[0].Rows[0]["ProductId"].ToString();
                        dr["pname"] = ds.Tables[0].Rows[0]["ProductName"].ToString();
                        dr["pimage"] = ds.Tables[0].Rows[0]["ProductImage"].ToString();
                        dr["pprice"] = ds.Tables[0].Rows[0]["Price"].ToString();
                        dr["pquantity"] = Request.QueryString["quantity"];

                        int price = Convert.ToInt32(ds.Tables[0].Rows[0]["Price"].ToString());
                        int quantity = Convert.ToInt16(ds.Tables[0].Rows[0]["quantity"].ToString());
                        int TotalPrice = price * quantity;
                        dr["ptotalprice"] = TotalPrice;

                        dt.Rows.Add(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buyitems"] = dt;
                        Button1.Enabled = true;

                        GridView1.FooterRow.Cells[5].Text = "Total Amount";
                        GridView1.FooterRow.Cells[6].Text = grandtotal().ToString();
                        Response.Redirect("AddToCart.aspx");






                    }
                }
                else
                {
                    dt = (DataTable)Session["buyitems"];
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (GridView1.Rows.Count > 0)
                    {
                        GridView1.FooterRow.Cells[5].Text = "Total Amount";
                        GridView1.FooterRow.Cells[6].Text = grandtotal().ToString();
                    }

                }


            }
            string OrderDate = DateTime.Now.ToShortDateString();
            Session["Orderdate"] = OrderDate;
            orderid();

        }

        //Calculate Final Price

        public int grandtotal()
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            int nrow = dt.Rows.Count;
            int i = 0;
            int totalprice = 0;
            while (i < nrow)
            {
                totalprice = totalprice + Convert.ToInt32(dt.Rows[i]["pprice"].ToString());

                i = i + 1;
            }
            return totalprice;





        }
        //Calculating Unique Order Id
        public void orderid()
        {
            String alpha = "abCdefGhijKlmnOpqRstuVwxyZ123456789";
            Random r = new Random();
            char[] myArray = new char[5];
            for (int i = 0; i < 5; i++)
            {
                myArray[i] = alpha[(int)(35 * r.NextDouble())];
            }
            string orderid;
            orderid = "Order_Id" + DateTime.Now.Second.ToString() + DateTime.Now.Date.ToString()
                + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() +
                new string(myArray) + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            Session["Orderid"] = orderid;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];

            for(int i=0; i<dt.Rows.Count - 1 ; i++)
            {
                int sr;
                int sr1;
                string qdata;
                string dtdata;
                sr = Convert.ToInt32(dt.Rows[i]["sno"].ToString());
                TableCell cell = GridView1.Rows[e.RowIndex].Cells[0];
                qdata = cell.Text;
                dtdata = sr.ToString();
                sr1 = Convert.ToInt32(qdata);

                if(sr == sr1)
                {
                    dt.Rows[1].Delete();
                    dt.AcceptChanges();
                    //item has been deleted from shopping cart
                    break;

                }

            }
            //Setting sno after deleting row from item cart
            for(int i = 1; i < dt.Rows.Count; i++)
            {
                dt.Rows[i - 1]["sno"] = 1;
                dt.AcceptChanges();
            }
            Session["buyitems"] = dt;
            Response.Redirect("AddToCart.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            DataTable dt = (DataTable)Session["buyitems"];

            if (Session["Orderid"] == null || Session["OrderDate"] == null)
            {
                Response.Write("<script>alert('Order ID or Order Date is missing.');</script>");
                return;
            }

            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (dt.Rows.Count == 0)
                {
                    Response.Write("<script>alert('Your cart is empty. You cannot place an order.');</script>");
                    return;
                }
                else
                {
                    SqlConnection scon = new SqlConnection(@"server=DESKTOP-NCFE678; database=Electronics; integrated security=SSPI; persist security info=FALSE; TrustServerCertificate=True;");
                    scon.Open();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        SqlCommand cmd = new SqlCommand("Insert into OrderDetails(orderid, sno, productid, productname, price, quantity, orderdate,status) values (@Orderid, @Sno, @Productid, @Productname, @Price, @Quantity, @OrderDate, @Status)", scon);
                        cmd.Parameters.AddWithValue("@Orderid", Session["orderid"]);
                        cmd.Parameters.AddWithValue("@Sno", dt.Rows[i]["sno"]);
                        cmd.Parameters.AddWithValue("@Productid", dt.Rows[i]["pid"]);
                        cmd.Parameters.AddWithValue("@Productname", dt.Rows[i]["pname"]); // Assuming 'pname' for product name
                        cmd.Parameters.AddWithValue("@Price", dt.Rows[i]["pprice"]);
                        cmd.Parameters.AddWithValue("@Quantity", dt.Rows[i]["pquantity"]);
                        cmd.Parameters.AddWithValue("@OrderDate", Session["OrderDate"]);
                        cmd.Parameters.AddWithValue("@Status", "Pending");
                        cmd.ExecuteNonQuery();
                    }

                    scon.Close();
                    Response.Redirect("PlaceOrder.aspx");
                }
            }

        }
    }

}