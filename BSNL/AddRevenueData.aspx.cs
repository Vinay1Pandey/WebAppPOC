using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSNL
{
    public partial class AddRevenueData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            BSNLEntity.RevenueData details = new BSNLEntity.RevenueData();
            details.CustomerID = Convert.ToInt32(txtCustID.Text);
            details.BillDate = Convert.ToDateTime(txtBillDate.Text);
            details.BillAmount = float.Parse(txtBillAmt.Text);
            details.LatePaymentPenalty = float.Parse(txtPenalty.Text);
            details.NoOfReminders = Convert.ToInt32(txtReminder.Text);
            details.isActive = true;
            int flag = AddRevenueDataBL.checkDuplicateID(Convert.ToInt32(txtCustID.Text));
            if (flag > 0)
            {
                lblcustID.Text = "Customer ID already exists !";
            }
            else
            {
                AddRevenueDataBL.InsertRevenueData(details);
                Response.Redirect("RevenueData.aspx");
            }
        }
    }
}