using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using FluentData.Business;
using FluentData.Business.ViewModels;
using FluentData.Business.Service;
using System.Text;

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

        public object GetBase64Decode(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
            {
                return new
                {
                    Code = -400,
                    Msg = "参数不能为空",
                    Data = ""
                };
            }

            byte[] bytes = Convert.FromBase64String(base64String);

            return new
            {
                Code = 200,
                Msg = "获取成功",
                Data = new
                {
                    Source = Encoding.UTF8.GetString(bytes)
                }
            };
        }

        public string EncodeBase64(string source)
        {

            if (string.IsNullOrEmpty(source)) return "";

            byte[] bytes = Encoding.UTF8.GetBytes(source);

            return Convert.ToBase64String(bytes);
        }

        public string DecodeBase64(string base64String)
        {
            if (string.IsNullOrEmpty(base64String)) return "";

            byte[] bytes = Convert.FromBase64String(base64String);

            return Encoding.UTF8.GetString(bytes);
        }
    }
}
