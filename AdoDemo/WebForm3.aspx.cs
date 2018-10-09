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
	public partial class WebForm3 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Btn_AddEmployee_Click(object sender, EventArgs e)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = con;
				cmd.CommandText = "spAddEmployee";
				cmd.CommandType = System.Data.CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@Name", Txt_EmployeeName.Text);
				cmd.Parameters.AddWithValue("@Gender", Ddl_Gender.SelectedValue);
				cmd.Parameters.AddWithValue("@Salary", Txt_Salary.Text);

				SqlParameter outputParameter = new SqlParameter();
				outputParameter.ParameterName = "@EmployeeId";
				outputParameter.SqlDbType = System.Data.SqlDbType.Int;
				outputParameter.Direction = System.Data.ParameterDirection.Output;

				cmd.Parameters.Add(outputParameter);

				con.Open();
				cmd.ExecuteNonQuery();

				string EmpId = outputParameter.Value.ToString();

				Lbl_Message.Text = "Employee Id = " + EmpId;
			}
		}
	}
}