using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Hotels.Utils
{
    public static class EmailSender
    {
        public static async Task SendEmailConfirmation(string To, string ValidationToken)
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(ConfigurationManager.AppSettings["MailFrom"].ToString());
                mail.To.Add(To);
                mail.Subject = ConfigurationManager.AppSettings["MailSubject"].ToString();
                string ValidationLink = String.Format("{0}://{1}/mailvalidator?ConfirmationToken={2}", 
                                                        HttpContext.Current.Request.Url.Scheme,
                                                        HttpContext.Current.Request.Url.Authority,
                                                        ValidationToken);
                mail.Body = String.Format(ConfigurationManager.AppSettings["MailBody"].ToString(), ValidationLink);
                
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com"))
                {
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(
                                                    ConfigurationManager.AppSettings["MailUser"].ToString(),
                                                    ConfigurationManager.AppSettings["MailPwd"].ToString());
                    SmtpServer.EnableSsl = true;

                    await SmtpServer.SendMailAsync(mail);
                }
 

            }
            catch (Exception ex)
            {
                
            }
        }

        public static async Task SendNewPassword(string To, string PwdResetToken, bool forHotelOwner)
        {
            try
            {
                MailMessage mail = new MailMessage();
                
                mail.From = new MailAddress(ConfigurationManager.AppSettings["MailFrom"].ToString());
                mail.To.Add(To);
                mail.Subject = ConfigurationManager.AppSettings["MailPwdSubject"].ToString();

                string SiteLink = (forHotelOwner)? 
                                             String.Format("{0}://{1}/HotelOwnerAccount/ResertPassword?resettoken={2}",
                                             HttpContext.Current.Request.Url.Scheme,
                                             HttpContext.Current.Request.Url.Authority,
                                             PwdResetToken) :

                                             String.Format("{0}://{1}/Account/ResertPassword?resettoken={2}",
                                             HttpContext.Current.Request.Url.Scheme,
                                             HttpContext.Current.Request.Url.Authority,
                                             PwdResetToken);

                mail.Body = String.Format(ConfigurationManager.AppSettings["MailPwdBody"].ToString(), SiteLink);
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com"))
                {
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(
                                                    ConfigurationManager.AppSettings["MailUser"].ToString(),
                                                    ConfigurationManager.AppSettings["MailPwd"].ToString());
                    SmtpServer.EnableSsl = true;

                    await SmtpServer.SendMailAsync(mail);
                }

            }
            catch (Exception ex)
            {

            }
        }
        
    }
}