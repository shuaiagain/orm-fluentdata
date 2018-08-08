using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using FluentData.Business.ViewModels;
using FluentData.Business.Utils;

namespace FluentData.Business.Service
{
    public class NoticeService
    {
        #region 获取通知列表(分页)
        /// <summary>
        /// 获取通知列表
        /// </summary>
        /// <returns></returns>
        public PageVM<NoticeVM> GetNoticeListPage(NoticeQuery query)
        {

            if (!query.PageIndex.HasValue)
                query.PageIndex = 1;
            if (!query.PageSize.HasValue)
                query.PageSize = 10;

            string sql = "select * from notice n where 1=1 ";
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
                List<NoticeVM> list = dbContext.Sql(sql + pageSql).QueryMany<NoticeVM,List<NoticeVM>>((no,reader) =>
                {
                    var noVM = new NoticeVM()
                    {
                        ID = reader.ID
                    };
                });

                list.ForEach(item =>
                {
                    if (!string.IsNullOrEmpty(item.AttachmentUrl))
                    {
                        var arr = HttpUtility.UrlDecode(item.AttachmentUrl).Split('>');
                        item.FilePath = arr.Length > 0 ? arr[0] : string.Empty;
                        item.FileName = arr.Length > 1 ? arr[1] : string.Empty;
                    }
                    else
                    {
                        item.FilePath = string.Empty;
                        item.FileName = string.Empty;
                    }
                });

                //获取数据总数
                //int totalCount = dbContext.Sql(sql).Query().Count;
                ////总页数
                //double totalPages = ((double)totalCount / query.PageSize.Value);

                PageVM<NoticeVM> pageVM = new PageVM<NoticeVM>();
                pageVM.Data = list;
                //pageVM.TotalCount = totalCount;
                //pageVM.TotalPages = (int)Math.Ceiling(totalPages);
                //pageVM.PageIndex = query.PageIndex;

                return pageVM;
            }
        }
        #endregion
    }
}
