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
	public partial class WebForm11 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
				SqlConnection con = new SqlConnection(connectionString);
				string selectQuery = "SELECT * FROM Students";
				SqlDataAdapter da = new SqlDataAdapter(selectQuery, con);

				DataSet dataSet = new DataSet();
				da.Fill(dataSet, "Students");
				Session["DATASET"] = dataSet;

				Gvw_Display.DataSource = from dataRow in dataSet.Tables["Students"].AsEnumerable()
										 select new Student {
											 Id = Convert.ToInt32(dataRow["Id"]),
											 Name = dataRow["Name"].ToString(),
											 Gender = dataRow["Gender"].ToString(),
											 TotalMarks = Convert.ToInt32(dataRow["TotalMarks"])
										 };
				Gvw_Display.DataBind();
			}
		}

		protected void Btn_Search_Click(object sender, EventArgs e)
		{
			DataSet dataSet = (DataSet)Session["DATASET"];

			if (string.IsNullOrEmpty(Txt_Input.Text))
			{
				Gvw_Display.DataSource = from dataRow in dataSet.Tables["Students"].AsEnumerable()
										 select new Student
										 {
											 Id = Convert.ToInt32(dataRow["Id"]),
											 Name = dataRow["Name"].ToString(),
											 Gender = dataRow["Gender"].ToString(),
											 TotalMarks = Convert.ToInt32(dataRow["TotalMarks"])
										 };
				Gvw_Display.DataBind();
			}
			else
			{
				Gvw_Display.DataSource = from dataRow in dataSet.Tables["Students"].AsEnumerable()
										 where dataRow["Name"].ToString().ToUpper().Contains(Txt_Input.Text.ToUpper())
										 select new Student
										 {
											 Id = Convert.ToInt32(dataRow["Id"]),
											 Name = dataRow["Name"].ToString(),
											 Gender = dataRow["Gender"].ToString(),
											 TotalMarks = Convert.ToInt32(dataRow["TotalMarks"])
										 };
				Gvw_Display.DataBind();
			}
		}
	}
}