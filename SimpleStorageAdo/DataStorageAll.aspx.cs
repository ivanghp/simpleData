using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleStorageAdo
{
    public partial class DataStorageAll : System.Web.UI.Page
    {
        string ConStr = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                SqlCommand sqlCommand = new SqlCommand("Select * from products", connection);
                connection.Open();
                GridView1.DataSource = sqlCommand.ExecuteReader();
                GridView1.DataBind();
            }
        }
    }
}