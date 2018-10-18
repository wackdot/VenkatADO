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
	public partial class WebForm15 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
	
		}

		private void bc_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
		{
			Lbl_ProgressStatus.Text = Lbl_ProgressStatus.Text + "<br/>" + e.RowsCopied + " loaded...";
		}

		protected void Btn_BulkTransfer_Click(object sender, EventArgs e)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

			using (SqlConnection sourceCon = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("SELECT * FROM Products_Source", sourceCon);
				sourceCon.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					using (SqlConnection destinationCon = new SqlConnection(connectionString))
					{
						using (SqlBulkCopy bc = new SqlBulkCopy(destinationCon))
						{
							bc.BatchSize = 10000;
							bc.NotifyAfter = 5000;
							bc.SqlRowsCopied += new SqlRowsCopiedEventHandler(bc_SqlRowsCopied);
							bc.DestinationTableName = "Products_Destination";
							destinationCon.Open();
							bc.WriteToServer(reader);
						}
					}
				}

			}
		}
	}
}