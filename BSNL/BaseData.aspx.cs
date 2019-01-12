using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSNLEntity;
namespace BSNL
{
    public partial class BaseData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindGrid();
            }
        }
        public void BindGrid()
        {
            BaseDataBL.ShowBaseData(gvBaseData);
        }
        protected void update(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                BSNLEntity.BaseData details = new BSNLEntity.BaseData();
                int id = int.Parse(gvBaseData.DataKeys[e.RowIndex].Value.ToString());
                details.CustomerID = id;
                string Email = ((TextBox)gvBaseData.Rows[e.RowIndex].Cells[17].Controls[0]).Text;
                details.ContactEmail = Email;
                BaseDataBL.Update(details);
                gvBaseData.EditIndex = -1;
                BindGrid();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            BSNLEntity.BaseData details = new BSNLEntity.BaseData();
            int id = int.Parse(gvBaseData.DataKeys[e.RowIndex].Value.ToString());
            details.CustomerID = id;
            BaseDataBL.Delete(details);
            BindGrid();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void edit(object sender, GridViewEditEventArgs e)
        {
            gvBaseData.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {

            gvBaseData.EditIndex = -1;
            BindGrid();
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBaseData.PageIndex = e.NewPageIndex;
            BaseDataBL.ShowBaseData(gvBaseData);
        }

        protected void btnAddNewRow_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}