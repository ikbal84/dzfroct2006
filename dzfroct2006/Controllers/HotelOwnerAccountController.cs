using dzfroct2006.Models;
using Hotels.Business;
using Hotels.Data.Model;
using Hotels.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Utils;
using WebMatrix.WebData;

namespace dzfroct2006.Controllers
{
    public class HotelOwnerAccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult login()
        {
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult login(LoginModel model)
        {
              if (ModelState.IsValid && IsHotelOwner(model.UserName))
            {
                if (WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", Resources.LoginErrors.LoginFailed);
                    
                }
                
            }

              ModelState.AddModelError("", Resources.LoginErrors.InvalidUserName);  
              return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult RegisterHotelOwner()
        {
            UsersContext context = new UsersContext();

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> RegisterHotelOwner(RegisterModel model)
        {
            if (EmailChecker.CheckIfEmailExists(model.eMail.ToLower()))
            {
                ModelState.AddModelError("EmailExisting", Resources.LoginErrors.EmailExisting);
            }

            if (!EmailChecker.IsEmailValid(model.eMail.ToLower()))
            {
                ModelState.AddModelError("InvalidEmail", Resources.LoginErrors.InvalidEmail);
            }

            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    HotelOwnerHandler OwnerHdl = new HotelOwnerHandler();

                    HotelOwner NewOwner = new HotelOwner
                    {
                        UserName = model.UserName.Trim(),
                        Email = model.eMail.ToLower(),
                        LastName = (String.IsNullOrEmpty(model.UserLastName)) ? null : model.UserLastName.ToLower().Trim(),
                        FirstName = (String.IsNullOrEmpty(model.UserFirstName)) ? null : model.UserFirstName.ToLower().Trim(),
                        ValidationToken = OwnerHdl.CreateConfirmationToken(),
                    };

                    WebSecurity.CreateUserAndAccount(NewOwner.UserName,
                                                     model.Password,
                                                     propertyValues: new { eMail = model.eMail }
                                                     );
                    Roles.AddUsersToRoles(new String[] { NewOwner.UserName }, new String[] { "HotelOwner" });

                    WebSecurity.Login(model.UserName, model.Password);

                    OwnerHdl.CreateOwner(NewOwner);
                    
                    //send the mail asynchrone....
                    await OwnerHdl.SendEmailConfirmation(NewOwner.Email, NewOwner.ValidationToken);

                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", MemberShipErrorCodes.ErrorCodeToString(e.StatusCode));
                }
                catch (Exception exp)
                {
                    
                }
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult PasswordForgoten()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> PasswordForgoten(FormCollection inputs)
        {
            string email = inputs["email"].ToString().ToLower();
            if (!EmailChecker.IsEmailValid(email))
            {
                ModelState.AddModelError("emailError", Resources.LoginErrors.InvalidEmail);
            }

            HotelOwnerHandler HotelHdl = new HotelOwnerHandler();

            if (HotelHdl.getOwnerByEmail(email) == null || !EmailChecker.CheckIfEmailExists(email))
            {
                ModelState.AddModelError("emailError", Resources.LoginErrors.InvalidEmail);
            }

            if (ModelState.IsValid)
            {
                await HotelHdl.SendEmailPwdForget(email);
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(string resettoken)
        {
            ResetPasswordModel model = new ResetPasswordModel();
            model.Resettoken = resettoken;
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordModel ResetModel)
        {
            if (ModelState.IsValid)
            {
                int UserIDInProfileDB = WebSecurity.GetUserIdFromPasswordResetToken(ResetModel.Resettoken);

                if (UserIDInProfileDB == WebSecurity.GetUserId(ResetModel.UserName))
                {
                    WebSecurity.ResetPassword(ResetModel.Resettoken, ResetModel.NewPassword);
                    return RedirectToAction("Login", "HotelOwnerAccount");
                }
                else
                {
                    ModelState.AddModelError("", Resources.LoginErrors.InvalidUserName);
                }


            }

            return View();
        }

        private bool IsHotelOwner(string UserName)
        {
            HotelOwnerHandler HotelHdl = new HotelOwnerHandler();
            return (HotelHdl.getOwnerByName(UserName) != null)? true : false;
        }
    }
}
