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
	public partial class WebForm5 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandText = "SELECT * FROM ProductInventory; SELECT* FROM ProductCategories";
				cmd.Connection = con;

				con.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					Gvw_Products.DataSource = reader;
					Gvw_Products.DataBind();

					while (reader.NextResult())
					{
						Gvw_ProductCategories.DataSource = reader;
						Gvw_ProductCategories.DataBind();
					}
				}

			}
		}
	}
}