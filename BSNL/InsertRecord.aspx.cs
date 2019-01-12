using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSNL
{
    public partial class InsertRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string FolderPath = HttpContext.Current.Server.MapPath("~/Upload/");
                string FilePath = FolderPath + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
                FileUpload1.SaveAs(FilePath);
                Ui.Style.Add("display", "none");
                //gridView.Style.Add("display", "block");
                lblShow.Visible = true;
                lblShow.ForeColor = Color.Green;
                lblShow.Text = "Processing...";
                DataTable dtBaseData = ReadExcel.ConvertExcelToDataTableBaseData(FilePath);
                DataTable dtRevenue = ReadExcel.ConvertExcelToDataTableRevenue(FilePath);
                DataTable dtDisputes = ReadExcel.ConvertExcelToDataTableDisputes(FilePath);
                // Import_To_Grid(FilePath, Extension, "No");
                InsrtDB.InsertBaseData(dtBaseData);
                InsrtDB.InsertRevenue(dtRevenue);
                InsrtDB.InsertDispute(dtDisputes);
                lblShow.Text = "Data Inserted Successfully";

            }
        }
        //private void Import_To_Grid(string FilePath, string Extension, string isHDR)
        //{
        //    string conStr = "";
        //    switch (Extension)
        //    {
        //        case ".xls":
        //            conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
        //            break;
        //        case ".xlsx":
        //            conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
        //            break;
        //    }
        //    conStr = string.Format(conStr, FilePath, isHDR);
        //    OleDbConnection connExcel = new OleDbConnection(conStr);
        //    OleDbCommand cmdExcel = new OleDbCommand();
        //    OleDbDataAdapter oda = new OleDbDataAdapter();
        //    DataTable dt1 = new DataTable();
        //    cmdExcel.Connection = connExcel;
        //    connExcel.Open();
        //    DataTable dtExcelSchema;
        //    dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        //    string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
        //    connExcel.Close();
        //    connExcel.Open();
        //    cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

        //    oda.SelectCommand = cmdExcel;
        //    oda.Fill(dt1);
        //    connExcel.Close();
        //    GridView1.Caption = Path.GetFileName(FilePath);
        //    GridView1.DataSource = dt1;
        //    GridView1.DataBind();
        //    DataTable dt = ConvertExcelToDataTable(FilePath);
        //    //processData(dt);
        //}
        //protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    string FolderPath = HttpContext.Current.Server.MapPath("Upload/");
        //    string FileName = GridView1.Caption;
        //    string Extension = Path.GetExtension(FileName);
        //    string FilePath = Server.MapPath(FolderPath + FileName);
        //    // Import_To_Grid(FilePath, Extension, "No");
        //    GridView1.PageIndex = e.NewPageIndex;
        //    GridView1.DataBind();
        //}
    }
}