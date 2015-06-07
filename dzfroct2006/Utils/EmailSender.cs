using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace dzfroct2006.Utils
{
    public static class EmailSender
    {
        public static void Send(string To, string ValidationToken)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(ConfigurationManager.AppSettings["MailFrom"].ToString());
                mail.To.Add(To);
                mail.Subject = ConfigurationManager.AppSettings["MailSubject"].ToString();
                string ValidationLink = String.Format("{0}://{1}/mailvalidator?ConfirmationToken={2}", 
                                                        HttpContext.Current.Request.Url.Scheme,
                                                        HttpContext.Current.Request.Url.Authority,
                                                        ValidationToken);
                mail.Body = String.Format(ConfigurationManager.AppSettings["MailBody"].ToString(), ValidationLink);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(
                                                ConfigurationManager.AppSettings["MailUser"].ToString(),
                                                ConfigurationManager.AppSettings["MailPwd"].ToString());
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
                
            }
        }
        
    }
}