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

namespace clinic.doctor_access
{
    public partial class appointmentupdate : System.Web.UI.Page
    {
        private SqlConnection deleteconnection, updateconnection2, updateconnection3;
        private SqlCommand deletecommand, updatecommand2, updatecommand3;

        static string availability_ID, doctorname;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                onload();
            }
        }
        private void onload()
        {
            string strSQLconnection2 = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection2 = new SqlConnection(strSQLconnection2);
            SqlCommand sqlCommandDoctorId = new SqlCommand("SELECT dr_name AS name FROM doctor WHERE username='" + User.Identity.Name + "'", sqlConnection2);

            if (sqlConnection2.State.Equals(ConnectionState.Open))
                sqlConnection2.Close();

            if (sqlConnection2.State.Equals(ConnectionState.Closed))
                sqlConnection2.Open();

            var reader2 = sqlCommandDoctorId.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader2);
            DataRow tbrow = table.Rows[0];
            doctorname = tbrow["name"].ToString();

            string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM availability WHERE dr_name = '" + doctorname + "'ORDER BY appointment_date,appointment_time", sqlConnection);

            try
            {
                if (sqlConnection.State.Equals(ConnectionState.Open))
                    sqlConnection.Close();

                if (sqlConnection.State.Equals(ConnectionState.Closed))
                    sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                gridslot.DataSource = reader;
                gridslot.DataBind();

                if (sqlConnection.State.Equals(ConnectionState.Open))
                    sqlConnection.Close();

                if (sqlConnection.State.Equals(ConnectionState.Closed))
                    sqlConnection.Open();
            }
            catch (SqlException ex)
            {
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            txtAppointmentDate.Text = ((Label)gvrow.FindControl("txtappointmentdate")).Text;
            txtAppointmentTime.Text = ((Label)gvrow.FindControl("txtappointmenttime")).Text;
            drpDrName.Text = ((Label)gvrow.FindControl("txtdrname")).Text;

            availability_ID = gvrow.Cells[0].Text;
            //date = gvrow.Cells[0].Text;
            //time = gvrow.Cells[1].Text;
            //doctor_name = gvrow.Cells[2].Text;
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string strSQLconnection2 = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection2 = new SqlConnection(strSQLconnection2);

            SqlCommand sqlCommandread2 = new SqlCommand("SELECT * FROM appointment WHERE appointment_date=@appointment_date AND appointment_time=@appointment_time AND dr_name=@dr_name", sqlConnection2);
            sqlCommandread2.Parameters.Clear();
            sqlCommandread2.Parameters.AddWithValue("@appointment_date", txtAppointmentDate.Text);
            sqlCommandread2.Parameters.AddWithValue("@dr_name", drpDrName.Text);
            sqlCommandread2.Parameters.AddWithValue("@appointment_time", txtAppointmentTime.Text);

            if (sqlConnection2.State.Equals(ConnectionState.Open))
                sqlConnection2.Close();

            if (sqlConnection2.State.Equals(ConnectionState.Closed))
                sqlConnection2.Open();

            SqlDataReader reader2 = sqlCommandread2.ExecuteReader();

            updateconnection2 = new SqlConnection();
            updateconnection2.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            updatecommand2 = new SqlCommand();
            updatecommand2.Connection = updateconnection2;
            updatecommand2.CommandText = "UPDATE availability SET dr_name=@dr_name,appointment_date=@appointment_date,appointment_time=@appointment_time WHERE availability_ID=@availability_ID";

            updatecommand2.Parameters.Clear();
            updatecommand2.Parameters.AddWithValue("@dr_name", drpDrName.Text);
            updatecommand2.Parameters.AddWithValue("@appointment_date", txtAppointmentDate.Text);
            updatecommand2.Parameters.AddWithValue("@appointment_time", txtAppointmentTime.Text);
            //updatecommand2.Parameters.AddWithValue("@name", doctor_name);
            //updatecommand2.Parameters.AddWithValue("@date", date);
            //updatecommand2.Parameters.AddWithValue("@time", time);
            updatecommand2.Parameters.AddWithValue("@availability_ID", availability_ID);

            DateTime datepick = Convert.ToDateTime(txtAppointmentDate.Text);

            if (!reader2.Read())
            {
                try
                {
                    if (DateTime.Now > datepick || datepick > DateTime.Now.AddMonths(3))
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    else
                    {
                        try
                        {
                            updateconnection2.Open();
                            int change2 = updatecommand2.ExecuteNonQuery();
                            if (change2 > 0)
                            {
                                MessageBox.Show("Update was succesfully! ");
                                onload();
                            }
                            else
                                MessageBox.Show("Cannot Update record, try again later!");
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("An error occured. Update failed.");
                        }
                        finally
                        {
                            updateconnection2.Close();
                        }
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show("Booking date cannot be less than today or more than three months from today, Please Re-enter date");
                }
                finally
                {

                }
            }
            else
            {
                MessageBox.Show("The date and slot you try to assign has already being booked by patient");
            }
        }
        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails2 = sender as ImageButton;
            GridViewRow gvrow2 = (GridViewRow)btndetails2.NamingContainer;

            availability_ID = gvrow2.Cells[0].Text;
            DeleteDate.Text = ((Label)gvrow2.FindControl("txtappointmentdate")).Text;
            DeleteSlot.Text = ((Label)gvrow2.FindControl("txtappointmenttime")).Text;
            DeleteDr.Text = ((Label)gvrow2.FindControl("txtdrname")).Text;

            this.ModalPopupExtender2.Show();
        }
        protected void confirmdelete_Click(object sender, EventArgs e)
        {
            deleteconnection = new SqlConnection();
            deleteconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            deletecommand = new SqlCommand();
            deletecommand.Connection = deleteconnection;
            deletecommand.CommandText = "DELETE FROM availability WHERE availability_ID=@availability_ID";

            deletecommand.Parameters.Clear();
            deletecommand.Parameters.AddWithValue("@availability_ID", availability_ID);
            //deletecommand.Parameters.AddWithValue("@dr_name", doctor_name);
            //deletecommand.Parameters.AddWithValue("@appointment_date", date);
            //deletecommand.Parameters.AddWithValue("@appointment_time", time);

            try
            {
                deleteconnection.Open();
                int change3 = deletecommand.ExecuteNonQuery();
                if (change3 > 0)
                {
                    MessageBox.Show("Delete process Succesfully made!");
                    onload();
                }
                else
                {
                    MessageBox.Show("Cannot execute delete request try again later!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occured. Delete failed.");
            }
            finally
            {
                deleteconnection.Close();
            }
        }
        public static void ClearControls(Control Parent)
        {
            if (Parent is TextBox)
            {
                (Parent as TextBox).Text = string.Empty;
            }
            else
            {
                foreach (Control c in Parent.Controls)
                    ClearControls(c);
            }
        }
        public class MessageBox
        {
            private static System.Collections.Hashtable m_executingPages = new System.Collections.Hashtable();
            private MessageBox()
            {
            }
            public static void Show(string sMessage)
            {
                // If this is the first time a page has called this method then
                if (!m_executingPages.Contains(HttpContext.Current.Handler))
                {
                    // Attempt to cast HttpHandler as a Page.
                    Page executingPage = HttpContext.Current.Handler as Page;
                    if (executingPage != null)
                    {
                        // Create a Queue to hold one or more messages.
                        System.Collections.Queue messageQueue = new System.Collections.Queue();
                        // Add our message to the Queue
                        messageQueue.Enqueue(sMessage);
                        // Add our message queue to the hash table. Use our page reference
                        // (IHttpHandler) as the key.
                        m_executingPages.Add(HttpContext.Current.Handler, messageQueue);
                        // Wire up Unload event so that we can inject
                        // some JavaScript for the alerts.
                        executingPage.Unload += new EventHandler(ExecutingPage_Unload);
                    }
                }
                else
                {
                    // If were here then the method has allready been
                    // called from the executing Page.
                    // We have allready created a message queue and stored a
                    // reference to it in our hastable.
                    System.Collections.Queue queue = (System.Collections.Queue)m_executingPages[HttpContext.Current.Handler];
                    // Add our message to the Queue
                    queue.Enqueue(sMessage);
                }
            }
            // Our page has finished rendering so lets output the JavaScript to produce the alert's
            private static void ExecutingPage_Unload(object sender, EventArgs e)
            {
                // Get our message queue from the hashtable
                System.Collections.Queue queue = (System.Collections.Queue)m_executingPages[HttpContext.Current.Handler];
                if (queue != null)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    // How many messages have been registered?
                    int iMsgCount = queue.Count;
                    // Use StringBuilder to build up our client slide JavaScript.
                    sb.Append("<script language='javascript'>");
                    // Loop round registered messages
                    string sMsg;
                    while (iMsgCount-- > 0)
                    {
                        sMsg = (string)queue.Dequeue();
                        sMsg = sMsg.Replace("\n", "\\n");
                        sMsg = sMsg.Replace("\"", "'");
                        sb.Append(@"alert( """ + sMsg + @""" );");
                    }
                    // Close our JS
                    sb.Append(@"</script>");
                    // Were done, so remove our page reference from the hashtable
                    m_executingPages.Remove(HttpContext.Current.Handler);
                    // Write the JavaScript to the end of the response stream.
                    HttpContext.Current.Response.Write(sb.ToString());
                }
            }
        }
    }
}