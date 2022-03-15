using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EmpTimeTracking
{
    public partial class TrackingMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmpID"] !=null)
            {
                if (Session["Role"].ToString().ToUpper() == "USER")
                {
                    lnkbtn1.Visible = false;
                }
                else
                {
                    lnkbtn1.Visible = true;
                }    
                }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }


        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Login.aspx");

        }
    }
}