using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using BSNLEntity;

namespace BusinessLogic
{
    public class BaseDataBL
    {
        public static void ShowBaseData(GridView gvBaseData)
        {
            using (BSNLContext db = new BSNLContext())
            {
                var query = (from p in db.BaseDatas
                             where p.isActive==true
                             select p).ToList();
                gvBaseData.DataSource = query;
                gvBaseData.DataBind();
            }
        }
        public static void Delete(BaseData details)
        {
            using (BSNLContext db = new BSNLContext())
            {
                try
                {
                    var deleteDetails = (from d in db.BaseDatas
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
        public static void Update(BaseData Getdetails)
        {
            using (BSNLContext db = new BSNLContext())
            {
                var query = from details in db.BaseDatas
                            where details.CustomerID == Getdetails.CustomerID
                            select details;


                foreach (BaseData detail in query)
                {
                    detail.ContactEmail = Getdetails.ContactEmail;

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
