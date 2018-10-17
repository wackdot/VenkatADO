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
	public partial class WebForm14 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Btn_Transfer_Click(object sender, EventArgs e)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
			string connectionStringDest = ConfigurationManager.ConnectionStrings["DBCS-Dest"].ConnectionString;

			using (SqlConnection sourceCon = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("SELECT * FROM Department", sourceCon);
				sourceCon.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					using (SqlConnection destinationCon = new SqlConnection(connectionStringDest))
					{
						using (SqlBulkCopy bc = new SqlBulkCopy(destinationCon))
						{
							bc.DestinationTableName = "Department";
							//bc.ColumnMappings.Add("Id", "Id");
							//bc.ColumnMappings.Add("Name", "Name");
							//bc.ColumnMappings.Add("Location", "Location");
							destinationCon.Open();
							bc.WriteToServer(reader);
						}
					}
				}
			}
		}
	}
}