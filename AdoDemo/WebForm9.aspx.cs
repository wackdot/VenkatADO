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
	public partial class WebForm9 : System.Web.UI.Page
	{
		string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Btn_LoadStudentID_Click(object sender, EventArgs e)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				string sqlQuery = "SELECT * FROM Students WHERE Id = " + Txt_StudentID.Text;
				SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
				DataSet ds = new DataSet();
				da.Fill(ds, "Students");

				ViewState["SQL_QUERY"] = sqlQuery;
				ViewState["DATASET"] = ds;

				if (ds.Tables["Students"].Rows.Count > 0)
				{
					DataRow dr = ds.Tables["Students"].Rows[0];
					Txt_StudentName.Text = dr["Name"].ToString();
					Ddl_Gender.SelectedValue = dr["Gender"].ToString();
					Txt_TotalMarks.Text = dr["TotalMarks"].ToString();

					Lbl_Message.ForeColor = System.Drawing.Color.Green;
					Lbl_Message.Text = "1 record retrieved!";
				}
				else
				{
					Lbl_Message.ForeColor = System.Drawing.Color.Red;
					Lbl_Message.Text = "No Student record with ID = " + Txt_StudentID.Text;
				}

			}
		}

		protected void Btn_Update_Click(object sender, EventArgs e)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlDataAdapter da = new SqlDataAdapter((string)ViewState["SQL_QUERY"], con);

				SqlCommandBuilder builder = new SqlCommandBuilder(da);

				DataSet ds = (DataSet)ViewState["DATASET"];

				// Targets the first row of the data set before updating it
				if (ds.Tables["Students"].Rows.Count > 0)
				{
					DataRow dr = ds.Tables["Students"].Rows[0];
					dr["Name"] = Txt_StudentName.Text;
					dr["Gender"] = Ddl_Gender.SelectedValue;
					dr["TotalMarks"] = Txt_TotalMarks.Text;
				}

				int rowsUpdated = da.Update(ds, "Students");

				if (rowsUpdated > 0)
				{
					Lbl_Message.ForeColor = System.Drawing.Color.Green;
					Lbl_Message.Text = rowsUpdated.ToString() + " row(s) updates";
				}
				else
				{
					Lbl_Message.ForeColor = System.Drawing.Color.Red;
					Lbl_Message.Text = "No rows updated";
				}

			}
		}
	}
}