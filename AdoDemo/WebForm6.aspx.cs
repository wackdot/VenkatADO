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
	public partial class WebForm6 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{

			}
	}
}