using System;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using BSNLEntity;

namespace ReadExcelFileApp
{
    public class WriteReminderExcel
    {
        public static void UpdateReminder(string CustID, string filePath, string NoOfRem)
        {
            try
            {
                int custIDs = Convert.ToInt32(CustID);
                using (BSNLContext db = new BSNLContext())
                {
                    int i = Convert.ToInt32(NoOfRem) + 1;
                    var query = (from p in db.RevenueDatas
                                 where p.CustomerID == custIDs && p.isActive == true
                                 select p).ToList();
                    foreach (var detail in query)
                    {
                        detail.NoOfReminders = i;
                    }
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }


        }

        public static void UpDateStatus(string CustID, string filePath, string status)
        {
            try
            {
                int custIDs = Convert.ToInt32(CustID);
                using (BSNLContext db = new BSNLContext())
                {
                    var query = (from p in db.BaseDatas
                                 where p.CustomerID == custIDs && p.isActive == true
                                 select p).ToList();
                    foreach(var detail in query)
                    {
                        detail.Status = status;
                    }
                    db.SaveChanges();

                }
                
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }


        }
    }
}
