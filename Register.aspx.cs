using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Services;
using System.Web.Services.Description;
using System.Web.UI;

namespace P12
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode=UnobtrusiveValidationMode.None;
        }

        protected void reg_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\Sem 4\\ADT(Application Development Tools)\\Codes\\P12 & P13\\App_Data\\p12.mdf\";Integrated Security=True");
            sc.Open();
            string gender;
            
            if (password.Text == cpassword.Text)
            {
                if (male.Checked == true)
                {
                    gender = male.Text;
                }
                else
                {
                    gender = female.Text;
                }
                string q = "insert into Data values('" + enroll.Text + "','" + name.Text + "','" + address.Text + "','" + mobile.Text + "','" + semester.SelectedItem.ToString() + "','" + branch.SelectedItem.ToString() + "','" + gender.ToString() + "','" + dob.Text + "','" + userid.Text + "','" + password.Text + "')";
                SqlCommand cmd = new SqlCommand(q, sc);
                try
                {
                    cmd.ExecuteNonQuery();
                    Response.Write("Registered");
                    sc.Close();
                }
                catch(SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        Response.Write("Data with this Enrollment Number already exists");
                    }
                }
                
            }
            else
            {
                Response.Write("Password and Confirm Password not same");
            }
            
        }
    }
}