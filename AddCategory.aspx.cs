using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iTextSharp.tool.xml.html.HTML;

namespace Sample
{
    public partial class AddCategory : System.Web.UI.Page
    {
        string sr = "server = DESKTOP-NCFE678; database=Electronics; integrated security = SSPI; persist security info=FALSE; TrustServerCertificate=True;";
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
           {
               showGrid();
           } 

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(sr);
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Category where CategoryName = '" +TextBox1.Text.ToString()+ "' ", con1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count == 1)
            {
                Response.Write("<script>alert('This Catergory is Already Present');</script>");

            }
            else
            {
                SqlConnection con = new SqlConnection(sr);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Category (CategoryName) VALUES (@Cname)", con);
                cmd.Parameters.AddWithValue("@Cname", TextBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('One Record Added');</script>");
                TextBox1.Text = "";
                showGrid();


            }


        }
        public void showGrid()
        {
            SqlConnection conn = new SqlConnection(sr);
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Category", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            showGrid();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            showGrid();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int CId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            SqlConnection con1 = new SqlConnection(sr);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("Delete from Category where CategoryId=@1", con1 );
            cmd1.Parameters.AddWithValue("@1", CId);
            cmd1.ExecuteNonQuery();
            con1.Close();


        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            showGrid();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int cId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string categoryname = (row.FindControl("TextBox2") as TextBox).Text;
            SqlConnection con2 = new SqlConnection(sr);
            con2.Open();
            SqlCommand cmd1 = new SqlCommand("Update Category set CategoryName=@1 where CategoryId=@2", con2 );
            cmd1.Parameters.AddWithValue("@1", categoryname);
            cmd1.Parameters.AddWithValue("@2", cId);
            cmd1.ExecuteNonQuery();
            con2.Close();
            Response.Write("<script>alert('Category Updated Successful');</script>");
            GridView1.EditIndex = -1;

        }
    }
}