using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AdoDemo
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			// MS SQL Connection
			//string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=True; MultipleActiveResultSets=True";
			//SqlConnection con = new SqlConnection(connectionString);
			//SqlCommand cmd = new SqlCommand("SELECT * FROM Product", con);
			//con.Open();
			//SqlDataReader rdr = cmd.ExecuteReader();

			//GridView1.DataSource = rdr;
			//GridView1.DataBind();

			//con.Close();

			// Approach: Try Catch Block
			//string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=True; MultipleActiveResultSets=True";

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
			//con.Close();

			// Approach: Using
			//string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=True; MultipleActiveResultSets=True";

			//using (SqlConnection con = new SqlConnection(connectionString))
			//{
			//	SqlCommand cmd = new SqlCommand("SELECT * FROM Product", con);
			//	con.Open();
			//	GridView1.DataSource = cmd.ExecuteReader();
			//	GridView1.DataBind();
			//}
			

		}
	}
}