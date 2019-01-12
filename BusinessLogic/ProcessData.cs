using BSNLEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace ReadExcelFileApp
{
    public class ProcessData
    {
        public static void processData(string filepath)
        {
            try
            {
                double NetAmtOS = 0;
                List<DateTime> lstLastPaymentDate = new List<DateTime>();
                List<int> lstCustID = new List<int>();
                List<int> lstDisputesCust = new List<int>();
                List<string> lstNoDisputeEmails = new List<string>();
                List<int> lstNoDisputeCustID = new List<int>();
                List<string> lstMobiles = new List<string>();
                List<string> lstBB = new List<string>();
                List<string> lstFixedLine = new List<string>();
                List<string> lstCustName = new List<string>();
                List<float> lstBill = new List<float>();
                List<float> lstDeposits = new List<float>();
                List<float> lstCRLimits = new List<float>();
                List<string> lstConnectionType = new List<string>();
                List<string> lstCostumerCategory = new List<string>();
                List<int> lstDefaults = new List<int>();
                List<string> lstCustomerType = new List<string>();
                List<string> lstAVGR = new List<string>();
                List<string> lstLOYT = new List<string>();
                List<int> lstReminder = new List<int>();
                using (BSNLContext db = new BSNLContext())
                {
                    lstLastPaymentDate = (from p in db.BaseDatas
                                          where p.isActive == true
                                          select p.LastPaymentDate).ToList();
                    lstCustID = (from p in db.BaseDatas
                                 where p.isActive == true
                                 select p.CustomerID).ToList();
                    lstDisputesCust = (from p in db.Disputes
                                       where p.isActive == true
                                       select p.CustomerID).ToList();
                    lstNoDisputeCustID = lstCustID.Except(lstDisputesCust).ToList();
                    foreach (var item in lstNoDisputeCustID)
                    {
                        var query = (from p in db.BaseDatas
                                     where p.CustomerID == item && p.isActive == true
                                     select p.ContactEmail).ToList();
                        lstNoDisputeEmails.Add(query[0]);
                        query = (from p in db.BaseDatas
                                 where p.CustomerID == item && p.isActive == true
                                 select p.Mobile).ToList();
                        lstMobiles.Add(query[0]);
                        query = (from p in db.BaseDatas
                                 where p.CustomerID == item && p.isActive == true
                                 select p.BB).ToList();
                        lstBB.Add(query[0]);
                        query = (from p in db.BaseDatas
                                 where p.CustomerID == item && p.isActive == true
                                 select p.FixedLine).ToList();
                        lstFixedLine.Add(query[0]);
                        query = (from p in db.BaseDatas
                                 where p.CustomerID == item && p.isActive == true
                                 select p.CustomerName).ToList();
                        lstCustName.Add(query[0]);
                        var query1 = (from p in db.RevenueDatas
                                      where p.CustomerID == item && p.isActive == true
                                      select p.BillAmount).ToList();
                        lstBill.Add(query1[0]);
                        query1 = (from p in db.BaseDatas
                                  where p.CustomerID == item && p.isActive == true
                                  select p.SecurityDepositAmt).ToList();
                        lstDeposits.Add(query1[0]);
                        query1 = (from p in db.BaseDatas
                                  where p.CustomerID == item && p.isActive == true
                                  select p.CreditLimit).ToList();
                        lstCRLimits.Add(query1[0]);
                        query = (from p in db.BaseDatas
                                 where p.CustomerID == item && p.isActive == true
                                 select p.ConnectionType).ToList();
                        lstConnectionType.Add(query[0]);
                        query = (from p in db.BaseDatas
                                 where p.CustomerID == item && p.isActive == true
                                 select p.CustomerCategory).ToList();
                        lstCostumerCategory.Add(query[0]);
                        var query2 = (from p in db.BaseDatas
                                      where p.CustomerID == item && p.isActive == true
                                      select p.DefaultsOrYear).ToList();
                        lstDefaults.Add(query2[0]);
                        query = (from p in db.BaseDatas
                                 where p.CustomerID == item && p.isActive == true
                                 select p.CustomerType).ToList();
                        lstCustomerType.Add(query[0]);
                        query = (from p in db.BaseDatas
                                 where p.CustomerID == item && p.isActive == true
                                 select p.AvgRevenueScore).ToList();
                        lstAVGR.Add(query[0]);
                        query = (from p in db.BaseDatas
                                 where p.CustomerID == item && p.isActive == true
                                 select p.LoyaltyScore).ToList();
                        lstLOYT.Add(query[0]);
                        query2 = (from p in db.RevenueDatas
                                  where p.CustomerID == item && p.isActive == true
                                  select p.NoOfReminders).ToList();
                        lstReminder.Add(query2[0]);

                    }


                }
                var stringList = lstLastPaymentDate;
                var stringListCustName = lstCustName;
                var stringListDeposits = lstDeposits;
                var stringListCRLimits = lstCRLimits;
                var stringListConnectionType = lstConnectionType;

                List<string> lstGadgets = new List<string>();
                for (int i = 0; i < lstBB.Count(); i++)
                {
                    if (lstBB[i] == "Yes")
                    {
                        lstGadgets.Add("BroadBand");
                    }
                    else if (lstMobiles[i] == "Yes")
                    {
                        lstGadgets.Add("Mobiles");
                    }
                    else if (lstFixedLine[i] == "Yes")
                    {
                        lstGadgets.Add("FixedLine");
                    }
                }
                double date = 0;

                for (int i = 0; i < stringList.Count; i++)
                {

                    if (stringList[i] != null)
                    {
                        string dtS = stringList[i].ToShortDateString();
                        //string dtS = string.Format("{0:MM/dd/yy}", Convert.ToDateTime(item).ToShortDateString());
                        string dtNow = string.Format("{0:yyyy/MM/dd}", DateTime.Now);

                        date = (Convert.ToDateTime(dtNow) - Convert.ToDateTime(dtS)).TotalDays;
                        //date = 31;
                        if (date <= 30)
                        {
                            //EM=0;
                            //SendEmail.Email(0,stringListEmailID.ToList());
                            // WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Out standing days are less than 30");
                        }
                        else if (date > 30 && date <= 60)
                        {
                            NetAmtOS = Convert.ToDouble(lstBill[i].ToString()) - Convert.ToDouble(stringListDeposits[i]) - Convert.ToDouble(stringListCRLimits[i]);
                            //NetAmtOS = 999;
                            if (NetAmtOS <= 0)
                            {
                                //EM0
                                // WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Net Amount is less than or equal to 0");
                            }
                            else if (0 < NetAmtOS && NetAmtOS <= 1000)
                            {
                                if (stringListConnectionType[i] == "Private")
                                {
                                    if (lstCostumerCategory[i] == "CIP")
                                    {
                                        if (Convert.ToInt32(lstDefaults[i]) > 0)
                                        {
                                            //cust
                                            if (lstCustomerType[i].ToUpper().Equals("INDIVIDUAL"))
                                            {
                                                //avgr
                                                if (Convert.ToInt32(lstAVGR[i]) <= 3)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute

                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(3, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");
                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(4, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (3 < Convert.ToInt32(lstAVGR[i]) && Convert.ToInt32(lstAVGR[i]) <= 6)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(1, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(2, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (Convert.ToInt32(lstAVGR[i]) > 6)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(1, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(2, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                            }
                                            else if (lstCustomerType[i].ToUpper().Equals("BUSINESS") ||
                                                lstCustomerType[i].ToUpper().Equals("SERVICE") || lstCustomerType[i].ToUpper().Equals("EMER"))
                                            {
                                                //avgr
                                                if (Convert.ToInt32(lstAVGR[i]) <= 3)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(3, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(4, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (3 < Convert.ToInt32(lstAVGR[i]) && Convert.ToInt32(lstAVGR[i]) <= 6)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(1, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(2, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (Convert.ToInt32(lstAVGR[i]) > 6)
                                                {
                                                    //SendEmail.Email(0, stringListEmailID.ToList());
                                                }
                                            }
                                        }
                                        else if (Convert.ToInt32(lstDefaults[i]) == 0)
                                        {
                                            //cust
                                            if (lstCustomerType[i].ToUpper().Equals("INDIVIDUAL"))
                                            {
                                                //avgr
                                                if (Convert.ToInt32(lstAVGR[i]) <= 3)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(1, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(2, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (3 < Convert.ToInt32(lstAVGR[i]) && Convert.ToInt32(lstAVGR[i]) <= 6)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(1, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(2, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (Convert.ToInt32(lstAVGR[i]) > 6)
                                                {
                                                    //SendEmail.Email(0, lstDisputeEmail);
                                                }
                                            }
                                            else if (lstCustomerType[i].ToUpper().Equals("BUSINESS") ||
                                                lstCustomerType[i].ToUpper().Equals("SERVICE") || lstCustomerType[i].ToUpper().Equals("EMER"))
                                            {
                                                //SendEmail.Email(0, lstDisputeEmail);
                                            }
                                        }
                                    }
                                    else if (lstCostumerCategory[i] == "VIP")
                                    {
                                        if (Convert.ToInt32(lstDefaults[i]) > 0)
                                        {
                                            //cust
                                            if (lstCustomerType[i].ToUpper().Equals("INDIVIDUAL"))
                                            {
                                                //avgr
                                                if (Convert.ToInt32(lstAVGR[i]) <= 3)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(3, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(4, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (3 < Convert.ToInt32(lstAVGR[i]) && Convert.ToInt32(lstAVGR[i]) <= 6)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(1, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(2, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (Convert.ToInt32(lstAVGR[i]) > 6)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(1, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(2, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                            }
                                            else if (lstCustomerType[i].ToUpper().Equals("BUSINESS") ||
                                                lstCustomerType[i].ToUpper().Equals("SERVICE") || lstCustomerType[i].ToUpper().Equals("EMER"))
                                            {
                                                //avgr
                                                if (Convert.ToInt32(lstAVGR[i]) <= 3)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(3, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(4, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (3 < Convert.ToInt32(lstAVGR[i]) && Convert.ToInt32(lstAVGR[i]) <= 6)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(1, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(2, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (Convert.ToInt32(lstAVGR[i]) > 6)
                                                {
                                                    //SendEmail.Email(0, lstDisputeEmail);
                                                }
                                            }
                                        }
                                        else if (Convert.ToInt32(lstDefaults[i]) == 0)
                                        {
                                            //cust
                                            if (lstCustomerType[i].ToUpper().Equals("INDIVIDUAL"))
                                            {
                                                //avgr
                                                if (Convert.ToInt32(lstAVGR[i]) <= 3)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(1, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(2, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (3 < Convert.ToInt32(lstAVGR[i]) && Convert.ToInt32(lstAVGR[i]) <= 6)
                                                {
                                                    //SendEmail.Email(0, lstDisputeEmail);
                                                }
                                                else if (Convert.ToInt32(lstAVGR[i]) > 6)
                                                {
                                                    //SendEmail.Email(0, lstDisputeEmail);
                                                }
                                            }
                                            else if (lstCustomerType[i].ToUpper().Equals("BUSINESS") ||
                                                lstCustomerType[i].ToUpper().Equals("SERVICE") || lstCustomerType[i].ToUpper().Equals("EMER"))
                                            {
                                                //SendEmail.Email(0, lstDisputeEmail);
                                            }
                                        }
                                    }
                                    else if (lstCostumerCategory[i] == "VVIP")
                                    {
                                        if (Convert.ToInt32(lstDefaults[i]) > 0)
                                        {
                                            //cust
                                            if (lstCustomerType[i].ToUpper().Equals("INDIVIDUAL"))
                                            {
                                                //avgr
                                                if (Convert.ToInt32(lstAVGR[i]) <= 3)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(3, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(4, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (3 < Convert.ToInt32(lstAVGR[i]) && Convert.ToInt32(lstAVGR[i]) <= 6)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(1, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(2, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (Convert.ToInt32(lstAVGR[i]) > 6)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(1, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(2, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                            }
                                            else if (lstCustomerType[i].ToUpper().Equals("BUSINESS") ||
                                                lstCustomerType[i].ToUpper().Equals("SERVICE") || lstCustomerType[i].ToUpper().Equals("EMER"))
                                            {
                                                //avgr
                                                if (Convert.ToInt32(lstAVGR[i]) <= 3)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(1, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(2, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (3 < Convert.ToInt32(lstAVGR[i]) && Convert.ToInt32(lstAVGR[i]) <= 6)
                                                {
                                                    //SendEmail.Email(0, lstDisputeEmail);
                                                }
                                                else if (Convert.ToInt32(lstAVGR[i]) > 6)
                                                {
                                                    //SendEmail.Email(0, lstDisputeEmail);
                                                }
                                            }
                                        }
                                        else if (Convert.ToInt32(lstDefaults[i]) == 0)
                                        {
                                            //cust
                                            if (lstCustomerType[i].ToUpper().Equals("INDIVIDUAL"))
                                            {
                                                //avgr
                                                if (Convert.ToInt32(lstAVGR[i]) <= 3)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        //SendEmail.Email(0, lstNoDisputeEmails);
                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(1, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (3 < Convert.ToInt32(lstAVGR[i]) && Convert.ToInt32(lstAVGR[i]) <= 6)
                                                {
                                                    //SendEmail.Email(0, lstDisputeEmail);
                                                }
                                                else if (Convert.ToInt32(lstAVGR[i]) > 6)
                                                {
                                                    //SendEmail.Email(0, lstDisputeEmail);
                                                }
                                            }
                                            else if (lstCustomerType[i].ToUpper().Equals("BUSINESS") ||
                                                lstCustomerType[i].ToUpper().Equals("SERVICE") || lstCustomerType[i].ToUpper().Equals("EMER"))
                                            {
                                                //SendEmail.Email(0, lstDisputeEmail);
                                            }
                                        }
                                    }
                                    else if (lstCostumerCategory[i] == "General")
                                    {
                                        if (Convert.ToInt32(lstDefaults[i]) > 0)
                                        {
                                            //cust
                                            if (lstCustomerType[i].ToUpper().Equals("INDIVIDUAL"))
                                            {
                                                //avgr
                                                if (Convert.ToInt32(lstAVGR[i]) <= 3)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(5, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(6, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (3 < Convert.ToInt32(lstAVGR[i]) && Convert.ToInt32(lstAVGR[i]) <= 6)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(3, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(4, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (Convert.ToInt32(lstAVGR[i]) > 6)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(3, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(4, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                            }
                                            else if (lstCustomerType[i].ToUpper().Equals("BUSINESS") ||
                                                lstCustomerType[i].ToUpper().Equals("SERVICE") || lstCustomerType[i].ToUpper().Equals("EMER"))
                                            {
                                                //avgr
                                                if (Convert.ToInt32(lstAVGR[i]) <= 3)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(5, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(6, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (3 < Convert.ToInt32(lstAVGR[i]) && Convert.ToInt32(lstAVGR[i]) <= 6)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(3, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(4, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (Convert.ToInt32(lstAVGR[i]) > 6)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(1, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        // SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(2, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                            }
                                        }
                                        else if (Convert.ToInt32(lstDefaults[i]) == 0)
                                        {
                                            //cust
                                            if (lstCustomerType[i].ToUpper().Equals("INDIVIDUAL"))
                                            {
                                                //avgr
                                                if (Convert.ToInt32(lstAVGR[i]) <= 3)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        // SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(5, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(6, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (3 < Convert.ToInt32(lstAVGR[i]) && Convert.ToInt32(lstAVGR[i]) <= 6)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        // SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(3, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(4, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (Convert.ToInt32(lstAVGR[i]) > 6)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(3, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(4, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                            }
                                            else if (lstCustomerType[i].ToUpper().Equals("BUSINESS") ||
                                                lstCustomerType[i].ToUpper().Equals("SERVICE") || lstCustomerType[i].ToUpper().Equals("EMER"))
                                            {
                                                //avgr
                                                if (Convert.ToInt32(lstAVGR[i]) <= 3)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(5, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(6, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (3 < Convert.ToInt32(lstAVGR[i]) && Convert.ToInt32(lstAVGR[i]) <= 6)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(3, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(4, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                                else if (Convert.ToInt32(lstAVGR[i]) > 6)
                                                {
                                                    //loyt
                                                    if (Convert.ToInt32(lstLOYT[i]) > 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(1, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                    else if (Convert.ToInt32(lstLOYT[i]) == 1)
                                                    {
                                                        //dispute
                                                        //SendEmail.Email(0, lstDisputeEmail);

                                                        SendEmail.Email(2, lstNoDisputeEmails[i], stringList[i].ToShortDateString(), lstBill[i].ToString(), lstReminder[i].ToString(), stringList[i].ToShortDateString(), lstCustName[i], lstGadgets[i]);
                                                        WriteReminderExcel.UpdateReminder(lstNoDisputeCustID[i].ToString(), filepath, lstReminder[i].ToString()); WriteReminderExcel.UpDateStatus(lstNoDisputeCustID[i].ToString(), filepath, "Reminder Sent");

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (lstCostumerCategory[i].ToUpper().Equals("CIP"))
                                    {
                                    }
                                    else if (lstCostumerCategory[i].ToUpper().Equals("VIP"))
                                    {
                                    }
                                    else if (lstCostumerCategory[i].ToUpper().Equals("VVIP"))
                                    {
                                    }
                                    else if (lstCostumerCategory[i].ToUpper().Equals("GENERAL"))
                                    {
                                    }
                                }

                            }
                            else if (1000 < NetAmtOS && NetAmtOS <= 3000)
                            {

                            }
                            else if (3000 < NetAmtOS && NetAmtOS <= 10000)
                            {

                            }
                            else if (10000 < NetAmtOS && NetAmtOS <= 25000)
                            {

                            }
                            else if (25000 < NetAmtOS && NetAmtOS <= 50000)
                            {

                            }
                            else if (50000 < NetAmtOS && NetAmtOS <= 100000)
                            {

                            }
                            else if (100000 < NetAmtOS && NetAmtOS <= 500000)
                            {

                            }
                            else if (NetAmtOS > 500000)
                            {

                            }

                        }
                    }
                    else if (60 < date && date <= 90)
                    {

                    }
                    else if (date > 90)
                    {

                    }
                }
                //}


            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }
    }
}
