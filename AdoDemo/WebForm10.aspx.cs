using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace AdoDemo
{
	public partial class WebForm10 : System.Web.UI.Page
	{


		protected void Page_Load(object sender, EventArgs e)
		{

		}

		private void GetDataFromDb()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
			SqlConnection con = new SqlConnection(connectionString);
			string strSelectQuery = "SELECT * FROM Students";
			SqlDataAdapter da = new SqlDataAdapter(strSelectQuery, connectionString);

			DataSet ds = new DataSet();
			da.Fill(ds, "Students");

			ds.Tables["Students"].PrimaryKey = new DataColumn[] { ds.Tables["Students"].Columns["Id"] };
			Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);

			Gvw_Students.DataSource = ds;
			Gvw_Students.DataBind();

			Lbl_Message.Text = "Data Loaded from Database";
		}

		private void GetDataFromCache()
		{
			if (Cache["DATASET"] != null)
			{
				DataSet ds = (DataSet)Cache["DATASET"];
				Gvw_Students.DataSource = ds;
				Gvw_Students.DataBind();
			}
		}

		protected void Btn_GetData_Click(object sender, EventArgs e)
		{
			GetDataFromDb();
		}

		protected void Gvw_Students_RowEditing(object sender, GridViewEditEventArgs e)
		{
			Gvw_Students.EditIndex = e.NewEditIndex;
			GetDataFromCache();
		}

		protected void Gvw_Students_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			if (Cache["DATASET"] != null)
			{
				DataSet ds = (DataSet)Cache["DATASET"];
				DataRow dr = ds.Tables["Students"].Rows.Find(e.Keys["Id"]);

				dr["Name"] = e.NewValues["Name"];
				dr["Gender"] = e.NewValues["Gender"];
				dr["TotalMarks"] = e.NewValues["TotalMarks"];

				Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
				Gvw_Students.EditIndex = -1;
				GetDataFromCache();
			}
		}

		protected void Gvw_Students_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			Gvw_Students.EditIndex = -1;
			GetDataFromCache();
		}

		protected void Gvw_Students_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			if (Cache["DATASET"] != null)
			{
				DataSet ds = (DataSet)Cache["DATASET"];
				DataRow dr = ds.Tables["Students"].Rows.Find(e.Keys["Id"]);

				dr.Delete();

				Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
				GetDataFromCache();
			}
		}

		protected void Btn_UpdateDatabase_Click(object sender, EventArgs e)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
			SqlConnection con = new SqlConnection(connectionString);
			string strSelectQuery = "SELECT * FROM Students";
			SqlDataAdapter da = new SqlDataAdapter(strSelectQuery, connectionString);

			DataSet ds = (DataSet)Cache["DATASET"];

			string strUpdateCommand = "UPDATE Students SET Name = @Name, Gender = @Gender, TotalMarks = @TotalMarks WHERE Id = @Id";
			SqlCommand updateCommand = new SqlCommand(strUpdateCommand, con);
			updateCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
			updateCommand.Parameters.Add("@Name", SqlDbType.VarChar, 255, "Name");
			updateCommand.Parameters.Add("@Gender", SqlDbType.VarChar, 255, "Gender");
			updateCommand.Parameters.Add("@TotalMarks", SqlDbType.Int, 0, "TotalMarks");

			da.UpdateCommand = updateCommand;

			string strDeleteCommand = "DELETE FROM Students WHERE Id = @Id";
			SqlCommand deleteCommand = new SqlCommand(strDeleteCommand, con);
			deleteCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");

			da.DeleteCommand = deleteCommand;

			da.Update(ds, "Students");

			Lbl_Message.Text = "Database Table Updated";
		}

		protected void Btn_DisplayRowState_Click(object sender, EventArgs e)
		{
			DataSet ds = (DataSet)Cache["DATASET"];
			DataRow newDataRow = ds.Tables["Students"].NewRow();
			newDataRow["Id"] = 101;
			// ds.Tables["Students"].Rows.Add(newDataRow);

			foreach (DataRow dr in ds.Tables["Students"].Rows)
			{
				if (dr.RowState == DataRowState.Deleted)
				{
					Response.Write(dr["Id", DataRowVersion.Original].ToString() + " - " + dr.RowState.ToString() + "<br/>");
				}
				else
				{
					Response.Write(dr["Id"].ToString() + " - " + dr.RowState.ToString() + "<br/>");
				}		
			}
			Response.Write(newDataRow.RowState.ToString());
 		}

		protected void Btn_UndoRowState_Click(object sender, EventArgs e)
		{
			DataSet ds = (DataSet)Cache["DATASET"];

			if (ds.HasChanges())
			{
				ds.RejectChanges();
				Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
				GetDataFromCache();

				Lbl_Message.Text = "Changes Undone";
				Lbl_Message.ForeColor = System.Drawing.Color.Green;
			}
			else
			{
				Lbl_Message.Text = "No changes to Undo";
				Lbl_Message.ForeColor = System.Drawing.Color.Red;
			}

		}

		protected void Btn_AcceptRowStateChanges_Click(object sender, EventArgs e)
		{
			DataSet ds = (DataSet)Cache["DATASET"];

			if (ds.HasChanges())
			{
				ds.AcceptChanges();
				Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
				GetDataFromCache();

				Lbl_Message.Text = "Changes Accepted";
				Lbl_Message.ForeColor = System.Drawing.Color.Green;
			}
			else
			{
				Lbl_Message.Text = "No changes made";
				Lbl_Message.ForeColor = System.Drawing.Color.Red;
			}
		}
	}
}