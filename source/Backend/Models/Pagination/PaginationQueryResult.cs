using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models.Pagination
{
    public class PaginationQueryResult<T>
    {
        private int totalCount;

        private List<T> results = new List<T>();

        public int TotalCount
        {
            get
            {
                return totalCount;
            }
            set
            {
                totalCount = value;
            }
        }

        public List<T> Results
        {
            get
            {
                return results;
            }
        }
    }
}
