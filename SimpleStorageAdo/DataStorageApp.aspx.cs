using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.Common;

namespace SimpleStorageAdo
{
    public partial class StorageApp : System.Web.UI.Page
    {
        string ConStr = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                string findNameButtonCmd = "select * from products where ProductName like @ProductName";
                SqlCommand sqlCommand = new SqlCommand(findNameButtonCmd, connection);
                sqlCommand.Parameters.AddWithValue("@ProductName", "%" + TextBox1.Text + "%");
                connection.Open();
                GridView2.DataSource = sqlCommand.ExecuteReader();
                GridView2.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                var text4 = TextBox4.Text.Trim();
                if (TextBox2.Text.Trim() == string.Empty || text4 == string.Empty)
                {
                    Page.Response.Redirect(Page.Request.Url.ToString(), false);
                }
                else if (TextBox2.Text.Trim().Length > 100 || TextBox3.Text.Trim().Length > 100 || text4.Length > 5)
                {
                    Page.Response.Redirect(Page.Request.Url.ToString(), false);
                }
                else if (!text4.All(char.IsDigit) || Convert.ToInt32(text4) > 32500)
                {
                    Page.Response.Redirect(Page.Request.Url.ToString(), false);
                }
                else if (TextBox3.Text.Trim() == string.Empty)
                {
                    SqlCommand sqlCommand2 = new SqlCommand("spAddItemDefault", connection);
                    sqlCommand2.CommandType = CommandType.StoredProcedure;
                    sqlCommand2.Parameters.AddWithValue("@Name", TextBox2.Text);
                    sqlCommand2.Parameters.AddWithValue("@Quantity", TextBox4.Text);
                    connection.Open();
                    sqlCommand2.ExecuteReader();
                }
                else
                {
                    SqlCommand sqlCommand1 = new SqlCommand("spAddItemWithUnit", connection);
                    sqlCommand1.CommandType = CommandType.StoredProcedure;
                    sqlCommand1.Parameters.AddWithValue("@Name", TextBox2.Text);
                    sqlCommand1.Parameters.AddWithValue("@Unit", TextBox3.Text);
                    sqlCommand1.Parameters.AddWithValue("@Quantity", TextBox4.Text);
                    connection.Open();
                    sqlCommand1.ExecuteReader();
                }
                Page.Response.Redirect(Page.Request.Url.ToString(), false);
            }
        }
    }
}

/*create table products (
 Id int identity(1,1) primary key,
 ProductName varchar(100) not null,
 ProductUnit varchar(30) default 'package',
 Quantity smallint not null
);*/
