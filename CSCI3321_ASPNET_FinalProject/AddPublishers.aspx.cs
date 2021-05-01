using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace CSCI3321_ASPNET_FinalProject
{
    public partial class AddPublishers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddPublisher_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;


            //Insert values into publishers (Publisher Name, Address, City, Postal Code, Country, Phone Number)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = String.Format("INSERT INTO Publishers VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                txtPublisherName.Text,
                txtAddress.Text,
                txtCity.Text,
                txtPostalCode.Text,
                txtCountry.Text,
                txtPhoneNumber.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}