using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.ComponentModel;

namespace clinic
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               onload();
            }
        }
        private void onload()
        {
            string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
            SqlCommand sqlCommandAdminDesignation = new SqlCommand("SELECT * FROM clinic_admin WHERE username='" + User.Identity.Name + "'", sqlConnection);
            SqlCommand sqlCommandDoctorDesignation = new SqlCommand("SELECT * FROM doctor WHERE username='" + User.Identity.Name + "'", sqlConnection);
                
            sqlConnection.Open();
                var reader = sqlCommandAdminDesignation.ExecuteReader();

                if (reader.Read())
                {
                    Response.Redirect("admin_access/homeadmin.aspx");
                }
            sqlConnection.Close();

            sqlConnection.Open();
            var reader2 = sqlCommandDoctorDesignation.ExecuteReader();

            if (reader2.Read())
            {
                Response.Redirect("doctor_access/homedoctor.aspx");
            }
            sqlConnection.Close();
        }
    }
}