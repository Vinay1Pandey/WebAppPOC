using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSNL
{
    public partial class RevenueData : System.Web.UI.Page
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
            RevenueDataBL.ShowRevenue(gvRevenue);
        }
        protected void update(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                BSNLEntity.RevenueData details = new BSNLEntity.RevenueData();
                int id = int.Parse(gvRevenue.DataKeys[e.RowIndex].Value.ToString());
                details.CustomerID = id;
                string Reminders = ((TextBox)gvRevenue.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
                details.NoOfReminders = Convert.ToInt32(Reminders);
                RevenueDataBL.Update(details);
                gvRevenue.EditIndex = -1;
                BindGrid();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            BSNLEntity.RevenueData details = new BSNLEntity.RevenueData();
            int id = int.Parse(gvRevenue.DataKeys[e.RowIndex].Value.ToString());
            details.CustomerID = id;
            RevenueDataBL.Delete(details);
            BindGrid();
        }
        protected void edit(object sender, GridViewEditEventArgs e)
        {
            gvRevenue.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {

            gvRevenue.EditIndex = -1;
            BindGrid();
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRevenue.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}