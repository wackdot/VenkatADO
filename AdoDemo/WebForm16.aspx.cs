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
	public partial class WebForm16 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				GetData();
			}
		}

		protected void Btn_Transfer_Click(object sender, EventArgs e)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				SqlTransaction transaction = con.BeginTransaction();

				try
				{				
					SqlCommand cmd = new SqlCommand("UPDATE Accounts SET Balance = Balance - 10 WHERE AccountNumber = 'A1'", con, transaction);										
					cmd.ExecuteNonQuery();

					cmd = new SqlCommand("UPDATE Accounts SET Balance = Balance + 10 WHERE AccountNumber = 'A2'", con, transaction);
					cmd.ExecuteNonQuery();

					transaction.Commit();

					Lbl_Message.Text = "Transaction Successful!";
					Lbl_Message.ForeColor = System.Drawing.Color.Green;					
				}
				catch
				{
					transaction.Rollback();
					Lbl_Message.Text = "Transaction Failed!";
					Lbl_Message.ForeColor = System.Drawing.Color.Red;
				}
				finally
				{
					GetData();
				}
			}
		}

		private void GetData()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("SELECT * FROM Accounts", con);
				con.Open();

				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					if (reader["AccountNumber"].ToString() == "A1")
					{
						Lbl_AccountNo1.Text = reader["AccountNumber"].ToString();
						Lbl_CustName1.Text = reader["CustomerName"].ToString();
						Lbl_Balance1.Text = reader["Balance"].ToString();
					}
					else if (reader["AccountNumber"].ToString() == "A2")
					{
						Lbl_AccountNo2.Text = reader["AccountNumber"].ToString();
						Lbl_CustName2.Text = reader["CustomerName"].ToString();
						Lbl_Balance2.Text = reader["Balance"].ToString();						
					}
				}
			}
		}

	}
}