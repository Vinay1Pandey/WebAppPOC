using BSNLEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BusinessLogic
{
    public class DisputesBL
    {
        public static void ShowDisputes(GridView gvDisputes)
        {
            using (BSNLContext db = new BSNLContext())
            {
                var query = (from p in db.Disputes
                             where p.isActive == true
                             select p).ToList();
                gvDisputes.DataSource = query;
                gvDisputes.DataBind();
            }
        }
        public static void Update(Dispute Getdetails)
        {
            using (BSNLContext db = new BSNLContext())
            {
                var query = (from details in db.Disputes
                             where details.CustomerID == Getdetails.CustomerID
                             select details).ToList();


                foreach (Dispute detail in query)
                {
                    detail.Status = Getdetails.Status;

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
        public static void Delete(Dispute details)
        {
            using (BSNLContext db = new BSNLContext())
            {
                try
                {
                    var deleteDetails = (from d in db.Disputes
                                         where d.CustomerID == details.CustomerID
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
    }
}
