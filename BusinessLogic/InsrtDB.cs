using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSNLEntity;

namespace BusinessLogic
{
    public class InsrtDB
    {
        public static void InsertBaseData(DataTable dt1)
        {
            using (BSNLContext db = new BSNLContext())
            {
                foreach (DataRow row in dt1.Rows)
                {
                    if (row["F10"] == DBNull.Value)
                    {
                        row["F10"] = "";
                    }
                    if (row[dt1.Columns[11].ColumnName] == DBNull.Value)
                    {
                        row[dt1.Columns[11].ColumnName] = "";
                    }
                    if (row["F13"] == DBNull.Value)
                    {
                        row["F13"] = "";
                    }
                    if (row["F14"] == DBNull.Value)
                    {
                        row["F14"] = "";
                    }
                    if (row["F2"] == DBNull.Value)
                    {
                        row["F2"] = "Customer Id";
                    }
                    if (row["F2"].ToString() != "Customer Id")
                    {
                        db.BaseDatas.Add(new BaseData
                        {
                            CustomerID = Convert.ToInt32(row["F2"]),
                            CustomerName = row["F3"].ToString(),
                            CustomerType = row["F4"].ToString(),
                            ConnectionActivationDate = Convert.ToDateTime(row["F5"]),
                            ConnectionLength = row["01-Oct-18"].ToString(),
                            LoyaltyScore = row["F7"].ToString(),
                            AvgRevenueScore = row["F8"].ToString(),
                            AvgMonthlyBilling = float.Parse(row["F9"].ToString()),
                            CustomerCategory = row["F10"].ToString(),
                            ConnectionType = row["F11"].ToString(),
                            FixedLine = row[dt1.Columns[11].ColumnName].ToString(),
                            BB = row["F13"].ToString(),
                            Mobile = row["F14"].ToString(),
                            SecurityDepositAmt = float.Parse(row["F15"].ToString()),
                            CreditLimit = float.Parse(row["F16"].ToString()),
                            DefaultsOrYear = Convert.ToInt32(row["F17"]),
                            LastPaymentDate = Convert.ToDateTime(row["F18"]),
                            ContactEmail = row["F19"].ToString()
                        });
                    }

                }
                db.SaveChanges();
            }
        }

        public static void InsertRevenue(DataTable dt2)
        {
            using (BSNLContext db = new BSNLContext())
            {
                foreach (DataRow row in dt2.Rows)
                {
                    db.RevenueDatas.Add(new RevenueData
                    {
                        CustomerID = Convert.ToInt32(row["Customer Id"]),
                        BillDate = Convert.ToDateTime(row["Bill Date"]),
                        BillAmount = float.Parse(row["Bill Amount (₹)"].ToString()),
                        LatePaymentPenalty = float.Parse(row["Late Payment Penalty (₹)"].ToString()),
                        NoOfReminders = Convert.ToInt32(row["No# of reminders sent"])
                    });
                }
                db.SaveChanges();
            }
                
        }

        public static void InsertDispute(DataTable dt3)
        {
            using (BSNLContext db = new BSNLContext())
            {
                foreach (DataRow row in dt3.Rows)
                {
                    db.Disputes.Add(new Dispute
                    {
                        CustomerID = Convert.ToInt32(row["Customer Id"]),
                        RequestDate = Convert.ToDateTime(row["Request Dt"]),
                        RequestType = row["Request Type"].ToString(),
                        Status = row["Status"].ToString()
                    });
                }
                db.SaveChanges();
            }
        }
    }
}


