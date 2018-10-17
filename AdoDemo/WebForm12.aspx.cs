using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdoDemo
{
	public partial class WebForm12 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				StudentDataSetTableAdapters.StudentsTableAdapter sta = new StudentDataSetTableAdapters.StudentsTableAdapter();
				StudentDataSet.StudentsDataTable sdt = new StudentDataSet.StudentsDataTable();
				sta.Fill(sdt);

				Session["DATATABLE"] = sdt;


				Gvw_Display.DataSource = from student in sdt
										 select new
										 {
											 student.Id,
											 student.Name,
											 student.Gender,
											 student.TotalMarks
										 };
				Gvw_Display.DataBind();
			}
		}

		protected void Btn_Search_Click(object sender, EventArgs e)
		{
			StudentDataSet.StudentsDataTable sdt = (StudentDataSet.StudentsDataTable)Session["DATATABLE"];

			if (string.IsNullOrEmpty(Txt_Input.Text))
			{
				Gvw_Display.DataSource = from student in sdt
										 select new
										 {
											 student.Id,
											 student.Name,
											 student.Gender,
											 student.TotalMarks
										 };
				Gvw_Display.DataBind();
			}
			else
			{
				Gvw_Display.DataSource = from student in sdt
										 where student.Name.ToUpper().Contains(Txt_Input.Text.ToUpper())
										 select new
										 {
											 student.Id,
											 student.Name,
											 student.Gender,
											 student.TotalMarks
										 };
				Gvw_Display.DataBind();
			}
		}
	}
}