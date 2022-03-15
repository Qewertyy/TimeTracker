using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace EmpTimeTracking
{
    public partial class ForgetPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnreset_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Str"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "forgetpwd";
            cmd.Parameters.AddWithValue("@Email", txtemail.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() != "NE")
                {
                    try
                    {
                        string RandomPwd = GeneratePassword(6);
                        cmd = new SqlCommand("update Emp0 set Password='" + RandomPwd + "' where Email='" + txtemail.Text + "'", con);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i == 1)
                        {
                            forgetpass(dt.Rows[0][0].ToString(), RandomPwd);
                            txtemail.Text = string.Empty;
                            ScriptManager.RegisterStartupScript(this.Page, GetType(), "alert", "alert('Password Sent Succesfully')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, GetType(), "alert", "alert('Erorr ! Try Again Later')", true);
                        }

                       
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, GetType(), "alert", "alert('Employee Does Not Exist 🙁')", true);
                    return;
                }
            }
        }
        protected void forgetpass(string UserName, string RandomPwd)
        {

            string EmailBody = string.Empty;
            EmailBody = PopulateBody("ForgetPassword.html");
            EmailBody = EmailBody.Replace("{#Name}", UserName);
            EmailBody = EmailBody.Replace("{#Password}", RandomPwd);
            sendpwd("Employee Login Credentials", true, EmailBody, txtemail.Text.Trim());

        }

        public void sendpwd(string Subj, bool allowHTML, string strBody, string EmailTo)
        {
            try
            {
                string strfromEmailID = ConfigurationManager.AppSettings["FromEmail"].ToString();
                string port = ConfigurationManager.AppSettings["Port"].ToString();
                string strMailServer = ConfigurationManager.AppSettings["HostName"].ToString();
                string pwd = ConfigurationManager.AppSettings["Pwd"].ToString();
                string MailNotSent = string.Empty;
                string str = string.Empty;
                SmtpClient emailClient = new SmtpClient();
                MailMessage message = new MailMessage(strfromEmailID, EmailTo);
                message.IsBodyHtml = allowHTML;
                message.Subject = Subj;
                message.Body = strBody;
                emailClient.Port = Convert.ToInt32(port);
                NetworkCredential NC = new NetworkCredential();
                NC.UserName = strfromEmailID;
                NC.Password = pwd;
                emailClient.UseDefaultCredentials = false;
                emailClient.EnableSsl = true;
                emailClient.Credentials = NC;
                emailClient.Host = strMailServer;
                emailClient.Send(message);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public string GeneratePassword(int Passlength)
        {
            int i = 0;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (i < Passlength)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
                i++;
            }
            return res.ToString();
        }
        public string PopulateBody(String EmailTemplates)
        {
            string body = string.Empty;
            string path = AppDomain.CurrentDomain.BaseDirectory;
            using (StreamReader reader = new StreamReader(string.Format("{0}EmailTemplate\\{1}", path, EmailTemplates)))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }
    }
}