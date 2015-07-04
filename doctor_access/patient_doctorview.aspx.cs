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
    public partial class patient_doctorview : System.Web.UI.Page
    {
        private SqlConnection userconnection;
        private SqlCommand usercommand;
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
                    Labelpatient_ID.Text = userreader["pat_ID"].ToString();
                    Labelfirst_name.Text = userreader["pat_firstname"].ToString();
                    Labellast_name.Text = userreader["pat_lastname"].ToString();
                    LabelIC.Text = userreader["pat_icno"].ToString();
                    Labelpassport.Text = userreader["pat_passport"].ToString();
                    Labeladdress.Text = userreader["pat_addr"].ToString();
                    Labelemail.Text = userreader["pat_email"].ToString();
                    Labelphone.Text = userreader["pat_phone"].ToString();
                    Labelage.Text = userreader["pat_age"].ToString();
                    Labelgender.Text = userreader["pat_gender"].ToString();
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
                Labelpatient_ID.Text = reader2["pat_ID"].ToString();
                Labelfirst_name.Text = reader2["pat_firstname"].ToString();
                Labellast_name.Text = reader2["pat_lastname"].ToString();
                LabelIC.Text = reader2["pat_icno"].ToString();
                Labelpassport.Text = reader2["pat_passport"].ToString();
                Labeladdress.Text = reader2["pat_addr"].ToString();
                Labelemail.Text = reader2["pat_email"].ToString();
                Labelphone.Text = reader2["pat_phone"].ToString();
                Labelage.Text = reader2["pat_age"].ToString();
                Labelgender.Text = reader2["pat_gender"].ToString();
            }
            else
            {
                MessageBox.Show("The Patient ID you entered cannot be found...");
            }
        }
    }
}