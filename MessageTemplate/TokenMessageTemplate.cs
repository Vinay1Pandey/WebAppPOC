using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using BSNLEntity;

namespace MessageTemplate
{
    public class TokenMessageTemplate
    {
        private string ccAddress;
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["BSNLContext"].ConnectionString;
        }

        string ReplaceTokens(string template, Dictionary<string, string> replacements)
        {
            var rex = new Regex(@"\${([^}]+)}");
            return (rex.Replace(template, delegate (Match m)
            {
                string key = m.Groups[1].Value;
                string rep = replacements.ContainsKey(key) ? replacements[key] : m.Value;
                return (rep);
            }));
        }

        public void SendEmail(EmailTemplate valemail)
        {
            string token;
            Dictionary<string, string> dict = new Dictionary<string, string>();
            switch (valemail.Name)
            {
                case "EM1":
                    MessageTemplate(ref valemail);
                    dict.Add("Name", valemail.ToUserName);
                    dict.Add("LastPayDate", valemail.LastPayDate);
                    dict.Add("AmtBill", valemail.AmtBill);
                    dict.Add("FORUMNAME", "BSNL");
                    token = ReplaceTokens(valemail.Body, dict);
                    valemail.Body = token;
                    send(ConfigurationManager.AppSettings["FromEmail"].ToString(), valemail.To, valemail.Subject, token);
                    break;

                case "EM2":
                    MessageTemplate(ref valemail);
                    dict.Add("Name", valemail.ToUserName);
                    dict.Add("LastPayDate", valemail.LastPayDate);
                    dict.Add("AmtBill", valemail.AmtBill);
                    dict.Add("FORUMNAME", "BSNL");
                    token = ReplaceTokens(valemail.Body, dict);
                    valemail.Body = token;
                    send(ConfigurationManager.AppSettings["FromEmail"].ToString(), valemail.To, valemail.Subject, token);
                    break;

                case "EM3":
                    MessageTemplate(ref valemail);
                    dict.Add("Name", valemail.ToUserName);
                    dict.Add("LastPayDate", valemail.LastPayDate);
                    dict.Add("AmtBill", valemail.AmtBill);
                    dict.Add("FORUMNAME", "BSNL");
                    token = ReplaceTokens(valemail.Body, dict);
                    valemail.Body = token;
                    send(ConfigurationManager.AppSettings["FromEmail"].ToString(), valemail.To, valemail.Subject, token);
                    break;

                case "EM4":
                    MessageTemplate(ref valemail);
                    dict.Add("Name", valemail.ToUserName);
                    dict.Add("LastPayDate", valemail.LastPayDate);
                    dict.Add("AmtBill", valemail.AmtBill);
                    dict.Add("reminder", valemail.reminder);
                    dict.Add("FORUMNAME", "BSNL");
                    token = ReplaceTokens(valemail.Body, dict);
                    valemail.Body = token;
                    send(ConfigurationManager.AppSettings["FromEmail"].ToString(), valemail.To, valemail.Subject, token);
                    break;

                case "EM5":
                    MessageTemplate(ref valemail);
                    dict.Add("Name", valemail.ToUserName);
                    dict.Add("LastPayDate", valemail.LastPayDate);
                    dict.Add("AmtBill", valemail.AmtBill);
                    dict.Add("reminder", valemail.reminder);
                    dict.Add("Gadgets", valemail.Gadgets);
                    dict.Add("FORUMNAME", "BSNL");
                    token = ReplaceTokens(valemail.Body, dict);
                    valemail.Body = token;
                    send(ConfigurationManager.AppSettings["FromEmail"].ToString(), valemail.To, valemail.Subject, token);
                    break;

                case "EM6":
                    MessageTemplate(ref valemail);
                    dict.Add("Name", valemail.ToUserName);
                    dict.Add("LastPayDate", valemail.LastPayDate);
                    dict.Add("AmtBill", valemail.AmtBill);
                    dict.Add("reminder", valemail.reminder);
                    dict.Add("Gadgets", valemail.Gadgets);
                    dict.Add("FORUMNAME", "BSNL");
                    token = ReplaceTokens(valemail.Body, dict);
                    valemail.Body = token;
                    send(ConfigurationManager.AppSettings["FromEmail"].ToString(), valemail.To, valemail.Subject, token);
                    break;
            }

        }

        private void MessageTemplate(ref EmailTemplate valemail)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            string SqlString = "SELECT TemplateID, Name, ccEmailAddress, Subject, Body, IsActive FROM  [dbo].[EmailTemplates] Where Name = '" + valemail.Name + "'";

            using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
            {
                SqlConn.Open();
                SqlDataReader reader = SqlCom.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        valemail.Subject = Convert.ToString(reader["Subject"]);
                        valemail.Body = Convert.ToString(reader["Body"]);
                        valemail.ccEmailAddress = Convert.ToString(reader["ccEmailAddress"]);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void send(string fromAddress, string toAddress, string subject, string body)
        {
            try
            {
                const string fromPassword = "incorrect@gic";

                var smtp = new SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.Timeout = 20000;

                }
                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.From = new MailAddress(fromAddress, "BSNL Team");
                if (!string.IsNullOrEmpty(ccAddress))
                {
                    string[] CCAddr = ccAddress.Split(',');
                    foreach (string add in CCAddr)
                    {
                        mail.CC.Add(add);
                    }

                }
                mail.To.Add(toAddress);
                mail.Subject = subject;
                mail.Body = body;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
