using dzfroct2006.DAL;
using dzfroct2006.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace dzfroct2006.BLL
{
    public class VisitorHandler
    {
        public bool CreateUser(Visitor visitor)
        {
            //using (VisitorDAO dao = new VisitorDAO())
            //{
            VisitorDAO dao = new VisitorDAO();
                return dao.CreateNewVisitor(visitor);
            //}
            
        }

        public Visitor getVisitorByID(long  Id)
        {
            using (VisitorDAO dao = new VisitorDAO())
            {
                return dao.getVisitorByIDFromDB(Id);
            }
        }

        public Visitor getVisitorByName(String name)
        {
            using (VisitorDAO dao = new VisitorDAO())
            {
                return dao.getVisitorByNameFromDB(name);
            }
        }

        public Visitor getVisitorByEmail(String email)
        {
            using (VisitorDAO dao = new VisitorDAO())
            {
                return dao.getVisitorByEmailFromDB(email);
            }
        }

        public string CreateConfirmationToken()
        {
            return Guid.NewGuid().ToString();
            
        }

        public void SendEmailConfirmation(string to, string username, string confirmationToken)
        {
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(to));
            email.From = new MailAddress("HotelsOfAlgeria@hoa.com");
            email.Subject = "HotelsOfAlgeria - Email Confirmation";
            string linkForValidation = "localhost/mailvalidator/" + confirmationToken;
            email.Body = "Bonjour " + username + 
                        ", \n Merci de Cliquer sur le lien pour valider votre inscription :" + linkForValidation;
            
           // email.Send();
        }
    }
}