using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;


namespace dzfroct2006
{
    public class LanguageFilter : ActionFilterAttribute, IActionFilter
    {

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            
            var language =  System.Web.HttpContext.Current.Session["lang"];
            
            if(language == null)
            {
                var userLanguages = System.Web.HttpContext.Current.Request.UserLanguages;

                if (userLanguages.Count() > 0)
                {
                    try
                    {
                        language = userLanguages[0];
                        
                    }
                    catch (CultureNotFoundException)
                    {
                        language = "fr-fr";
                    }
                }
                else
                {
                    language = "fr-fr";
                }
                
            }
                        
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language.ToString());
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            System.Web.HttpContext.Current.Session["lang"] = language;

            //injection de la langue dans le cookie
            HttpCookie languageCookie = new HttpCookie("languageCookie");
            String langue = (String)language;
            languageCookie["lang"] = langue.Substring(0, 2);
            System.Web.HttpContext.Current.Response.Cookies.Add(languageCookie);


        }
    }
} 