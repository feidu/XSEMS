using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models.Pagination;
using System.Web;

namespace Backend.Utilities
{
    public class PaginationHelper
    {
        public static PaginationQueryCondition GetCurrentPaginationQueryCondition(HttpRequest request)
        {
            int page = GetCurrentPage(request);
            int size = GetPageSize(request);
            PaginationQueryCondition condition = new PaginationQueryCondition(page, size);
            return condition;
        }

        public static int GetCurrentPage(HttpRequest request)
        {
            string pageString = request.QueryString[Constants.REQUEST_PAGE_NUMBER];
            if (pageString != null)
            {
                if (!Validator.IsMatchNumber(pageString))
                {
                    return Constants.PAGE_NUMBER_DEFAULT;
                }

                return Convert.ToInt16(pageString);
            }
            else
            {
                return Constants.PAGE_NUMBER_DEFAULT;
            }
        }

        public static int GetPageSize(HttpRequest request)
        {
            return GetPageSize(request, Constants.PAGE_SIZE_DEFAULT);
        }

        public static int GetPageSize(HttpRequest request, int defaultPageSize)
        {
            string pageString = request.QueryString[Constants.REQUEST_PAGE_SIZE];
            if (pageString != null)
            {
                if (!Validator.IsMatchNumber(pageString))
                {
                    return defaultPageSize;
                }

                return Convert.ToInt16(pageString);
            }
            else
            {
                return defaultPageSize;
            }
        }
    }
}
