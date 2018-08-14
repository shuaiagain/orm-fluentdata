using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentData.Web.Filters;

using System.Web.Security;

namespace FluentData.Web.Controllers
{

    public class BaseController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = RedirectToAction("Login", "Account");
                return;
            }

            var cookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                filterContext.Result = RedirectToAction("Login", "Account");
                return;
            }

            var ticket = FormsAuthentication.Decrypt(cookie.Value);

        }
    }
}
