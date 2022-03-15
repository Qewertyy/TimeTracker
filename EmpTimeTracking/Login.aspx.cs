using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Web.Security;

namespace EmpTimeTracking
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Str"].ToString());
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Loginn";
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPwd.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "P")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, GetType(), "alert", "alert('Please Check Your Password !')", true);
                        return;
                    }
                    else if (dt.Rows[0][0].ToString() == "U")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, GetType(), "alert", "alert('Please Check Your Email Address !')", true);
                        return;
                    }
                    else
                    {
                        if (dt.Rows[0]["Role"].ToString().ToUpper() != "ADMIN")
                        {
                            Session["Role"] = dt.Rows[0]["Role"].ToString();
                            Session["EmpName"] = dt.Rows[0]["EmpName"].ToString();
                            Session["EmpID"] = dt.Rows[0]["EmpID"].ToString();
                            Response.Redirect("~/TimeTracker.aspx", false);
                        }
                        else if(dt.Rows[0]["Role"].ToString().ToUpper() == "ADMIN")
                        {
                            Session["Role"] = dt.Rows[0]["Role"].ToString();
                            Session["EmpName"] = dt.Rows[0]["EmpName"].ToString();
                            Session["EmpID"] = dt.Rows[0]["EmpID"].ToString();
                            Response.Redirect("~/TimeTracker.aspx", false);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void chkbox_CheckedChanged(object sender, EventArgs e)
        {
            if(chkbox.Checked==true)
            {
                txtPwd.Attributes.Add("value", txtPwd.Text);
                txtPwd.TextMode = TextBoxMode.SingleLine;
            }
            if(chkbox.Checked==false)
            {
                txtPwd.TextMode = TextBoxMode.Password;
            }
        }
    }
}