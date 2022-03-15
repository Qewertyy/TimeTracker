using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;


namespace EmpTimeTracking
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dll1();
                BindGrid();
            }
            if(Session["Role"].ToString().ToUpper() !="ADMIN")
            {
                dll2.Visible = false;
                namelbl.Visible = false;
            }
            else
            {
                dll2.Visible = true;
                namelbl.Visible = true;
            }
        }


        public void dll1()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Str"].ToString());
            SqlCommand cmd;
            if (Session["Role"].ToString().ToUpper() != "ADMIN") 
            {
                cmd = new SqlCommand("select * from Emp0 Where EmpID='" + Session["EmpID"] + "'", con);
            }
            else
            {
                cmd = new SqlCommand("select * from Emp0", con);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dll2.DataTextField = dt.Columns["EmpName"].ToString();
            dll2.DataValueField = dt.Columns["EmpID"].ToString();
            dll2.DataSource = dt;
            dll2.DataBind();
            dll2.Items.Insert(0, "---Select---");
        }
        
        

        protected void tt1_TextChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
        protected void BindGrid()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Str"].ToString());
            SqlCommand cmd;
            if (Session["Role"].ToString().ToUpper() != "ADMIN")
            {
                cmd = new SqlCommand("select TrackerID,EmpID,Work,TimeStart,TimeStop,Status from TimeTracker Where EmpID='" + Session["EmpID"].ToString() + "' and cast(TimeStart as date)='" + (string.IsNullOrEmpty(tt1.Text.Trim()) ? DateTime.Now.ToShortDateString() : tt1.Text)  + "'", con);
            }
            else
            {
                if(dll2.SelectedIndex>=0)
                cmd = new SqlCommand("select TrackerID,EmpID,Work,TimeStart,TimeStop,Status from TimeTracker Where cast(TimeStart as date) ='" +(string.IsNullOrEmpty(tt1.Text.Trim()) ? DateTime.Now.ToShortDateString() : tt1.Text) + "'", con);
                  else
                    cmd = new SqlCommand("select TrackerID,EmpID,Work,TimeStart,TimeStop,Status from TimeTracker Where EmpID='" + dll2.SelectedValue + "' and cast(TimeStart as date) ='" + (string.IsNullOrEmpty(tt1.Text.Trim()) ? DateTime.Now.ToShortDateString() : tt1.Text) + "'", con);

            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gv22.DataSource = dt;
                gv22.DataBind();
                btnpdf.Visible = true;
                btnxslx.Visible = true;
                btndocx.Visible = true;
            }
            else
            {
                gv22.DataSource = null;
                gv22.DataBind();
                btnpdf.Visible = false;
                btnxslx.Visible = false;
                btndocx.Visible = false;
            }
        }

        protected void btnpdf_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Tracker_Report.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gv22.HeaderRow.BackColor = System.Drawing.Color.Black;
            gv22.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            gv22.AllowPaging = true;
            gv22.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

        protected void btnxslx_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }
        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Tracker_Report.xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gv22.GridLines = GridLines.Both;
            gv22.HeaderRow.Style.Add("background-color", "#FFFFFF");
            gv22.HeaderStyle.Font.Bold = true;
            gv22.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

        protected void btndocx_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Tracker_Report.doc");
            Response.ContentType = "application/word";
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
            gv22.HeaderRow.Style.Add("background-color", "#FFFFFF");
            gv22.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
    }
}














