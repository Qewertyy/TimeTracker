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
    public partial class EmpMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Newtry();
            

        }

        public void Newtry()

        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Str"].ToString());
            SqlCommand cmd = new SqlCommand("select EmpID,EmpName,Empsall,EmpDOJ,EmpDOR,Email,Role from Emp0", con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gridview1.DataSource = dt;
                gridview1.DataBind();
            }

        }



        protected void gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "RowDelete")
                {
                    int empid = Convert.ToInt32(e.CommandArgument);
                    DataTable dt = new DataTable();
                    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Str"].ToString());
                    SqlCommand cmd = new SqlCommand("delete from emp0 where empid='" + empid + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Newtry();
                    ScriptManager.RegisterStartupScript(this.Page, GetType(), "alert", "alert('Employee Deleted Succesfully')", true);
                }
                if (e.CommandName == "RowEdit")
                {
                    int empid = Convert.ToInt32(e.CommandArgument);
                    DataTable dt = new DataTable();
                    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Str"].ToString());
                    SqlCommand cmd = new SqlCommand("select EmpID,EmpName,Empsall,EmpDOJ,EmpDOR,Email,Role from Emp0 where empid='" + empid + "'", con);
                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        tb1.Text = dt.Rows[0]["EmpName"].ToString();
                        tb2.Text = dt.Rows[0]["EmpSall"].ToString();
                        tb3.Text = dt.Rows[0]["EmpDOJ"].ToString();
                        tb4.Text = dt.Rows[0]["EmpDOR"].ToString();
                        tb5.Text = dt.Rows[0]["Email"].ToString();
                        tb6.Text = dt.Rows[0]["Role"].ToString();
                        hdd.Value = empid.ToString();
                    }
                    btnsave.Text = "Update";
                    Newtry();
                    sa.Visible = false;
                    sas.Visible = true;
                }

            }
            catch (Exception exe)
            {

                throw exe;
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

        protected void btnback_Click(object sender, EventArgs e)
        {
            sa.Visible = true;
            sas.Visible = false;
            tb1.Text = string.Empty;
            tb2.Text = string.Empty;
            tb3.Text = string.Empty;
            tb4.Text = string.Empty;
            tb5.Text = string.Empty;
            tb6.Text = string.Empty;
            Newtry();
        }

        protected void ADD_Click(object sender, EventArgs e)
        {
            sa.Visible = false;
            sas.Visible = true;
            btnsave.Text = "Save";
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                string RandomPwd = GeneratePassword(6);
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Str"].ToString());
                SqlCommand cmd = new SqlCommand("insert into emp0 values('" + tb1.Text + "','" + tb2.Text + "','" + tb3.Text + "','" + tb4.Text + "','" + tb5.Text + "','" + tb6.Text + "','"+ RandomPwd + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                createuser(RandomPwd);
                tb1.Text = string.Empty;
                tb2.Text = string.Empty;
                tb3.Text = string.Empty;
                tb4.Text = string.Empty;
                tb5.Text = string.Empty;
                tb6.Text = string.Empty;
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "alert", "alert('Employee Added Succesfully')", true);
            }

            else if (btnsave.Text == "Update")
            {
                int empid = Convert.ToInt32(hdd.Value);
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Str"].ToString());
              SqlCommand cmd = new SqlCommand("update emp0 set EmpName='" + tb1.Text + "',Empsall='" + tb2.Text + "',EmpDOj='" + tb3.Text + "',EmpDOR='" + tb4.Text + "',Email='" + tb5.Text + "',Role='" + tb6.Text + "' where empid='" + empid + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                tb1.Text = string.Empty;
                tb2.Text = string.Empty;
                tb3.Text = string.Empty;
                tb4.Text = string.Empty;
                tb5.Text = string.Empty;
                tb6.Text = string.Empty;
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "alert", "alert('Employee Updated Succesfully')", true);
            }
        }
    protected void createuser(string RandomPwd)
    {
            string EmailBody = string.Empty;
            EmailBody = PopulateBody("CreateUser.html");
            EmailBody = EmailBody.Replace("{#LoginID}", tb5.Text.Trim());
            EmailBody = EmailBody.Replace("{#Name}", tb1.Text.Trim());
            EmailBody = EmailBody.Replace("{#Password}", RandomPwd);
            SendMail("Employee Login Credentials", true, EmailBody, tb5.Text.Trim());

        }
        public void SendMail(string Subj, bool allowHTML, string strBody, string EmailTo)
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