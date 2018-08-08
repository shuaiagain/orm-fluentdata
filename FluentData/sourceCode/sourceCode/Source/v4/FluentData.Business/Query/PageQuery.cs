using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentData.Business.ViewModels
{
    public class PageQuery : BaseQuery
    {
        /// <summary>
        /// 当前第几页
        /// </summary>
        public int? PageIndex { get; set; }

        /// <summary>
        /// 每页大小
        /// </summary>
        public int? PageSize { get; set; }
    }
}
