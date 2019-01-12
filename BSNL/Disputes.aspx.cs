using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSNL
{
    public partial class Disputes : System.Web.UI.Page
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
            DisputesBL.ShowDisputes(gvDisputes);
        }
        protected void update(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                BSNLEntity.Dispute details = new BSNLEntity.Dispute();
                int id = int.Parse(gvDisputes.DataKeys[e.RowIndex].Value.ToString());
                details.CustomerID = id;
                string Status = ((TextBox)gvDisputes.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
                details.Status = Status;
                DisputesBL.Update(details);
                gvDisputes.EditIndex = -1;
                BindGrid();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            BSNLEntity.Dispute details = new BSNLEntity.Dispute();
            int id = int.Parse(gvDisputes.DataKeys[e.RowIndex].Value.ToString());
            details.CustomerID = id;
            DisputesBL.Delete(details);
            BindGrid();
        }
        protected void edit(object sender, GridViewEditEventArgs e)
        {
            gvDisputes.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {

            gvDisputes.EditIndex = -1;
            BindGrid();
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDisputes.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}