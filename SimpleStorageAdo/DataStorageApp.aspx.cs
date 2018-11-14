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
            //string ConStr = "data source=.; database = project2; integrated security=SSPI";

            //using (SqlConnection connection = new SqlConnection(ConStr))
            //{
            //    SqlCommand sqlCommand = new SqlCommand("Select * from products", connection);
            //    //SqlDataReader dataReader = sqlCommand.ExecuteReader();
            //    connection.Open();
            //    GridView1.DataSource = sqlCommand.ExecuteReader();
            //    GridView1.DataBind();
            //    //ovoa na posebna strana(gore), kako lista od site. Drugoto na posebna
            //}
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
                //SqlCommand sqlCommand = new SqlCommand("spAddProduct", connection);
                //sqlCommand.CommandType = CommandType.StoredProcedure;
                string addItemwithunit = "insert into products ( ProductName, ProductUnit, Quantity ) values ( @ProductName, @ProductUnit, @Quantity )";
                string addItemDefault = "insert into products( ProductName, Quantity ) values ( @ProductName, @Quantity )";
                var text4 = TextBox4.Text.Trim();
                if (TextBox2.Text.Trim() == string.Empty || text4 == string.Empty)//TextBox2.Text == null || TextBox2.Text == "" || TextBox4.Text == null || TextBox4.Text == ""
                {
                    //MessageBox.Show("empty not allowed");
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
                else if (TextBox3.Text.Trim() == string.Empty/*TextBox3.Text.Trim() == null || TextBox3.Text,Trim() == ""*/)
                {
                    SqlCommand sqlCommand2 = new SqlCommand(addItemDefault, connection);
                    sqlCommand2.Parameters.AddWithValue("@ProductName", TextBox2.Text);
                    sqlCommand2.Parameters.AddWithValue("@Quantity", TextBox4.Text);
                    connection.Open();
                    sqlCommand2.ExecuteReader();
                }
                else
                {
                    SqlCommand sqlCommand1 = new SqlCommand(addItemwithunit, connection);
                    sqlCommand1.Parameters.AddWithValue("@ProductName", TextBox2.Text);
                    sqlCommand1.Parameters.AddWithValue("@ProductUnit", TextBox3.Text);
                    sqlCommand1.Parameters.AddWithValue("@Quantity", TextBox4.Text);
                    connection.Open();
                    sqlCommand1.ExecuteReader();
                }
                Page.Response.Redirect(Page.Request.Url.ToString(), false);
            }
        }
    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    string ConStr = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

    //    using (SqlConnection connection = new SqlConnection(ConStr))
    //    {
    //        string findNameButtonCmd = "select * from products where ProductName like @ProductName";
    //        SqlCommand sqlCommand = new SqlCommand(findNameButtonCmd, connection);
    //        sqlCommand.Parameters.AddWithValue("@ProductName", TextBox1.Text);
    //        connection.Open();
    //        GridView2.DataSource = sqlCommand.ExecuteReader();
    //        GridView2.DataBind();
    //    }
    //}
}

/*create table products (
 Id int identity(1,1) primary key,
 ProductName varchar(100) not null,
 ProductUnit varchar(30) default 'package',
 Quantity smallint not null
);*/
