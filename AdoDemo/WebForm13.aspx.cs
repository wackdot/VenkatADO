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
	public partial class WebForm13 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		
		}

		protected void Btn_LoadXMLData_Click(object sender, EventArgs e)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				DataSet ds = new DataSet();
				ds.ReadXml(Server.MapPath("~/Data.xml"));

				DataTable dtDept = ds.Tables["Department"];

				con.Open();

				using (SqlBulkCopy bc = new SqlBulkCopy(con))
				{
					bc.DestinationTableName = "Department";
					bc.ColumnMappings.Add("Id", "Id");
					bc.ColumnMappings.Add("Name", "Name");
					bc.ColumnMappings.Add("Location", "Location");
					bc.WriteToServer(dtDept);
				}
			}
		}
	}
}