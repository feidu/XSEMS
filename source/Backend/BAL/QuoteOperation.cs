using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.Models.Pagination;
using Backend.DAL;

namespace Backend.BAL
{
    public class QuoteOperation
    {
        private static readonly QuoteDAL dal = new QuoteDAL();

        public static void CreateQuote(Quote quote)
        {
            dal.CreateQuote(quote);
        }

        public static Quote GetQuoteById(int id)
        {
            return dal.GetQuoteById(id);
        }

        public static Quote GetQuoteByEncode(string encode)
        {
            return dal.GetQuoteByEncode(encode);
        }

        public static void UpdateQuote(Quote quote)
        {
            dal.UpdateQuote(quote);
        }

        public static void UpdateQuoteStatus(Quote quote)
        {
            dal.UpdateQuoteStatus(quote);
        }

        public static void UpdateQuoteAuditInfo(Quote quote)
        {
            dal.UpdateQuoteAuditInfo(quote);
        }

        public static void DeleteQuoteById(int id)
        {
            dal.DeleteQuoteById(id);
            dal.DeleteQuoteDetailByQuoteId(id);
        }

        public static void DeleteQuoteByIds(string ids)
        {
            string[] array = ids.Split(',');
            foreach (string sId in array)
            {
                int id = 0;
                if(int.TryParse(sId, out id))
                {
                    dal.DeleteQuoteById(id);
                    dal.DeleteQuoteDetailByQuoteId(id);
                }
            }
        }

        public static PaginationQueryResult<Quote> GetQuoteByCompanyId(PaginationQueryCondition condition, int compId)
        {
            return dal.GetQuoteByCompanyId(condition, compId);
        }

        public static PaginationQueryResult<Quote> GetQuoteByParameters(PaginationQueryCondition condition, int compId, DateTime startDate, DateTime endDate, string strStatus, string keyword)
        {
            return dal.GetQuoteByParameters(condition, compId, startDate, endDate, strStatus, keyword);
        }

        public static List<QuoteDetail> GetQuoteDetailByQuoteId(int id)
        {
            return dal.GetQuoteDetailByQuoteId(id);
        }

        public static void DeleteQuoteDetailByQuoteId(int quoteId)
        {
            dal.DeleteQuoteDetailByQuoteId(quoteId);
        }

        public static void DeleteQuoteDetailByIds(string ids)
        {
            string[] array = ids.Split(',');
            foreach (string sId in array)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeleteQuoteDetailById(id);
                }
            }
        }

        public static void CreateQuoteDetail(QuoteDetail qd)
        {
            dal.CreateQuoteDetail(qd);
        }

        public static void UpdateQutoeDetail(QuoteDetail qd)
        {
            dal.UpdateQutoeDetail(qd);
        }

        public static QuoteDetail GetQuoteDetailById(int id)
        {
            return dal.GetQuoteDetailById(id);
        }

        public static void UpdateQutoeDetailStatusByQuoteId(int quoteId)
        {
            dal.UpdateQutoeDetailStatusByQuoteId(quoteId);
        }
    }
}
