using BSNLEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BusinessLogic
{
    public class RevenueDataBL
    {
        public static void ShowRevenue(GridView gvRevenue)
        {
            using (BSNLContext db = new BSNLContext())
            {
                var query = (from p in db.RevenueDatas
                             where p.isActive == true
                             select p).ToList();
                gvRevenue.DataSource = query;
                gvRevenue.DataBind();
            }
        }
        public static void Update(RevenueData Getdetails)
        {
            using (BSNLContext db = new BSNLContext())
            {
                var query = (from details in db.RevenueDatas
                             where details.CustomerID == Getdetails.CustomerID
                             select details).ToList();


                foreach (RevenueData detail in query)
                {
                    detail.NoOfReminders = Getdetails.NoOfReminders;

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
        public static void Delete(RevenueData details)
        {
            using (BSNLContext db = new BSNLContext())
            {
                try
                {
                    var deleteDetails = (from d in db.RevenueDatas
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
