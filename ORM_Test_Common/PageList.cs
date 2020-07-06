using System;
using System.Collections.Generic;

namespace ORM_Test_Common
{
    /// <summary>
    /// 分页实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageList<T>
    {
        /// <summary>
        /// 记录查询状态
        /// </summary>
        
        public bool Status { get; set; } = true;

        /// <summary>
        /// 返回提示
        /// </summary>
        
        public string Message { get; set; } = "查询分页数据成功";

        /// <summary>
        /// 页记录数
        /// </summary>
        
        public int PageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        
        public int TotalCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        
        public int TotalPageCount
        {
            get
            {
                return (int)Math.Ceiling(TotalCount / ((double)PageSize));
            }
        }

        /// <summary>
        /// 当前页索引
        /// </summary>
        
        public int CurrentIndex { get; set; }

        /// <summary>
        /// 开始记录位置
        /// </summary>
        
        public int StartRecordIndex
        {
            get
            {
                return ((CurrentIndex - 1) * this.PageSize) + 1;
            }
        }

        /// <summary>
        /// 结束记录位置
        /// </summary>
        
        public int EndRecordIndex
        {
            get
            {
                return ((TotalCount > (CurrentIndex * PageSize)) ? CurrentIndex * PageSize : TotalCount);
            }
        }

        /// <summary>
        /// 查询到的结果集
        /// </summary>
        public List<T> RecordList { get; set; }

        /// <summary>
        /// 查询到的记录数
        /// </summary>
        public int Count
        {
            get
            {
                return RecordList.Count;
            }
        }

        public PageList()
        {
            PageSize = 0;
            CurrentIndex = 0;
            TotalCount = 0;
            RecordList = new List<T>();
        }

        public PageList(int pageIndex, int pageSize = 0)
        {
            CurrentIndex = 0;
            PageSize = 0;
            TotalCount = 0;
            CurrentIndex = pageIndex;
            PageSize = pageSize;
            RecordList = new List<T>();
        }
    }
}
