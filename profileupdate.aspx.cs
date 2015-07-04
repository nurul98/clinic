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
    public partial class profileupdate : System.Web.UI.Page
    {
        private SqlConnection userconnection, loginconnection, updateconnection;
        private SqlCommand usercommand, logincommand, updatecommand;
        private SqlDataReader userreader, loginreader;

        protected void Page_Load(object sender, EventArgs e)
        {
            userconnection = new SqlConnection();
            userconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf;Trusted_Connection=True;User Instance=True";
            usercommand = new SqlCommand();
            usercommand.Connection = userconnection;

            usercommand.CommandText = "SELECT * FROM patient WHERE pat_username=@pat_username";
            usercommand.Parameters.Clear();
            usercommand.Parameters.AddWithValue("@pat_username", User.Identity.Name);

            loginconnection = new SqlConnection();
            loginconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aspnetdb.mdf; Trusted_Connection=True;User Instance=True";
            logincommand = new SqlCommand();
            logincommand.Connection = loginconnection;

            logincommand.CommandText = "SELECT UserName FROM aspnet_Users WHERE UserName=@UserName";
            logincommand.Parameters.Clear();
            logincommand.Parameters.AddWithValue("@UserName", User.Identity.Name);

            updateconnection = new SqlConnection();
            updateconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\ccbs.mdf; Trusted_Connection=True;User Instance=True";
            updatecommand = new SqlCommand();
            updatecommand.Connection = updateconnection;

            if (!IsPostBack)
            {
                try
                {
                    loginconnection.Open();
                    loginreader = logincommand.ExecuteReader(CommandBehavior.SingleRow);

                    if (loginreader.Read())
                    {
                        try
                        {
                            userconnection.Open();
                            userreader = usercommand.ExecuteReader(CommandBehavior.SingleRow);

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

                                update.Enabled = true;
                                patient_ID.Enabled = false;
                                first_name.Enabled = false;
                                last_name.Enabled = false;
                                IC.Enabled = false;
                                passport.Enabled = false;
                                address.Enabled = true;
                                email.Enabled = true;
                                phone.Enabled = true;
                                age.Enabled = true;
                                gender.Enabled = false;
                            }
                            else
                                MessageBox.Show("Sorry, you are not authorized to use this system.");

                            userreader.Close();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Check user data error occured.");
                        }
                        finally
                        {
                            userconnection.Close();
                        }
                    }
                    else
                        MessageBox.Show("You need to log in");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Log in data check error");
                }
                finally
                {
                    loginconnection.Close();
                }
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

        protected void update_Click(object sender, EventArgs e)
        {
            updatecommand.CommandText = "UPDATE patient SET pat_ID=@pat_ID,pat_addr=@pat_addr,pat_email=@pat_email,pat_phone=@pat_phone,pat_age=@pat_age WHERE pat_ID=@pat_ID";

            updatecommand.Parameters.Clear();
            updatecommand.Parameters.AddWithValue("@pat_ID", patient_ID.Text);
            updatecommand.Parameters.AddWithValue("@pat_addr", address.Text);
            updatecommand.Parameters.AddWithValue("@pat_email", email.Text);
            updatecommand.Parameters.AddWithValue("@pat_phone", phone.Text);
            updatecommand.Parameters.AddWithValue("@pat_age", age.Text);

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
        }
    }
}