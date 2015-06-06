using dzfroct2006.DAL;
using dzfroct2006.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dzfroct2006.BLL
{
    public class EmailConfirmer
    {
        public Visitor getVisitorByToken(string token)
        {
            using (var context = new HotelsDBContext())
            {
                return context.Visitor.Where(v => v.ValidationToken.Equals(token)).First();
            }
        }

        public bool ConfirmVisitorEmail(String UserName)
        {
            try
            {
                using (var context = new HotelsDBContext())
                {
                    Visitor Visitor = context.Visitor.Where(v => v.UserName.Equals(UserName.Trim())).First();
                    if (Visitor != null)
                    {
                        Visitor.Valid = true;
                    }

                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}