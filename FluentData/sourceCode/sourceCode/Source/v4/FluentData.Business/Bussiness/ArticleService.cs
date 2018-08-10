using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using FluentData.Business.ViewModels;
using FluentData.Business.Utils;

namespace FluentData.Business.Service
{
    public class ArticleService
    {
        #region 获取通知列表(分页)
        /// <summary>
        /// 获取通知列表
        /// </summary>
        /// <returns></returns>
        public PageVM<ArticleVM> GetArticlePageList(ArticleQuery query)
        {
            if (!query.PageIndex.HasValue)
                query.PageIndex = 1;
            if (!query.PageSize.HasValue)
                query.PageSize = 8;

            string sql = "select * from article n where 1=1 ";
            if (!string.IsNullOrEmpty(query.KeyWord))
            {
                sql += string.Format(" and n.title like '%{0}%' ", query.KeyWord);
            }

            if (query.StartTime.HasValue)
            {
                sql += string.Format(" and date(n.UpdateTime) >= '{0}' ", query.StartTime);
            }

            if (query.EndTime.HasValue)
            {
                sql += string.Format(" and date(n.UpdateTime) <= '{0}' ", query.EndTime);
            }

            sql += " order by n.UpdateTime DESC,n.ID DESC ";
            string pageSql = string.Format(" Limit {0},{1}", (query.PageIndex - 1) * query.PageSize, query.PageSize);
            using (var dbContext = new DbContext().ConnectionStringName(ConnectionUtil.connWXB, new MySqlProvider()))
            {

                //获取指定页数据
                List<ArticleVM> list = dbContext.Sql(sql + pageSql).QueryMany<ArticleVM>((ArticleVM art, IDataReader reader) =>
                {
                    art.ID = reader.GetInt32("ID");
                    art.Title = reader.GetString("Title");
                    art.Content = reader.GetString("Content");
                    art.Inputer = reader.GetString("Inputer");
                    art.InputTime = reader.GetDateTime("InputTime");
                    art.UpdateTime = reader.GetDateTime("UpdateTime");
                    art.UpdateTimeStr = reader.GetDateTime("UpdateTime").ToString("yyyy-MM-dd");
                });

                //获取数据总数
                int totalCount = dbContext.Sql(sql).QueryMany<int>().Count;
                //总页数
                double totalPages = ((double)totalCount / query.PageSize.Value);

                PageVM<ArticleVM> pageVM = new PageVM<ArticleVM>();
                pageVM.Data = list;
                pageVM.TotalCount = totalCount;
                pageVM.TotalPages = (int)Math.Ceiling(totalPages);
                pageVM.PageIndex = query.PageIndex;

                return pageVM;
            }
        }
        #endregion
    }
}
