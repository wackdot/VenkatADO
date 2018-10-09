using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace AdoDemo
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// Using Web.config file to centralise all DB connection string configurations
			string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

			// Basic: MS SQL Connection
			//SqlConnection con = new SqlConnection(connectionString);
			//SqlCommand cmd = new SqlCommand("SELECT * FROM Product", con);
			//con.Open();
			//SqlDataReader rdr = cmd.ExecuteReader();

			//GridView1.DataSource = rdr;
			//GridView1.DataBind();

			//con.Close();

			// Basic + Error Handling with Try Catch Block
			//SqlConnection con = new SqlConnection(connectionString);
			//try
			//{
			//	SqlCommand cmd = new SqlCommand("SELECT * FROM Product", con);
			//	con.Open();
			//	GridView1.DataSource = cmd.ExecuteReader();
			//	GridView1.DataBind();
			//}
			//catch
			//{
			//	// Exception handling
			//}
			//finally
			//{
			//	con.Close();
			//}

			// ExecuteReader + Basic + Closing Connection with Using statement
			//using (SqlConnection con = new SqlConnection(connectionString))
			//{
			//	SqlCommand cmd = new SqlCommand("SELECT * FROM Product", con);
			//	con.Open();

			//	// Storing data seperately
			//	// SqlDataReader data = cmd.ExecuteReader();

			//	// Direct data binding
			//	GridView1.DataSource = cmd.ExecuteReader();
			//	GridView1.DataBind();
			//}

			//  ExecuteScalar + Basic + Closing Connection with Using statement
			//using (SqlConnection con = new SqlConnection(connectionString))
			//{
			//	SqlCommand cmd = new SqlCommand("SELECT COUNT(ProductId) FROM Product", con);
			//	con.Open();
			//	int TotalRows = (int)cmd.ExecuteScalar();
			//	Response.Write("Total Rows = " + TotalRows.ToString());
			//}


			//  ExecuteNonQuery - Insert Statement + Basic + Closing Connection with Using statement
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = con;
				con.Open();

				// Insert SQL
				cmd.CommandText = "INSERT INTO Product VALUES(4, 'Calculators', 100, 230)";

				int TotalRows = (int)cmd.ExecuteNonQuery();
				Response.Write("Total Rows Inserted = " + TotalRows.ToString() + "<br/>");

				// Delete SQL
				cmd.CommandText = "DELETE FROM Product WHERE ProductId = 4";

				TotalRows = cmd.ExecuteNonQuery();
				Response.Write("Total Rows Deleted = " + TotalRows.ToString() + "<br/>");
			
				// Update SQL 
				cmd.CommandText = "UPDATE Product SET QtyAvailable = 200 WHERE ProductId = 2";

				TotalRows = cmd.ExecuteNonQuery();
				Response.Write("Total Rows Updated = " + TotalRows.ToString() + "<br/>");
			}

		}
	}
}