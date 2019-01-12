using BSNLEntity;
using MessageTemplate;
using System;

namespace ReadExcelFileApp
{
    public class SendEmail
    {
        public static void Email(int i, string EmailID, string LastPayDate, string ListBill, string Reminder, string DueDate, string CustName, string Gadgets)
        {
            try
            {
                EmailTemplate emailContent = new EmailTemplate();
                TokenMessageTemplate valEmail = new TokenMessageTemplate();

                int reminder = Convert.ToInt32(Reminder) + 1;
                switch (i)
                {

                    case 1:

                        emailContent.Name = "EM1";
                        emailContent.To = EmailID;
                        emailContent.ToUserName = CustName;
                        emailContent.LastPayDate = LastPayDate;
                        emailContent.AmtBill = ListBill;
                        valEmail.SendEmail(emailContent);
                        break;
                    case 2:
                        emailContent.Name = "EM2";
                        emailContent.To = EmailID;
                        emailContent.ToUserName = CustName;
                        emailContent.LastPayDate = LastPayDate;
                        emailContent.AmtBill = ListBill;
                        valEmail.SendEmail(emailContent);
                        break;
                    case 3:
                        emailContent.Name = "EM3";
                        emailContent.To = EmailID;
                        emailContent.ToUserName = CustName;
                        emailContent.LastPayDate = LastPayDate;
                        emailContent.AmtBill = ListBill;
                        valEmail.SendEmail(emailContent);

                        break;
                    case 4:

                        emailContent.Name = "EM4";
                        emailContent.To = EmailID;
                        emailContent.ToUserName = CustName;
                        emailContent.LastPayDate = LastPayDate;
                        emailContent.AmtBill = ListBill;
                        emailContent.reminder = reminder.ToString();
                        valEmail.SendEmail(emailContent);

                        break;
                    case 5:

                        emailContent.Name = "EM5";
                        emailContent.To = EmailID;
                        emailContent.ToUserName = CustName;
                        emailContent.LastPayDate = LastPayDate;
                        emailContent.AmtBill = ListBill;
                        emailContent.reminder = reminder.ToString();
                        emailContent.Gadgets = Gadgets;
                        valEmail.SendEmail(emailContent);

                        break;
                    case 6:

                        emailContent.Name = "EM5";
                        emailContent.To = EmailID;
                        emailContent.ToUserName = CustName;
                        emailContent.LastPayDate = LastPayDate;
                        emailContent.AmtBill = ListBill;
                        emailContent.reminder = reminder.ToString();
                        emailContent.Gadgets = Gadgets;
                        valEmail.SendEmail(emailContent);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
