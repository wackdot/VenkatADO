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
	public partial class WebForm7 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlDataAdapter da = new SqlDataAdapter("spGetProductAndCategories", con);
				da.SelectCommand.CommandType = CommandType.StoredProcedure;

				DataSet ds = new DataSet();
				da.Fill(ds);

				ds.Tables[0].TableName = "Products";
				ds.Tables[1].TableName = "Product Categories";

				GridView1.DataSource = ds.Tables["Products"];
				GridView1.DataBind();

				GridView2.DataSource = ds.Tables["Products Categories"];
				GridView2.DataBind();
			}
		}
	}
}