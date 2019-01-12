using BSNLEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AddDisputesBL
    {
        public static void InsertDisputesData(Dispute details)
        {
            try
            {
                using (BSNLContext db = new BSNLContext())
                {
                    db.Disputes.Add(details);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static int checkDuplicateID(int id)
        {
            int flag = 0;
            using (BSNLContext db = new BSNLContext())
            {
                var query = from c in db.Disputes
                            where c.CustomerID == id
                            select c;
                if (query.Count() > 0)
                {
                    flag = 1;
                }

                return flag;
            }
        }
    }
}
