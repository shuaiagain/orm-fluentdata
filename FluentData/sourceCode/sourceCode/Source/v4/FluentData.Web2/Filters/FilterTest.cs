using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace FluentData.Web2.Filters
{
    public class FilterTest : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write(string.Format("<div> FilterTest  OnActionExecuting</div> {0}", 0));
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write(string.Format("<div> FilterTest  OnActionExecuted</div>  {0}", 1));
            base.OnActionExecuted(filterContext);
        }
    }

    public class FilterTestTwo : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write(string.Format("<div> FilterTestTwo  OnActionExecuting</div> {0}", 0));
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write(string.Format("<div> FilterTestTwo  OnActionExecuted</div>  {0}", 1));
            base.OnActionExecuted(filterContext);
        }
    }
}