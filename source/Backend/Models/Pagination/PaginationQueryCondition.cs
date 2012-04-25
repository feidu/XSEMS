using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models.Pagination
{
    public enum PaginationQuerySortDirection
    {
        DESC, ASC
    }

    public enum PaginationQuerySearchMode
    {
        LIKE,
        EXACT
    }

    public class PaginationQueryCondition
    {
        public PaginationQueryCondition()
        {
        }

        public PaginationQueryCondition(int page, int pagesize)
        {
            this.currentPage = page;
            this.pageSize = pagesize;
        }

        public PaginationQueryCondition(int page, int pagesize, string sort, PaginationQuerySortDirection dir)
        {
            this.currentPage = page;
            this.pageSize = pagesize;
            this._SortColumn = sort;
            this._SortDirection = dir;
        }


        private int currentPage = 1;

        private int pageSize;

        public int CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                if (value < 1)
                {
                    currentPage = 1;
                }
                else
                {
                    currentPage = value;
                }
            }
        }

        private string _SortColumn;

        public string SortColumn
        {
            get { return _SortColumn; }
            set { _SortColumn = value; }
        }

        private PaginationQuerySortDirection _SortDirection;

        public PaginationQuerySortDirection SortDirection
        {
            get { return _SortDirection; }
            set { _SortDirection = value; }
        }
	

        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value;
            }
        }
    }
}
