using Hotels.Data.Model;
using Hotels.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace dzfroct2006.Controllers
{
    public class mailvalidatorController : Controller
    {
        //
        // GET: /mailvalidator/

        public ActionResult Index(String ConfirmationToken)
        {
            VisitorDAO confirmer = new VisitorDAO();

            Visitor ConfirmingVisitor = confirmer.getVisitorByToken(ConfirmationToken);

            if (ConfirmingVisitor == null)
            {
                return RedirectToAction("ConfirmationError");
            }
            else
            {
                if (ConfirmingVisitor.Valid)
                {
                    return RedirectToAction("AlreadyConfirmed");
                }
                else
                {
                    TempData["token"] = ConfirmationToken;
                    TempData["user"] = ConfirmingVisitor.UserName;
                    return View();
                }
            }
            
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (WebSecurity.Login(model.UserName, model.Password))
            {
                if (TempData["user"].ToString().Equals(model.UserName.Trim()))
                {
                    VisitorDAO confirmer = new VisitorDAO();

                    confirmer.ConfirmVisitorEmail(model.UserName);
                    return RedirectToAction("ValidationSuccess");
                }
            }
            return RedirectToAction("ConfirmationError");
        }

        public ActionResult ConfirmationError()
        {
            return View();
        }

        public ActionResult AlreadyConfirmed()
        {
            return View();
        }

        public ActionResult ValidationSuccess()
        {
            return View();
        }


       
    }
}
