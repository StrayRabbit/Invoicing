using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 分页逻辑处理类
    /// </summary>
    public class PageCollection
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// 当前页面
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// 每页的记录数
        /// </summary>
        public int OnePageSize { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public long TotalRows { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// 构造无参默认为最大数
        /// </summary>
        public PageCollection()
        {
            this.CurrentPage = 0;
            this.OnePageSize = 20;//默认最大行数20条
        }
    }
    /// <summary>
    /// 分页逻辑处理类 linq to entites
    /// </summary>
    public class PageInfo<TEntity> where TEntity : class
    {
        public PageInfo(int index, int pageSize, int count, List<TEntity> list, string url = "")
        {
            Index = index;
            PageSize = pageSize;
            Count = count;
            List = list;
            Url = url;
            //计算数据条数从开始到结束的值
            if (count == 0)
            {
                BeginPage = 0;
                EndPage = 0;
            }
            else
            {
                int maxpage = count / pageSize;

                if (count % pageSize > 0)
                {
                    maxpage++;
                }
                if (index >= maxpage)
                {
                    index = maxpage;

                    BeginPage = pageSize * index - pageSize + 1;
                    EndPage = count;
                }
                else
                {
                    BeginPage = pageSize * index - pageSize + 1;
                    EndPage = pageSize * index;
                }
            }
        }

        public int Index { get; private set; }
        public int PageSize { get; private set; }
        public int Count { get; private set; }
        public List<TEntity> List { get; set; }
        public string Url { get; set; }
        public int BeginPage { get; private set; }
        public int EndPage { get; private set; }
    }

    /// <summary>
    /// 分页逻辑处理类 dynamic
    /// </summary>
    public class PageInfo
    {
        public PageInfo(int index, int pageSize, int count, dynamic list, string url = "")
        {
            Index = index;
            PageSize = pageSize;
            Count = count;
            List = list;
            Url = url;
            //计算数据条数从开始到结束的值
            if (count == 0)
            {
                BeginPage = 0;
                EndPage = 0;
            }
            else
            {
                int maxpage = count / pageSize;

                if (count % pageSize > 0)
                {
                    maxpage++;
                }
                if (index >= maxpage)
                {
                    index = maxpage;

                    BeginPage = pageSize * index - pageSize + 1;
                    EndPage = count;
                }
                else
                {
                    BeginPage = pageSize * index - pageSize + 1;
                    EndPage = pageSize * index;
                }
            }
        }

        public int Index { get; private set; }
        public int PageSize { get; private set; }
        public int Count { get; private set; }
        public dynamic List { get; private set; }
        public string Url { get; set; }
        public int BeginPage { get; private set; }
        public int EndPage { get; private set; }
    }

    /// <summary>
    /// Eazyui分页处理逻辑类
    /// </summary>
    public class PageEazyUi
    {
        public PageEazyUi(int _page, int _pagesize, int _total, object _rows)
        {
            page = _page;
            pagesize = _pagesize;
            total = _total;
            rows = _rows;
        }

        public int page { get; private set; }
        public int pagesize { get; private set; }
        public int total { get; private set; }
        public object rows { get; private set; }
    }
}