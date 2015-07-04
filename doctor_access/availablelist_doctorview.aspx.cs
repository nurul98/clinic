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
    public partial class availablelist_doctorview : System.Web.UI.Page
    {
        private SqlConnection deleteconnection, updateconnection2, updateconnection3;
        private SqlCommand deletecommand, updatecommand2, updatecommand3;

        static string availability_ID,doctorname;

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
        public int Count_Row()
        {
            Random rand = new Random();

            System.Data.SqlClient.SqlConnection conn3 = new System.Data.SqlClient.SqlConnection(GetConnectionString());
            string sql = "SELECT COUNT(*) FROM availability AS no";
            conn3.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, conn3);
            return Convert.ToInt32(cmd.ExecuteScalar()) + (rand.Next(1, 100));
        }
        public string GetConnectionString()
        {
            //sets the connection string from your web config file "Patient_Table_Connection" is the name of your Connection String
            return System.Configuration.ConfigurationManager.ConnectionStrings["Table_Connection"].ConnectionString;
        }
        protected void assign_Click(object sender, EventArgs e)
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
            
            updateconnection3 = new SqlConnection();
            updateconnection3.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            updatecommand3 = new SqlCommand();
            updatecommand3.Connection = updateconnection3;

            string strSQLconnection3 = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection3 = new SqlConnection(strSQLconnection3);

            SqlCommand sqlCommandread3 = new SqlCommand("SELECT * FROM availability WHERE appointment_date=@appointment_date AND appointment_time=@appointment_time AND dr_name=@dr_name", sqlConnection3);
            sqlCommandread3.Parameters.Clear();
            sqlCommandread3.Parameters.AddWithValue("@appointment_date", txtDate.Text);
            sqlCommandread3.Parameters.AddWithValue("@dr_name", doctorname);
            sqlCommandread3.Parameters.AddWithValue("@appointment_time", txtTime.Text);

            if (sqlConnection3.State.Equals(ConnectionState.Open))
                sqlConnection3.Close();

            if (sqlConnection3.State.Equals(ConnectionState.Closed))
                sqlConnection3.Open();

            SqlDataReader reader3 = sqlCommandread3.ExecuteReader();

            updatecommand3.CommandText = "INSERT INTO availability (availability_ID,appointment_date, appointment_time, dr_name) VALUES "

                        + " (@availability_ID,@appointment_date, @appointment_time, @dr_name)";

            updatecommand3.Parameters.Clear();

            updatecommand3.Parameters.AddWithValue("@availability_ID", "AV" + Count_Row());
            updatecommand3.Parameters.AddWithValue("@dr_name", doctorname);
            updatecommand3.Parameters.AddWithValue("@appointment_date", txtDate.Text);
            updatecommand3.Parameters.AddWithValue("@appointment_time", txtTime.Text);

            DateTime datepick = Convert.ToDateTime(txtDate.Text);

            if (!reader3.Read())
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
                            updateconnection3.Open();
                            int change = updatecommand3.ExecuteNonQuery();
                            if (change > 0)
                            {
                                MessageBox.Show("Slot assigned succesfully! ");
                                onload();
                            }
                            else
                                MessageBox.Show("Cannot assign slot, try again later!");
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("An error occured. Slot assigned failed.");
                        }
                        finally
                        {
                            updateconnection3.Close();
                        }
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show("Assign date cannot be less than today or more than three months from today, Please Re-enter date");
                }
                finally
                {

                }
            }
            else
            {
                MessageBox.Show("The slot you pick already in the list");
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
        protected void change_click(object sender, EventArgs e)
        {
            Response.Redirect("appointmentupdate.aspx");
        }
    }
}