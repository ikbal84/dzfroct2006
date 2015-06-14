using Hotels.Data.Model;
using Hotels.Data.Services;
using Hotels.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMatrix.WebData;

namespace Hotels.Business
{
    public class HotelOwnerHandler
    {
        private HotelOwnerDAO dao;

        public HotelOwnerHandler()
        {
            dao = new HotelOwnerDAO();
        }
        public bool CreateOwner(HotelOwner Owner)
        {
            return dao.CreateNewOwner(Owner);
        }

        public HotelOwner getOwnerByID(long  Id)
        {

                return dao.getOwnerByIDFromDB(Id);

        }

        public HotelOwner getOwnerByName(String name)
        {

                return dao.getOwnerByNameFromDB(name);

        }

        public HotelOwner getOwnerByEmail(String email)
        {
                return dao.getOwnerByEmailFromDB(email);

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
            var Owner = getOwnerByEmail(email);
            await EmailSender.SendNewPassword(email, WebSecurity.GeneratePasswordResetToken(Owner.UserName), true);
        }
    }
}
