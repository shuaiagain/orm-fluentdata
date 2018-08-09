using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FluentData.Business.Service;
using FluentData.Business.ViewModels;

namespace FluentData.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            PageVM<NoticeVM> data = new NoticeService().GetNoticeListPage(new NoticeQuery());
            return View(data);

        }

    }
}
