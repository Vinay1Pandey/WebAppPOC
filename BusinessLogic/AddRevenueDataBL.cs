using BSNLEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AddRevenueDataBL
    {
        public static void InsertRevenueData(RevenueData details)
        {
            try
            {
                using (BSNLContext db = new BSNLContext())
                {
                    db.RevenueDatas.Add(details);
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
                var query = from c in db.RevenueDatas
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
