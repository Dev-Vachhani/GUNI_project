using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P12
{
    public partial class admin : System.Web.UI.Page
    {
        SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\Sem 4\\ADT(Application Development Tools)\\Codes\\P12 & P13\\App_Data\\p12.mdf\";Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            sc.Open();
            SqlDataAdapter adb= new SqlDataAdapter();
            DataTable dt = new DataTable();
            adb=new SqlDataAdapter("select * from Data where Username='" + Session["username"]  +"' and Password='" + Session["password"] +"'",sc);
            adb.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            sc.Close();
        }
    }
}