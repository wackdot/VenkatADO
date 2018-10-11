using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdoDemo
{
	public partial class WebForm6 : System.Web.UI.Page
	{
		string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

		protected void Page_Load(object sender, EventArgs e)
		{
	
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ProductInventory", con);

				DataSet ds = new DataSet();

				da.Fill(ds);

				GridView1.DataSource = ds;
				GridView1.DataBind();

			}
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlDataAdapter da = new SqlDataAdapter("spGetProductsByName", con);
				da.SelectCommand.CommandType = CommandType.StoredProcedure;
				da.SelectCommand.Parameters.AddWithValue("@ProductName", TextBox1.Text);

				DataSet ds = new DataSet();
				da.Fill(ds);

				GridView2.DataSource = ds;
				GridView2.DataBind();
			}
		}
	}
}