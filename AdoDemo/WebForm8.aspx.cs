using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AdoDemo
{
	public partial class WebForm8 : System.Web.UI.Page
	{
		string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void BtnLoadData_Click(object sender, EventArgs e)
		{
			if (Cache["Data"] == null)
			{
				using (SqlConnection con = new SqlConnection(connectionString))
				{
					SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ProductInventory", con);
					DataSet ds = new DataSet();
					da.Fill(ds);

					Cache["Data"] = ds;

					Gvw_Products.DataSource = ds;
					Gvw_Products.DataBind();
				}
				LblMessage.Text = "Data loaded from Database";
			}
			else
			{
				Gvw_Products.DataSource = (DataSet)Cache["Data"];
				Gvw_Products.DataBind();

				LblMessage.Text = "Data loaded from Cache";
			}
		}

		protected void BtnClearCache_Click(object sender, EventArgs e)
		{
			if (Cache["Data"] != null)
			{
				Cache.Remove("Data");
				LblMessage.Text = "The DataSet is removed from the cache";
			}
			else
			{
				LblMessage.Text = "The cache is empty";
			}
		}
	}
}