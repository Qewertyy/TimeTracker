using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace EmpTimeTracking
{
    public partial class TimeTracker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Trynew();
                Try();
            }
        }
        public void Trynew()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Str"].ToString());
            SqlCommand cmd;
            if (Session["Role"].ToString().ToUpper() != "ADMIN")
            {
                cmd = new SqlCommand("select TrackerID,EmpID,Work,TimeStart,TimeStop,Status from TimeTracker where EmpID='" + Session["EmpID"] + "' and cast (TimeStart as date)='" + DateTime.Now.ToShortDateString() + "'", con);
            }
            else
            {
                if(dll1.SelectedIndex <=0)
                cmd = new SqlCommand("select TrackerID,EmpID,Work,TimeStart,TimeStop,Status from TimeTracker where cast (TimeStart as date)='" + DateTime.Now.ToShortDateString() + "'", con);
            else
                    cmd = new SqlCommand("select TrackerID,EmpID,Work,TimeStart,TimeStop,Status from TimeTracker where EmpID='"+dll1.SelectedValue+"' and cast (TimeStart as date)='"+DateTime.Now.ToShortDateString()+"'", con);
            }
        
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gridview2.DataSource = dt;
                gridview2.DataBind();
            }
        }
        public void Try()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Str"].ToString());
            SqlCommand cmd;
            if (Session["Role"].ToString().ToUpper() != "ADMIN")
            {
                cmd = new SqlCommand("select * from Emp0 where EmpID='" + Session["EmpID"].ToString() + "'", con);
            }
            else
            {
                cmd = new SqlCommand("select * from Emp0 ", con);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dll1.DataTextField = dt.Columns["Empname"].ToString();
            dll1.DataValueField = dt.Columns["EmpID"].ToString();
            if (dt.Rows.Count > 0)
            {
                dll1.DataSource = dt;
                dll1.DataBind();
            }

        }

        protected void gridview2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void bttn_Click(object sender, EventArgs e)
        {
            if (bttn.Text == "Start")
            {
                tt2.Text = Convert.ToString(DateTime.Now);
                bttn.Text = "Stop";
            }
            else if (bttn.Text == "Stop")
            {
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Str"].ToString());
                SqlCommand cmd = new SqlCommand("insert into TimeTracker values('" + dll1.SelectedItem.Value + "','" + tt1.Text + "','" + tt2.Text + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "','" + tt3.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Trynew();
                tt1.Text = string.Empty;
                tt2.Text = string.Empty;
                tt3.Text = string.Empty;
                bttn.Text = "Start";
            }
        }
    }
}
