using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;
using Backend.Models.Pagination;

namespace Backend.BAL
{
    public class NewsOperation
    {
        private static readonly NewsDAL dal = new NewsDAL();

        public static void CreateNewsCategory(NewsCategory cat)
        {
            dal.CreateNewsCategory(cat);
        }

        public static List<NewsCategory> GetNewsCategory()
        {
            return dal.GetNewsCategory();
        }

        public static void UpdateNewCategory(NewsCategory nc)
        {
            dal.UpdateNewsCategory(nc);
        }

        public static NewsCategory GetNewsCategoryById(int id)
        {
            return dal.GetNewsCategoryById(id);
        }

        public static void DeleteNewsCategoryByIds(string ids)
        {
            if (ids == null) return;
            string[] array = ids.Split(',');
            foreach (string sId in array)
            {
                int id = 0;
                if(int.TryParse(sId,out id))
                {
                    dal.DeleteNewsCategoryById(id);
                }
            }

        }

        public static PaginationQueryResult<News> GetNews(PaginationQueryCondition condition)
        {
            return dal.GetNews(condition);
        }

        public static PaginationQueryResult<News> GetNewsByCategoryId(PaginationQueryCondition condition, int catId)
        {
            return dal.GetNewsByCategoryId(condition, catId);
        }

        public static List<News> GetNewsByCategoryId(int catId, int amount)
        {
            return dal.GetNewsByCategoryId(catId, amount);
        }

        public static List<News> GetNewsByCategoryId(int catId)
        {
            return dal.GetNewsByCategoryId(catId);
        }

        public static News GetNewsById(int id)
        {
            return dal.GetNewsById(id);
        }

        public static void CreateNews(News news)
        {
            dal.CreateNews(news);
        }

        public static void UpdateNews(News news)
        {
            dal.UpdateNews(news);
        }

        public static void DeleteNewsByIds(string  ids)
        {
            if (ids == null)
            {
                return;
            }
            string[] array = ids.Split(',');
            foreach(string sId in array)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeleteNewsById(id);
                }
            }
                
        }
    }
}
