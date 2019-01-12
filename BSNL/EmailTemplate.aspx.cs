using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSNL
{
    public partial class EmailTemplate : System.Web.UI.Page
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
            EmailTemplateBL.ShowTemplates(gvTemplate);
        }
        protected void update(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                BSNLEntity.EmailTemplate details = new BSNLEntity.EmailTemplate();
                int id = int.Parse(gvTemplate.DataKeys[e.RowIndex].Value.ToString());
                details.TemplateID = id;
                string Body = ((TextBox)gvTemplate.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
                details.Body = Body;
                EmailTemplateBL.Update(details);
                gvTemplate.EditIndex = -1;
                BindGrid();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            BSNLEntity.EmailTemplate details = new BSNLEntity.EmailTemplate();
            int id = int.Parse(gvTemplate.DataKeys[e.RowIndex].Value.ToString());
            details.TemplateID = id;
            EmailTemplateBL.Delete(details);
            BindGrid();
        }
        protected void edit(object sender, GridViewEditEventArgs e)
        {
            gvTemplate.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {

            gvTemplate.EditIndex = -1;
            BindGrid();
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTemplate.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}