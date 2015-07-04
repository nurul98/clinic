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
    public partial class doctorlist : System.Web.UI.Page
    {
        private SqlConnection userconnection, updateconnection, deleteconnection, deleteconnection2, deleteconnection3;
        private SqlCommand usercommand, updatecommand, deletecommand, deletecommand2, deletecommand3;
        private SqlDataReader userreader;

        static string doctorid,doctor_name;

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
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM doctor ORDER BY dr_ID", sqlConnection);

            try
            {
                if (sqlConnection.State.Equals(ConnectionState.Open))
                    sqlConnection.Close();

                if (sqlConnection.State.Equals(ConnectionState.Closed))
                    sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                griddoctor.DataSource = reader;
                griddoctor.DataBind();

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
            doctor_ID.Enabled = false;
            name.Enabled = true;
            speciality.Enabled = true;
           
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            doctorid = gvrow.Cells[0].Text;

            userconnection = new SqlConnection();
            userconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf;Trusted_Connection=True;User Instance=True";
            usercommand = new SqlCommand();
            usercommand.Connection = userconnection;

            usercommand.CommandText = "SELECT * FROM doctor WHERE dr_ID=@dr_ID";
            usercommand.Parameters.Clear();
            usercommand.Parameters.AddWithValue("@dr_ID", doctorid);

            try
            {
                userconnection.Open();
                userreader = usercommand.ExecuteReader();

                if (userreader.Read())
                {
                    doctor_ID.Text = userreader["dr_ID"].ToString();
                    name.Text = userreader["dr_name"].ToString();
                    speciality.Text = userreader["dr_speciality"].ToString();
                }
                else
                {
                    MessageBox.Show("Doctor data cannot be read.");
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

            updatecommand.CommandText = "UPDATE doctor SET dr_ID=@dr_ID,dr_name=@dr_name,dr_speciality=@dr_speciality WHERE dr_ID=@dr_ID";

            updatecommand.Parameters.Clear();
            updatecommand.Parameters.AddWithValue("@dr_ID", doctor_ID.Text);
            updatecommand.Parameters.AddWithValue("@dr_name", name.Text);
            updatecommand.Parameters.AddWithValue("@dr_speciality", speciality.Text);
            
            try
            {
                updateconnection.Open();
                int change = updatecommand.ExecuteNonQuery();
                if (change > 0)
                {
                    MessageBox.Show("Doctor update successful!");
                }
                else
                    MessageBox.Show("Doctor update failed! Please try later.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occured. Doctor update failed.");
            }
            finally
            {
                updateconnection.Close();
            }
            update.Enabled = false;
            doctor_ID.Enabled = false;
            name.Enabled = false;
            speciality.Enabled = false;

            onload();
        }
        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            doctorid = gvrow.Cells[0].Text;
            doctor_name = ((Label)gvrow.FindControl("txtname")).Text;
            DeleteDoctor.Text = doctorid;
            this.ModalPopupExtender2.Show();
        }
        protected void confirmdelete_Click(object sender, EventArgs e)
        { 
            deleteconnection = new SqlConnection();
            deleteconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            deletecommand = new SqlCommand();
            deletecommand.Connection = deleteconnection;
            deletecommand.CommandText = "DELETE FROM doctor WHERE dr_ID=@dr_ID";

            deletecommand.Parameters.Clear();
            deletecommand.Parameters.AddWithValue("@dr_ID", doctorid);

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
            SqlCommand sqlCommand2 = new SqlCommand("SELECT dr_name FROM appointment WHERE dr_name=@dr_name", sqlConnection2);
            sqlCommand2.Parameters.Clear();
            sqlCommand2.Parameters.AddWithValue("@dr_name", doctor_name);

            if (sqlConnection2.State.Equals(ConnectionState.Open))
                sqlConnection2.Close();

            if (sqlConnection2.State.Equals(ConnectionState.Closed))
                sqlConnection2.Open();

            SqlDataReader reader2 = sqlCommand2.ExecuteReader();
            
            deleteconnection2 = new SqlConnection();
            deleteconnection2.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            deletecommand2 = new SqlCommand();
            deletecommand2.Connection = deleteconnection2;
            deletecommand2.CommandText = "DELETE FROM appointment WHERE dr_name=@dr_name";

            deletecommand2.Parameters.Clear();
            deletecommand2.Parameters.AddWithValue("@dr_name", doctor_name);

            if (reader2.Read())
            {
                try
                {
                    deleteconnection2.Open();
                    int change = deletecommand2.ExecuteNonQuery();
                    if (change > 0)
                    {
                        MessageBox.Show("Change To appointment table succesfully made!");
                        onload();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occured to delete from appointment. Update failed.");
                }
                finally
                {
                    deleteconnection2.Close();
                }
            }

            string strSQLconnection3 = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection3 = new SqlConnection(strSQLconnection3);
            SqlCommand sqlCommand3 = new SqlCommand("SELECT dr_name FROM availability WHERE dr_name=@dr_name", sqlConnection3);
            sqlCommand3.Parameters.Clear();
            sqlCommand3.Parameters.AddWithValue("@dr_name", doctor_name);

            if (sqlConnection3.State.Equals(ConnectionState.Open))
                sqlConnection3.Close();

            if (sqlConnection3.State.Equals(ConnectionState.Closed))
                sqlConnection3.Open();

            SqlDataReader reader3 = sqlCommand3.ExecuteReader();
            
            deleteconnection3 = new SqlConnection();
            deleteconnection3.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            deletecommand3 = new SqlCommand();
            deletecommand3.Connection = deleteconnection3;
            deletecommand3.CommandText = "DELETE FROM availability WHERE dr_name=@dr_name";

            deletecommand3.Parameters.Clear();
            deletecommand3.Parameters.AddWithValue("@dr_name", doctor_name);

            if (reader3.Read())
            {
                try
                {
                    deleteconnection3.Open();
                    int change = deletecommand3.ExecuteNonQuery();
                    if (change > 0)
                    {
                        MessageBox.Show("Change To availability table succesfully made!");
                        onload();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occured to delete from availability. Update failed.");
                }
                finally
                {
                    deleteconnection3.Close();
                }
            }
        }
        protected void register_doctor_Click(object sender, EventArgs e)
        {
            Response.Redirect("addnewdoctor.aspx");
        }
    }
}