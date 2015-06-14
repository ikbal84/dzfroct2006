using Hotels.Data.Services;
using Hotels.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using Hotels.Utils;
using WebMatrix.WebData;
using System.Threading.Tasks;


namespace Hotels.Business
{
    public class VisitorHandler
    {
        private VisitorDAO dao;

        public VisitorHandler()
        {
            dao = new VisitorDAO();
        }
        public bool CreateUser(Visitor visitor)
        {
                return dao.CreateNewVisitor(visitor);
        }

        public Visitor getVisitorByID(long  Id)
        {

                return dao.getVisitorByIDFromDB(Id);

        }

        public Visitor getVisitorByName(String name)
        {

                return dao.getVisitorByNameFromDB(name);

        }

        public Visitor getVisitorByEmail(String email)
        {
                return dao.getVisitorByEmailFromDB(email);

        }

        public string CreateConfirmationToken()
        {
            return Guid.NewGuid().ToString();
            
        }

        public async Task SendEmailConfirmation(string to, string confirmationToken)
        {
            await EmailSender.SendEmailConfirmation(to, confirmationToken);
        }

        public async Task SendEmailPwdForget(string email)
        {
            var Visitor = getVisitorByEmail(email);
            await EmailSender.SendNewPassword(email, WebSecurity.GeneratePasswordResetToken(Visitor.UserName), false);
        }

  
    }
}