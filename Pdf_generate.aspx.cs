using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace Sample
{
    public partial class Pdf_generate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Orderid"] != null)
            {
                string Orderid = Session["Orderid"].ToString();
                Label1.Text = Orderid;
                findorderdate(Orderid);
            }
            else
            {
                // Handle case when Orderid is null
                Response.Write("Order ID is missing.");
                Response.End();
                return;
            }

            if (Session["address"] != null)
            {
                string Address = Session["address"].ToString();
                Label3.Text = Address;
            }
            else
            {
                // Handle case when Address is null
                Response.Write("Address is missing.");
                Response.End();
                return;
            }

            showgrid(Label1.Text); // Call to populate grid and labels


        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            exportpdf();
        }
        private void exportpdf()
        {
           
            if (Panel1.Controls.Count == 0)
            {
                Response.Write("No content to export. Panel1 is empty.");
                Response.End();
                return;
            }

            if (GridView1.Rows.Count == 0)
            {
              
                Response.Write("No content in the GridView to export.");
                Response.End();
                return;
            }

           
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=OrderInvoice.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);


            StringWriter SW = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(SW);

            
            Panel1.RenderControl(hw);

       
            string renderedHtml = SW.ToString();
            if (string.IsNullOrEmpty(renderedHtml))
            {
                Response.Write("Rendered HTML is empty.");
                Response.End();
                return;
            }

            
            StringReader sr = new StringReader(renderedHtml);

           
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

         
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            
            pdfDoc.Open();

       
            iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);

            pdfDoc.Close();

            
            Response.End();



        }
        private void findorderdate(string Orderid)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-NCFE678; database=Electronics; integrated security=SSPI; persist security info=FALSE; TrustServerCertificate=True;");
            SqlCommand cmd = new SqlCommand("Select * from OrderDetails where orderid = '" + Label1.Text + "'");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label2.Text = ds.Tables[0].Rows[0]["Orderdate"].ToString();

            }
            con.Close();
    

        }
        private void showgrid(String orderid)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("sno");
            dt.Columns.Add("productid");
            dt.Columns.Add("productname");
            dt.Columns.Add("quantity");
            dt.Columns.Add("price");
            dt.Columns.Add("totalprice");
            SqlConnection scon = new SqlConnection("server=DESKTOP-NCFE678; database=Electronics; integrated security=SSPI; persist security info=FALSE; TrustServerCertificate=True;");
            SqlCommand cmd = new SqlCommand("Select * from OrderDetails where orderid = '" + Label1.Text + "'");
            cmd.Connection = scon;
            SqlDataAdapter da =  new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            int totalrows = ds.Tables[0].Rows.Count;
            int i = 0;
            int grandtotal = 0;
            while(i < totalrows)
            {
                dr = dt.NewRow();
                dr["sno"] = ds.Tables[0].Rows[i]["sno"].ToString();
                dr["productid"] = ds.Tables[0].Rows[i]["productid"].ToString();
                dr["productname"] = ds.Tables[0].Rows[i]["productname"].ToString();
                dr["quantity"] = ds.Tables[0].Rows[i]["quantity"].ToString();
                dr["price"] = ds.Tables[0].Rows[i]["price"].ToString();
                int price = Convert.ToInt32(ds.Tables[0].Rows[i]["price"].ToString());
                int quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["quantity"].ToString());
                int totalprice = price * quantity;
                dr["totalprice"] = totalprice;
                grandtotal = grandtotal + totalprice;
                dt.Rows.Add(dr);
                i = i + 1;


            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Label4.Text = grandtotal.ToString();

           



        }
    }
}