using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdoDemo
{
	public partial class WebForm2 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		// SQL Injection Example
		//protected void Btn_GetProducts_Click(object sender, EventArgs e)
		//{
		//	Using Web.config file to centralise all DB connection string configurations
		//	string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

		//	using (SqlConnection con = new SqlConnection(connectionString))
		//	{
		//		SqlCommand cmd = new SqlCommand();
		//		cmd.Connection = con;
		//		cmd.CommandText = "SELECT * FROM ProductInventory WHERE ProductName LIKE '" + Tbx_InputProducts.Text + "%'";
		//		con.Open();

		//		Gvw_DisplayProducts.DataSource = cmd.ExecuteReader();
		//		Gvw_DisplayProducts.DataBind();
		//	}
		//}

		// Preventing SQL Injection via Parameterised Query
		//protected void Btn_GetProducts_Click(object sender, EventArgs e)
		//{
		//	// Using Web.config file to centralise all DB connection string configurations
		//	string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

		//	using (SqlConnection con = new SqlConnection(connectionString))
		//	{
		//		SqlCommand cmd = new SqlCommand();
		//		cmd.Connection = con;
		//		cmd.CommandText = "SELECT * FROM ProductInventory WHERE ProductName LIKE @ProductName";
		//		cmd.Parameters.AddWithValue("ProductName", Tbx_InputProducts.Text + "%");
		//		con.Open();

		//		Gvw_DisplayProducts.DataSource = cmd.ExecuteReader();
		//		Gvw_DisplayProducts.DataBind();
		//	}
		//}

		// Preventing SQL Injection via Stored Procedure
		//protected void Btn_GetProducts_Click(object sender, EventArgs e)
		//{
		//	// Using Web.config file to centralise all DB connection string configurations
		//	string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

		//	using (SqlConnection con = new SqlConnection(connectionString))
		//	{
		//		SqlCommand cmd = new SqlCommand();
		//		cmd.Connection = con;
		//		cmd.CommandText = "spGetProductsByName";
		//		cmd.CommandType = System.Data.CommandType.StoredProcedure;
		//		cmd.Parameters.AddWithValue("@ProductName", Tbx_InputProducts.Text + "%");
		//		con.Open();

		//		Gvw_DisplayProducts.DataSource = cmd.ExecuteReader();
		//		Gvw_DisplayProducts.DataBind();
		//	}
		//}
	}

}