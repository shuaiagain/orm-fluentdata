using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FluentData.Business.Service;
using FluentData.Business.ViewModels;
using FluentData.Web2.Filters;

namespace FluentData.Web2.Controllers
{
    [AuthFilters]
    public class HomeController : Controller
    {
        #region Index
     
        public ActionResult Index()
        {
            PageVM<ArticleVM> data = new ArticleService().GetArticlePageList(new ArticleQuery());
            return View(data);
        }
        #endregion

        #region GetArticlePageList
        public ActionResult GetArticlePageList(ArticleQuery query)
        {
            if (query == null) query = new ArticleQuery();

            if (!query.PageIndex.HasValue)
                query.PageIndex = 1;
            if (!query.PageSize.HasValue)
                query.PageSize = 8;

            PageVM<ArticleVM> list = new ArticleService().GetArticlePageList(query);
            if (list == null || list.Data == null || list.Data.Count == 0)
            {
                return Json(new
                {
                    Code = -200,
                    Msg = "暂无数据"
                });
            }

            return Json(new
            {
                Code = 200,
                Msg = "获取成功",
                Data = list
            });
        }
        #endregion
    }
}
