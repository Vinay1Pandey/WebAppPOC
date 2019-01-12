using BSNLEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BusinessLogic
{
    public class EmailTemplateBL
    {
        public static void ShowTemplates(GridView gvTemplate)
        {
            using (BSNLContext db = new BSNLContext())
            {
                var query = (from p in db.EmailTemplates
                             where p.isActive == true
                             select new
                             {
                                 p.TemplateID,
                                 p.Name,
                                 p.Subject,
                                 p.Body,
                                 p.ccEmailAddress
                             }).ToList();
                gvTemplate.DataSource = query;
                gvTemplate.DataBind();
            }
        }
        public static void Delete(EmailTemplate details)
        {
            using (BSNLContext db = new BSNLContext())
            {
                try
                {
                    var deleteDetails = (from d in db.EmailTemplates
                                         where d.TemplateID == details.TemplateID
                                         select d).ToList();

                    foreach (var detail in deleteDetails)
                    {
                        detail.isActive = false;
                    }
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
        }
        public static void Update(EmailTemplate Getdetails)
        {
            using (BSNLContext db = new BSNLContext())
            {
                var query = (from details in db.EmailTemplates
                            where details.TemplateID == Getdetails.TemplateID
                            select details).ToList();


                foreach (EmailTemplate detail in query)
                {
                    detail.Body = Getdetails.Body;

                }


                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }

        }
    }
}
