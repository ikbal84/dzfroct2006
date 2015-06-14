using Hotels.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Data.Services
{
    public class HotelOwnerDAO
    {
        public HotelOwnerDAO()
        {

        }

        public bool CreateNewOwner(HotelOwner NewVisitor)
        {
            try
            {
                using (var context = new HotelsDBContext())
                {
                    context.Owner.Add(new HotelOwner
                    {
                        LastName = NewVisitor.LastName,
                        FirstName = NewVisitor.FirstName,
                        UserName = NewVisitor.UserName,
                        Email = NewVisitor.Email,
                        Address = NewVisitor.Address,
                        PhoneNumber = NewVisitor.PhoneNumber,
                        Valid = false,
                        ValidationToken = NewVisitor.ValidationToken,
                        CreationDate = (NewVisitor.CreationDate == DateTime.MinValue) ? DateTime.Now : NewVisitor.CreationDate,
                        LastUpdateDate = DateTime.Now
                    });
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public HotelOwner getOwnerByIDFromDB(long Id)
        {
            using (var context = new HotelsDBContext())
            {
                return context.Owner.Where(o => o.OwnerID.Equals(Id)).FirstOrDefault();
            }

        }

        public HotelOwner getOwnerByNameFromDB(String UserName)
        {
            using (var context = new HotelsDBContext())
            {
                return context.Owner.Where(o => o.UserName.Equals(UserName)).FirstOrDefault();
            }
        }

        public HotelOwner getOwnerByEmailFromDB(String Email)
        {
            using (var context = new HotelsDBContext())
            {
                return context.Owner.Where(o => o.Email.Equals(Email)).FirstOrDefault();
            }
        }

        public HotelOwner getOwnerByToken(string token)
        {
            var context = new HotelsDBContext();
            return context.Owner.Where(o => o.ValidationToken.Equals(token)).FirstOrDefault();
        }

        public bool ConfirmOwnerEmail(String UserName)
        {
            try
            {
                var context = new HotelsDBContext();

                HotelOwner Owner = context.Owner.Where(o => o.UserName.Equals(UserName.Trim())).FirstOrDefault();
                if (Owner != null)
                {
                    Owner.Valid = true;
                }

                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
