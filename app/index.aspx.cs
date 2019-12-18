using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.Page;

namespace WebApplication_dotNet.app
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CONNECT TO DB

            string connStr = "Server=localhost;Database=test;UID=sa;PWD=admin12345678";
            //string connStr = "Server=mssql-2017-mssqldemo.cpat-cpak4mcm-cluster-afb9c6047b062b44e3f1b3ecfeba4309-0002.us-south.containers.appdomain.cloud;Database=test;UID=sa;PWD=admin12345678";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            //CREATE A COMMAND
            SqlCommand cmd = new SqlCommand("SELECT [id],[name] FROM [dbo].[test_tab]");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            string temp = "";
            //READ FROM DB
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                temp += reader["id"].ToString();
                temp += reader["name"].ToString();
                temp += "<br/>";

            }
            conn.Close();
            lbl_test.Text = temp;

        }
    }
}
