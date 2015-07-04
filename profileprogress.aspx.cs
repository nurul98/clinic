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
    public partial class profileprogress : System.Web.UI.Page
    {
        private SqlConnection updateconnection, deleteconnection;
        private SqlCommand updatecommand, deletecommand;

        static string pati_ID, appointment_id, appoint_ID;

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
            SqlCommand sqlCommandPatientId = new SqlCommand("SELECT pat_ID AS id FROM patient WHERE pat_username='" + User.Identity.Name + "'", sqlConnection);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM appointment WHERE username='" + User.Identity.Name + "' ORDER BY appointment_date,appointment_time,dr_name", sqlConnection);

            try
            {
                if (sqlConnection.State.Equals(ConnectionState.Open))
                    sqlConnection.Close();
                
                if (sqlConnection.State.Equals(ConnectionState.Closed))
                    sqlConnection.Open();

                var reader = sqlCommandPatientId.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                DataRow tbrow = table.Rows[0];
                pati_ID = tbrow["id"].ToString();

                if (sqlConnection.State.Equals(ConnectionState.Open))
                    sqlConnection.Close();

                if (sqlConnection.State.Equals(ConnectionState.Closed))
                    sqlConnection.Open();

                SqlDataReader reader2 = sqlCommand.ExecuteReader();
                
                appointment.DataSource = reader2;
                appointment.DataBind();
                
                if (sqlConnection.State.Equals(ConnectionState.Open))
                    sqlConnection.Close();

                if (sqlConnection.State.Equals(ConnectionState.Closed))
                    sqlConnection.Open();

                SqlCommand sqlCommandProfile = new SqlCommand("SELECT pat_ID,pat_firstname,pat_lastname,pat_icno,pat_passport,pat_addr,pat_email,pat_phone,pat_age,pat_gender FROM patient WHERE (pat_ID = '" + pati_ID + "')", sqlConnection);
                var reader1 = sqlCommandProfile.ExecuteReader();

                DataTable table1 = new DataTable();
                table1.Load(reader1);
                DataRow tbrow1 = table1.Rows[0];

                patient_ID.Text = tbrow1["pat_ID"].ToString();
                first_name.Text = tbrow1["pat_firstname"].ToString();
                last_name.Text = tbrow1["pat_lastname"].ToString();
                IC.Text = tbrow1["pat_icno"].ToString();
                passport.Text = tbrow1["pat_passport"].ToString();
                address.Text = tbrow1["pat_addr"].ToString();
                phone.Text = tbrow1["pat_phone"].ToString();
                email.Text = tbrow1["pat_email"].ToString();
                age.Text = tbrow1["pat_age"].ToString();
                gender.Text = tbrow1["pat_gender"].ToString();
            }
            catch (SqlException ex)
            {
            }
            finally
            {
                sqlConnection.Close();
            }
            string strSQLconnection2 = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection2 = new SqlConnection(strSQLconnection2);
            SqlCommand sqlCommand2 = new SqlCommand("SELECT * FROM availability ORDER BY appointment_date,appointment_time,dr_name", sqlConnection2);

            try
            {
                if (sqlConnection2.State.Equals(ConnectionState.Open))
                    sqlConnection2.Close();

                if (sqlConnection2.State.Equals(ConnectionState.Closed))
                    sqlConnection2.Open();

                SqlDataReader reader2 = sqlCommand2.ExecuteReader();

                gridslot.DataSource = reader2;
                gridslot.DataBind();

                if (sqlConnection2.State.Equals(ConnectionState.Open))
                    sqlConnection2.Close();

                if (sqlConnection2.State.Equals(ConnectionState.Closed))
                    sqlConnection2.Open();
            }
            catch (SqlException ex)
            {
            }
            finally
            {
                sqlConnection2.Close();
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
        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtAppointmentDate.Text = ((Label)gvrow.FindControl("txtappointmentdate")).Text;
            txtAppointmentTime.Text = ((Label)gvrow.FindControl("txtappointmenttime")).Text;
            txtMediNotes.Text = ((Label)gvrow.FindControl("medinotes")).Text;
            drpDrName.Text = ((Label)gvrow.FindControl("txtdrname")).Text;
            appointment_id = gvrow.Cells[0].Text;
          
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection = new SqlConnection(strSQLconnection);

            SqlCommand sqlCommandread = new SqlCommand("SELECT * FROM availability WHERE appointment_date=@appointment_date AND appointment_time=@appointment_time AND dr_name=@dr_name", sqlConnection);
            sqlCommandread.Parameters.Clear();
            sqlCommandread.Parameters.AddWithValue("@appointment_date", txtAppointmentDate.Text);
            sqlCommandread.Parameters.AddWithValue("@dr_name", drpDrName.Text);
            sqlCommandread.Parameters.AddWithValue("@appointment_time", txtAppointmentTime.Text);
           
            if (sqlConnection.State.Equals(ConnectionState.Open))
                sqlConnection.Close();

            if (sqlConnection.State.Equals(ConnectionState.Closed))
                sqlConnection.Open();

            SqlDataReader reader = sqlCommandread.ExecuteReader();
            
            updateconnection = new SqlConnection();
            updateconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            updatecommand = new SqlCommand();
            updatecommand.Connection = updateconnection;
            updatecommand.CommandText = "UPDATE appointment SET appointment_ID=@appointment_ID,dr_name=@dr_name,appointment_date=@appointment_date,appointment_time=@appointment_time,medi_note=@medi_note,approval_status=@approval_status WHERE appointment_ID=@appointment_ID";

            updatecommand.Parameters.Clear();
            updatecommand.Parameters.AddWithValue("@appointment_ID", appointment_id);
            updatecommand.Parameters.AddWithValue("@dr_name", drpDrName.Text);
            updatecommand.Parameters.AddWithValue("@appointment_date", txtAppointmentDate.Text);
            updatecommand.Parameters.AddWithValue("@appointment_time", txtAppointmentTime.Text);
            updatecommand.Parameters.AddWithValue("@medi_note", txtMediNotes.Text);
            updatecommand.Parameters.AddWithValue("@approval_status", "Pending");

            DateTime datepick = Convert.ToDateTime(txtAppointmentDate.Text);

            string strSQLconnectionstatus = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnectionstatus = new SqlConnection(strSQLconnectionstatus);

            SqlCommand sqlCommandreadstatus = new SqlCommand("SELECT approval_status FROM appointment WHERE appointment_ID=@appointment_ID AND approval_status=@approval_status", sqlConnectionstatus);
            sqlCommandreadstatus.Parameters.Clear();
            sqlCommandreadstatus.Parameters.AddWithValue("@approval_status", "Pending");
            sqlCommandreadstatus.Parameters.AddWithValue("@appointment_ID", appointment_id);
           
            if (sqlConnectionstatus.State.Equals(ConnectionState.Open))
                sqlConnectionstatus.Close();

            if (sqlConnectionstatus.State.Equals(ConnectionState.Closed))
                sqlConnectionstatus.Open();

            SqlDataReader reader2 = sqlCommandreadstatus.ExecuteReader();

            if (reader2.Read())
            {
                if (reader.Read())
                {
                    try
                    {
                        updateconnection.Open();
                        int change = updatecommand.ExecuteNonQuery();
                        if (change > 0)
                        {
                            MessageBox.Show("Update was succesfully! ");
                            deletefromavail();
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
                        updateconnection.Close();
                     }
                }
                else
                {
                    MessageBox.Show("The date and slot you try to book is not available");
                    sqlConnection.Close();
                }
            }
            else
            {
                MessageBox.Show("Sorry, your appointment has already been approved or rejected. You cannot do any changes...");
                sqlConnectionstatus.Close(); 
            }
        }
        protected void btnUpdateNotes_Click(object sender, EventArgs e)
        {
            updateconnection = new SqlConnection();
            updateconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            updatecommand = new SqlCommand();
            updatecommand.Connection = updateconnection;
            updatecommand.CommandText = "UPDATE appointment SET appointment_ID=@appointment_ID,medi_note=@medi_note WHERE appointment_ID=@appointment_ID";

            updatecommand.Parameters.Clear();
            updatecommand.Parameters.AddWithValue("@appointment_ID", appointment_id);
            updatecommand.Parameters.AddWithValue("@medi_note", txtMediNotes.Text);

            string strSQLconnectionstatus = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnectionstatus = new SqlConnection(strSQLconnectionstatus);

            SqlCommand sqlCommandreadstatus = new SqlCommand("SELECT approval_status FROM appointment WHERE appointment_ID=@appointment_ID AND approval_status=@approval_status", sqlConnectionstatus);
            sqlCommandreadstatus.Parameters.Clear();
            sqlCommandreadstatus.Parameters.AddWithValue("@approval_status", "Rejected");
            sqlCommandreadstatus.Parameters.AddWithValue("@appointment_ID", appointment_id);

            if (sqlConnectionstatus.State.Equals(ConnectionState.Open))
                sqlConnectionstatus.Close();

            if (sqlConnectionstatus.State.Equals(ConnectionState.Closed))
                sqlConnectionstatus.Open();

            SqlDataReader reader2 = sqlCommandreadstatus.ExecuteReader();

            if (!reader2.Read())
            {
                try
                {
                    updateconnection.Open();
                    int change = updatecommand.ExecuteNonQuery();
                    if (change > 0)
                    {
                        MessageBox.Show("Medi Notes Update was succesful! ");
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
                    updateconnection.Close();
                }
            }
            else
            {
                MessageBox.Show("Sorry, your appointments have been rejected. You cannot make any updates.");
            }
        }
        private void deletefromavail()
        {
            deleteconnection = new SqlConnection();
            deleteconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            deletecommand = new SqlCommand();
            deletecommand.Connection = deleteconnection;
            deletecommand.CommandText = "DELETE FROM availability WHERE appointment_date=@appointment_date AND appointment_time=@appointment_time AND dr_name=@dr_name ";

            deletecommand.Parameters.Clear();
            deletecommand.Parameters.AddWithValue("@dr_name", drpDrName.Text);
            deletecommand.Parameters.AddWithValue("@appointment_date", txtAppointmentDate.Text);
            deletecommand.Parameters.AddWithValue("@appointment_time", txtAppointmentTime.Text);

            try
            {
                deleteconnection.Open();
                int change = deletecommand.ExecuteNonQuery();
                if (change > 0)
                {
                    MessageBox.Show("Change Succesfully made to availability list!");
                    onload();
                }
                else
                    MessageBox.Show("Cannot execute delete request try again later!");
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
        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            DeleteDate.Text = ((Label)gvrow.FindControl("txtappointmentdate")).Text;
            DeleteTime.Text = ((Label)gvrow.FindControl("txtappointmenttime")).Text;
            DeleteNotes.Text = ((Label)gvrow.FindControl("medinotes")).Text;
            DeleteDr.Text = ((Label)gvrow.FindControl("txtdrname")).Text;
            appoint_ID = gvrow.Cells[0].Text;
            this.ModalPopupExtender2.Show();
        }
        protected void confirmdelete_Click(object sender, EventArgs e)
        {
            deleteconnection = new SqlConnection();
            deleteconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            deletecommand = new SqlCommand();
            deletecommand.Connection = deleteconnection;
            deletecommand.CommandText = "DELETE FROM appointment WHERE appointment_ID=@appointment_ID ";

            deletecommand.Parameters.Clear();
            deletecommand.Parameters.AddWithValue("@appointment_ID", appoint_ID);

            try
            {
                deleteconnection.Open();
                int change = deletecommand.ExecuteNonQuery();
                if (change > 0)
                {
                    MessageBox.Show("Change Succesfully made!");
                    onload();
                }
                else
                    MessageBox.Show("Cannot execute delete request try again later!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occured. Update failed.");
            }
            finally
            {
                deleteconnection.Close();
            }
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            if (String.Compare(DropDownSearch.Text.ToString(), "Date") == 0)
            {
                string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
                SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM availability ORDER BY appointment_date,appointment_time,dr_name", sqlConnection);

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
            if (String.Compare(DropDownSearch.Text.ToString(), "Slot") == 0)
            {
                string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
                SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM availability ORDER BY appointment_time,appointment_date,dr_name", sqlConnection);

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
            if (String.Compare(DropDownSearch.Text.ToString(), "Doctor") == 0)
            {
                string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
                SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM availability ORDER BY dr_name,appointment_date,appointment_time", sqlConnection);

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
        }
        protected void Schedule_Click(object sender, EventArgs e)
        {
            string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM availability WHERE dr_name=@dr_name ORDER BY dr_name,appointment_date,appointment_time", sqlConnection);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@dr_name", DropDownSchedule.Text);
            
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
    }
}