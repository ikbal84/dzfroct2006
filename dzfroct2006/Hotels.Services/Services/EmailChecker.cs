﻿using Hotels.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotels.Data.Services
{
    public static class EmailChecker
    {
        public static bool CheckIfEmailExists(String email)
        {
            using (var context = new UsersContext())
            {
                return context.UserProfiles.Where(user => user.eMail.Equals(email.ToLower())).Count() > 0;
            }
        }

        public static bool IsEmailValid(string email)
        {
            try
            {
                var EmailAddr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}