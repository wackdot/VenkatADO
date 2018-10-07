using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AdoDemo
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=True;");
			SqlCommand cmd = new SqlCommand("SELECT * FROM Product", con);
			con.Open();
			SqlDataReader rdr = cmd.ExecuteReader();

			GridView1.DataSource = rdr;
			GridView1.DataBind();

			con.Close();
		}

	}
}