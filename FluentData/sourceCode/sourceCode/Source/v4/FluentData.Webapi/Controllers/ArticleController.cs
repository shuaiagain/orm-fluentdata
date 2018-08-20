using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using FluentData.Business;
using FluentData.Business.ViewModels;
using FluentData.Business.Service;

namespace FluentData.Webapi.Controllers
{
    public class ArticleController : ApiController
    {

        public object GetArticleList([FromUri]ArticleQuery query)
        {
            if (query == null) query = new ArticleQuery();
            PageVM<ArticleVM> pageVm = new ArticleService().GetArticlePageList(query);

            if (pageVm == null)
            {
                return new
                {
                    Code = -200,
                    Msg = "暂时数据",
                    Data = ""
                };
            }

            return new
            {
                Code = 200,
                Msg = "获取成功",
                Data = pageVm
            };
        }

        public object GetArticleLists([FromUri]ArticleQuery query)
        {
            if (query == null) query = new ArticleQuery();
            PageVM<ArticleVM> pageVm = new ArticleService().GetArticlePageList(query);

            if (pageVm == null)
            {
                return new
                {
                    Code = -200,
                    Msg = "暂时数据",
                    Data = ""
                };
            }

            return new
            {
                Code = 200,
                Msg = "获取成功",
                Data = pageVm
            };
        }

    }
}
