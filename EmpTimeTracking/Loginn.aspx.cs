//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Data;
//using System.Data.SqlClient;
//using System.Configuration;

//namespace EmpTimeTracking
//{
//    public partial class Login : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {

//        }
//        protected void btnlogin_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                DataTable dt = new DataTable();
//                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Str"].ToString());
//                SqlCommand cmd = new SqlCommand();
//                cmd.Connection = con;
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.CommandText = "Loginn";
//                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
//                cmd.Parameters.AddWithValue("@Password", txtPwd.Text);
//                SqlDataAdapter da = new SqlDataAdapter(cmd);
//                da.Fill(dt);
//                if (dt.Rows.Count > 0)
//                {
//                    if (dt.Rows[0][0].ToString() == "P")
//                    {
//                        ScriptManager.RegisterStartupScript(this.Page, GetType(), "alert", "alert('Please Check Your Password !')", true);
//                        return;
//                    }
//                    else if (dt.Rows[0][0].ToString() == "U")
//                    {
//                        ScriptManager.RegisterStartupScript(this.Page, GetType(), "alert", "alert('Please Check Your Email Address !')", true);
//                        return;
//                    }
//                    else
//                    {
//                        if (dt.Rows[0]["Role"].ToString().ToUpper() == "ADMIN")
//                        {
                            
//                        }
//                        else
//                        {
//                            Session["Role"] = dt.Rows[0]["Role"].ToString();
//                        }
//                    }
//                }

//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

//        protected void chkbox_CheckedChanged(object sender, EventArgs e)
//        {
            
//        }
//    }
//}
    
