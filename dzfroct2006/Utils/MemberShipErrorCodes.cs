using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Utils
{
    public static class MemberShipErrorCodes
    {
        public static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return Resources.LoginErrors.DuplicateUserName;

                case MembershipCreateStatus.DuplicateEmail:
                    return Resources.LoginErrors.DuplicateEmail;

                case MembershipCreateStatus.InvalidPassword:
                    return Resources.LoginErrors.InvalidPassword;

                case MembershipCreateStatus.InvalidEmail:
                    return Resources.LoginErrors.InvalidEmail;

                case MembershipCreateStatus.InvalidAnswer:
                    return Resources.LoginErrors.InvalidAnswer;

                case MembershipCreateStatus.InvalidQuestion:
                    return Resources.LoginErrors.InvalidQuestion;

                case MembershipCreateStatus.InvalidUserName:
                    return Resources.LoginErrors.InvalidUserName;

                case MembershipCreateStatus.ProviderError:
                    return Resources.LoginErrors.ProviderError;

                case MembershipCreateStatus.UserRejected:
                    return Resources.LoginErrors.UserRejected;

                default:
                    return Resources.LoginErrors.UnknownError;
            }
        }
    }
}
