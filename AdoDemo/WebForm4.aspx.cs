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
	public partial class WebForm4 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = con;
				cmd.CommandText = "SELECT * FROM ProductInventory";

				con.Open();
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					DataTable dt = new DataTable();
					dt.Columns.Add("ID");
					dt.Columns.Add("Name");
					dt.Columns.Add("Price");
					dt.Columns.Add("Discounted Price");

					while (reader.Read())
					{
						DataRow dr = dt.NewRow();

						int OriginalPrice = Convert.ToInt32(reader["UnitPrice"]);
						double DiscountedPrice = OriginalPrice * 0.9;

						dr["ID"] = reader["Id"];
						dr["Name"] = reader["ProductName"];
						dr["Price"] = reader["UnitPrice"];
						dr["Discounted Price"] = DiscountedPrice;

						dt.Rows.Add(dr);
					}

					GridView1.DataSource = dt;
					GridView1.DataBind();
				}
			}

		}
	}
}