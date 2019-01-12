using BusinessLogic;
using System;

namespace BSNL
{
    public partial class AddBaseData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //AddBaseDataBL.ShowColumn(RptShow);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BSNLEntity.BaseData details = new BSNLEntity.BaseData();
            details.CustomerID = Convert.ToInt32(txtCustID.Text);
            details.CustomerName = fName.Text;
            details.ContactEmail = mail.Text;
            details.LoyaltyScore = txtLoyaltyScore.Text;
            details.CustomerType = ddlCustomerType.SelectedItem.Text;
            details.AvgRevenueScore = txtAvgRevenueScore.Text;
            details.AvgMonthlyBilling = float.Parse(txtAvgMonthlyBilling.Text);
            details.ConnectionType = ddlConnectionType.SelectedItem.Text;
            details.CustomerCategory = ddlCustomerCategory.SelectedItem.Text;
            details.ConnectionActivationDate = Convert.ToDateTime(txtConnectionActivationDate.Text);
            details.FixedLine = ddlFixedLine.SelectedItem.Text;
            details.BB = ddlBB.SelectedItem.Text;
            details.Mobile = ddlMobile.SelectedItem.Text;
            details.SecurityDepositAmt = float.Parse(txtSecurityDepositAmt.Text);
            details.CreditLimit = float.Parse(txtCreditLimit.Text);
            details.DefaultsOrYear = Convert.ToInt32(txtDefaultsOrYear.Text);
            details.LastPaymentDate = Convert.ToDateTime(txtLastPaymentDate.Text);
            details.ConnectionLength = txtConnectionLength.Text;

            int flag = AddBaseDataBL.checkDuplicateID(Convert.ToInt32(txtCustID.Text));
            if (flag > 0)
            {
                lblcustID.Text = "Customer ID already exists !";
            }
            else
            {
                AddBaseDataBL.InsertBaseData(details);
                Response.Redirect("BaseData.aspx");
            }



        }

        protected void ddlFixedLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlFixedLine.SelectedItem.Text == "Yes")
            {
                ddlMobile.SelectedItem.Text = "No";
                ddlBB.SelectedItem.Text = "No";
            }
            //else
            //{
            //    ddlMobile.ClearSelection();
            //    ddlBB.ClearSelection();
            //}
        }
        protected void ddlBB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlBB.SelectedItem.Text == "Yes")
            {
                ddlMobile.SelectedItem.Text = "No";
                ddlFixedLine.SelectedItem.Text = "No";
            }
            //else
            //{
            //    ddlMobile.ClearSelection();
            //    ddlFixedLine.ClearSelection();
            //}

        }
        protected void ddlMobile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlMobile.SelectedItem.Text == "Yes")
            {
                ddlBB.SelectedItem.Text = "No";
                ddlFixedLine.SelectedItem.Text = "No";
            }
            //else
            //{
            //    ddlBB.ClearSelection();
            //    ddlFixedLine.ClearSelection();
            //}
        }
    }
}