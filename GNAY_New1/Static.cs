using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace GNAY_New1
{
    public class Static
    {
        

        static bool mailSent = false;
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            //if (e.Cancelled)
            //{
            //    Console.WriteLine("[{0}] Send canceled.", token);
            //}
            //if (e.Error != null)
            //{
            //    Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            //}
            //else
            //{
            //    Console.WriteLine("Message sent.");
            //}
            mailSent = true;
        }
        public static void SendEmail(string subject, string emailbody, string toEMAIL)
        {
            if (ConfigurationManager.AppSettings["sendemail"].ToUpper() == "FALSE")
                return;
            string fromemail = ConfigurationManager.AppSettings["fromemail"];
            string frompassword = ConfigurationManager.AppSettings["frompassword"];
            string toemail = ConfigurationManager.AppSettings["toemail"];

            if (toEMAIL == "" || toEMAIL==null)
            {
                toEMAIL = toemail;
            }

            string smtp = ConfigurationManager.AppSettings["smtp"];
            string port = ConfigurationManager.AppSettings["port"];
            string deploymentmode = ConfigurationManager.AppSettings["deploymentmode"];

            if (deploymentmode == "debug") // debug mode // below debug code not working
            {
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                string msg = string.Empty;
                try
                {
                    MailAddress fromAddress = new MailAddress(fromemail);
                    message.From = fromAddress;
                    message.To.Add(toEMAIL);
                    if (toEMAIL != "" && toEMAIL != null)
                    {
                        message.Bcc.Add(toemail);
                    }
                    message.Subject = subject;
                    message.IsBodyHtml = true;
                    message.Body = emailbody;
                    smtpClient.Host = smtp;// "relay-hosting.secureserver.net";   //-- Donot change.
                    smtpClient.Port = Convert.ToInt32(port);// 25 //--- Donot change
                    smtpClient.EnableSsl = false;//--- Donot change
                    //smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential(fromemail, frompassword);
                    smtpClient.Send(message);
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
            else //godaddy deployed code
            {

                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromemail);

                message.To.Add(new MailAddress(toEMAIL));
                if (toEMAIL != "" && toEMAIL != null)
                {
                    message.Bcc.Add(new MailAddress(toemail));
                }

                message.Subject = subject;
                message.Body = emailbody;
                message.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();
                //client.SendCompleted += new
                //    SendCompletedEventHandler(SendCompletedCallback);
                //string userState = "Email alert";
                //client.SendAsync(message, userState);
                client.Send(message);
            }


        }
    }
}