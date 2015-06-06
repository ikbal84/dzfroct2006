using dzfroct2006.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dzfroct2006.DAL
{
    public class VisitorDAO: IDisposable
    {

        public VisitorDAO()
        {

        }

        public bool CreateNewVisitor(Visitor NewVisitor)
        {
            try
            {
                using (var context = new HotelsDBContext())
                {
                    context.Visitor.Add(new Visitor
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

        public Visitor getVisitorByIDFromDB(long Id)
        {
            using (var context = new HotelsDBContext())
            {
                return context.Visitor.Where(v => v.ID.Equals(Id)).First();
            }
            
        }

        public Visitor getVisitorByNameFromDB(String UserName)
        {
            using (var context = new HotelsDBContext())
            {
                return context.Visitor.Where(v => v.UserName.Equals(UserName)).First();
            }
        }

        public Visitor getVisitorByEmailFromDB(String Email)
        {
            using (var context = new HotelsDBContext())
            {
                return context.Visitor.Where(v => v.ID.Equals(Email)).First();
            }
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}