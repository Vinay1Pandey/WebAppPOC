using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSNL
{
    public partial class AddDisputes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            BSNLEntity.Dispute details = new BSNLEntity.Dispute();
            details.CustomerID = Convert.ToInt32(txtCustID.Text);
            details.RequestDate = Convert.ToDateTime(txtRequestDate.Text);
            details.RequestType = txtRequestType.Text;
            details.Status = txtStatus.Text;
            details.isActive = true;
            int flag = AddDisputesBL.checkDuplicateID(Convert.ToInt32(txtCustID.Text));
            if (flag > 0)
            {
                lblcustID.Text = "Customer ID already exists !";
            }
            else
            {
                AddDisputesBL.InsertDisputesData(details);
                Response.Redirect("Disputes.aspx");
            }
        }
    }
}