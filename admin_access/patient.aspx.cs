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

namespace clinic.admin_access
{
    public partial class patient : System.Web.UI.Page
    {
        private SqlConnection userconnection, updateconnection, deleteconnection, deleteconnection2;
        private SqlCommand usercommand, updatecommand, deletecommand, deletecommand2;
        private SqlDataReader userreader;

        static string patientid;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                onload();
            }
        }
        private void onload()
        {
            update.Enabled = false;

            string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM patient ORDER BY pat_ID", sqlConnection);

            try
            {
                if (sqlConnection.State.Equals(ConnectionState.Open))
                    sqlConnection.Close();

                if (sqlConnection.State.Equals(ConnectionState.Closed))
                    sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                gridpatient.DataSource = reader;
                gridpatient.DataBind();

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
        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            update.Enabled = true;
            patient_ID.Enabled = false;
            first_name.Enabled = true;
            last_name.Enabled = true;
            IC.Enabled = true;
            passport.Enabled = true;
            address.Enabled = true;
            email.Enabled = true;
            phone.Enabled = true;
            age.Enabled = true;
            gender.Enabled = true;

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            patientid = gvrow.Cells[0].Text;

            userconnection = new SqlConnection();
            userconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf;Trusted_Connection=True;User Instance=True";
            usercommand = new SqlCommand();
            usercommand.Connection = userconnection;

            usercommand.CommandText = "SELECT * FROM patient WHERE pat_ID=@pat_ID";
            usercommand.Parameters.Clear();
            usercommand.Parameters.AddWithValue("@pat_ID", patientid);

            try
            {
                userconnection.Open();
                userreader = usercommand.ExecuteReader();

                if (userreader.Read())
                {
                    patient_ID.Text = userreader["pat_ID"].ToString();
                    first_name.Text = userreader["pat_firstname"].ToString();
                    last_name.Text = userreader["pat_lastname"].ToString();
                    IC.Text = userreader["pat_icno"].ToString();
                    passport.Text = userreader["pat_passport"].ToString();
                    address.Text = userreader["pat_addr"].ToString();
                    email.Text = userreader["pat_email"].ToString();
                    phone.Text = userreader["pat_phone"].ToString();
                    age.Text = userreader["pat_age"].ToString();
                    gender.Text = userreader["pat_gender"].ToString();
                }
                else
                {
                    MessageBox.Show("Patient data cannot be read.");
                }
            }
            catch (SqlException ex)
            {
            }
            finally
            {
                userconnection.Close();
            }
        }
        protected void update_Click(object sender, EventArgs e)
        {
            updateconnection = new SqlConnection();
            updateconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            updatecommand = new SqlCommand();
            updatecommand.Connection = updateconnection;
            
            updatecommand.CommandText = "UPDATE patient SET pat_ID=@pat_ID,pat_firstname=@pat_firstname,pat_lastname=@pat_lastname,pat_icno=@pat_icno,pat_addr=@pat_addr,pat_email=@pat_email,pat_phone=@pat_phone,pat_age=@pat_age,pat_gender=@pat_gender,pat_passport=@pat_passport WHERE pat_ID=@pat_ID";

            updatecommand.Parameters.Clear();
            updatecommand.Parameters.AddWithValue("@pat_ID", patient_ID.Text);
            updatecommand.Parameters.AddWithValue("@pat_firstname", first_name.Text);
            updatecommand.Parameters.AddWithValue("@pat_lastname", last_name.Text);
            updatecommand.Parameters.AddWithValue("@pat_icno", IC.Text);
            updatecommand.Parameters.AddWithValue("@pat_addr", address.Text);
            updatecommand.Parameters.AddWithValue("@pat_email", email.Text);
            updatecommand.Parameters.AddWithValue("@pat_phone", phone.Text);
            updatecommand.Parameters.AddWithValue("@pat_age", age.Text);
            updatecommand.Parameters.AddWithValue("@pat_gender", gender.Text);
            updatecommand.Parameters.AddWithValue("@pat_passport", passport.Text);

            try
            {
                updateconnection.Open();
                int change = updatecommand.ExecuteNonQuery();
                if (change > 0)
                {
                    MessageBox.Show("Profile update successful!");
                }
                else
                    MessageBox.Show("Profile update failed! Please try later.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occured. Profile update failed.");
            }
            finally
            {
                updateconnection.Close();
            }
            update.Enabled = false;
            patient_ID.Enabled = false;
            first_name.Enabled = false;
            last_name.Enabled = false;
            IC.Enabled = false;
            passport.Enabled = false;
            address.Enabled = false;
            email.Enabled = false;
            phone.Enabled = false;
            age.Enabled = false;
            gender.Enabled = false;

            onload();
        }
        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            patientid = gvrow.Cells[0].Text;
            DeletePatient.Text = patientid; 
            this.ModalPopupExtender2.Show();  
        }
        protected void confirmdelete_Click(object sender, EventArgs e)
        {
            deleteconnection = new SqlConnection();
            deleteconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            deletecommand = new SqlCommand();
            deletecommand.Connection = deleteconnection;
            deletecommand.CommandText = "DELETE FROM patient WHERE pat_ID=@pat_ID";

            deletecommand.Parameters.Clear();
            deletecommand.Parameters.AddWithValue("@pat_ID", patientid);

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

            string strSQLconnection2 = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection2 = new SqlConnection(strSQLconnection2);
            SqlCommand sqlCommand2 = new SqlCommand("SELECT pat_ID FROM appointment WHERE pat_ID=@pat_ID", sqlConnection2);
            sqlCommand2.Parameters.Clear();
            sqlCommand2.Parameters.AddWithValue("@pat_ID", patientid);

            if (sqlConnection2.State.Equals(ConnectionState.Open))
                sqlConnection2.Close();

            if (sqlConnection2.State.Equals(ConnectionState.Closed))
                sqlConnection2.Open();

            SqlDataReader reader2 = sqlCommand2.ExecuteReader();

            if (reader2.Read())
            {
                deleteconnection2 = new SqlConnection();
                deleteconnection2.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
                deletecommand2 = new SqlCommand();
                deletecommand2.Connection = deleteconnection2;
                deletecommand2.CommandText = "DELETE FROM appointment WHERE pat_ID=@pat_ID";

                deletecommand2.Parameters.Clear();
                deletecommand2.Parameters.AddWithValue("@pat_ID", patientid);

                try
                {
                    deleteconnection2.Open();
                    int change = deletecommand2.ExecuteNonQuery();
                    if (change > 0)
                    {
                        MessageBox.Show("Change to appointment table succesfully made!");
                        onload();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occured to delete patient from appointment table. Update failed.");
                }
                finally
                {
                    deleteconnection2.Close();
                }
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            string strSQLconnectionstatus = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnectionstatus = new SqlConnection(strSQLconnectionstatus);

            SqlCommand sqlCommandreadstatus = new SqlCommand("SELECT * FROM patient WHERE pat_ID=@pat_ID", sqlConnectionstatus);
            sqlCommandreadstatus.Parameters.Clear();
            sqlCommandreadstatus.Parameters.AddWithValue("@pat_ID", txtSearch.Text);
            
            if (sqlConnectionstatus.State.Equals(ConnectionState.Open))
                sqlConnectionstatus.Close();

            if (sqlConnectionstatus.State.Equals(ConnectionState.Closed))
                sqlConnectionstatus.Open();

            SqlDataReader reader2 = sqlCommandreadstatus.ExecuteReader();

            if (reader2.Read())
            {
                patient_ID.Text = reader2["pat_ID"].ToString();
                first_name.Text = reader2["pat_firstname"].ToString();
                last_name.Text = reader2["pat_lastname"].ToString();
                IC.Text = reader2["pat_icno"].ToString();
                passport.Text = reader2["pat_passport"].ToString();
                address.Text = reader2["pat_addr"].ToString();
                email.Text = reader2["pat_email"].ToString();
                phone.Text = reader2["pat_phone"].ToString();
                age.Text = reader2["pat_age"].ToString();
                gender.Text = reader2["pat_gender"].ToString();
                update.Enabled = true;
            }
            else
            {
                MessageBox.Show("The Patient ID you entered cannot be found...");
            }
        }
    }
}