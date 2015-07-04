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
    public partial class booking : System.Web.UI.Page
    {
        private SqlConnection updateconnection,deleteconnection;
        private SqlCommand updatecommand,deletecommand;

        static string pati_ID;

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
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM availability ORDER BY appointment_date", sqlConnection);

            try
            {
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
            }
            catch (SqlException ex)
            {
            }
            finally
            {
                sqlConnection.Close();
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
        public int Count_Row()
        {
            Random rand = new Random();

            System.Data.SqlClient.SqlConnection conn3 = new System.Data.SqlClient.SqlConnection(GetConnectionString());
            string sql = "SELECT COUNT(*) FROM appointment AS no";
            conn3.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, conn3);
            return Convert.ToInt32(cmd.ExecuteScalar()) + (rand.Next(1, 100));
        }
        public string GetConnectionString()
        {
            //sets the connection string from your web config file "Patient_Table_Connection" is the name of your Connection String
            return System.Configuration.ConfigurationManager.ConnectionStrings["Table_Connection"].ConnectionString;
        }
        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtDate.Text = ((Label)gvrow.FindControl("txtappointmentdate")).Text;
            txtTime.Text = ((Label)gvrow.FindControl("txtappointmenttime")).Text;
            txtDrName.Text = ((Label)gvrow.FindControl("txtdrname")).Text;
            
            this.ModalPopupExtender1.Show();
        }
        protected void btnBook_Click(object sender, EventArgs e)
        {
            updateconnection = new SqlConnection();
            updateconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            updatecommand = new SqlCommand();
            updatecommand.Connection = updateconnection;
            updatecommand.CommandText = "INSERT INTO appointment (appointment_ID, pat_ID, username, dr_name, appointment_date, appointment_time, medi_note, approval_status) VALUES "

                        + " (@appointment_ID, @pat_ID, @username, @dr_name, @appointment_date, @appointment_time, @medi_note, @approval_status)";

            updatecommand.Parameters.Clear();
            updatecommand.Parameters.AddWithValue("@appointment_ID", "MA" + Count_Row());
            updatecommand.Parameters.AddWithValue("@pat_ID", pati_ID);
            updatecommand.Parameters.AddWithValue("@username", User.Identity.Name);
            updatecommand.Parameters.AddWithValue("@dr_name", txtDrName.Text);
            updatecommand.Parameters.AddWithValue("@appointment_date", txtDate.Text);
            updatecommand.Parameters.AddWithValue("@appointment_time", txtTime.Text);
            updatecommand.Parameters.AddWithValue("@medi_note", txtMedicalNotes.Text);
            updatecommand.Parameters.AddWithValue("@approval_status", "Pending");

                    try
                    {
                        updateconnection.Open();
                        int change = updatecommand.ExecuteNonQuery();
                        if (change > 0)
                        {
                            MessageBox.Show("Booking process succesful! ");
                            deletefromavail();
                            onload();
                        }
                        else
                            MessageBox.Show("Cannot make booking, try again later!");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("An error occured. Booking failed.");
                    }
                    finally
                    {
                        updateconnection.Close();
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
            deletecommand.Parameters.AddWithValue("@dr_name", txtDrName.Text);
            deletecommand.Parameters.AddWithValue("@appointment_date", txtDate.Text);
            deletecommand.Parameters.AddWithValue("@appointment_time", txtTime.Text);

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

                    appointment.DataSource = reader;
                    appointment.DataBind();

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

                    appointment.DataSource = reader;
                    appointment.DataBind();

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

                    appointment.DataSource = reader;
                    appointment.DataBind();

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

                appointment.DataSource = reader;
                appointment.DataBind();

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