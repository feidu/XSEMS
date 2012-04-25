using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Models.Pagination;
using Backend.Utilities;

namespace Backend.DAL
{
    public class NewsDAL
    {
        public void CreateNewsCategory(NewsCategory nc)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@name",100,nc.Name),
                SqlUtilities.GenerateInputNVarcharParameter("@remark",400,nc.Remark)         
            };

            string sql = "INSERT INTO news_categories (name, remark) VALUES (@name,@remark)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public List<NewsCategory> GetNewsCategory()
        {
            string sql = "SELECT id, name, remark FROM news_categories";
            List<NewsCategory> result = new List<NewsCategory>();
            using(SqlDataReader dr=SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while(dr.Read())
                {
                    NewsCategory nc=new NewsCategory();
                    nc.Id=dr.GetInt32(0);
                    nc.Name=dr.GetString(1);
                    nc.Remark=dr.GetString(2);
                    result.Add(nc);
                }
            }
            return result;
        }

        public NewsCategory GetNewsCategoryById(int id)
        {
            NewsCategory nc = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id",id)
            };
            string sql = "SELECT id, name, remark FROM news_categories WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    nc = new NewsCategory();
                    nc.Id = dr.GetInt32(0);
                    nc.Name = dr.GetString(1);
                    nc.Remark = dr.GetString(2);
                }
            }
            return nc;
        }

        public void UpdateNewsCategory(NewsCategory nc)
        {
            SqlParameter[] param = new SqlParameter[] {
                SqlUtilities.GenerateInputIntParameter("@id", nc.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@name",100,nc.Name),
                SqlUtilities.GenerateInputNVarcharParameter("@remark",400,nc.Remark)   
            };
            string sql = "UPDATE news_categories SET name = @name , remark = @remark WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteNewsCategoryById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id",id)
            };
            string sql = "DELETE FROM news_categories WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public PaginationQueryResult<News> GetNews(PaginationQueryCondition condition)
        {
            
            PaginationQueryResult<News> result = new PaginationQueryResult<News>();

            string sql = "SELECT TOP " + condition.PageSize + " news.id, title, content, create_time, news.category_id, news_categories.name FROM news INNER JOIN news_categories ON (news_categories.id = news.category_id) ";
            if (condition.CurrentPage > 1)
                sql += " WHERE news.id<(SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " news.id FROM news INNER JOIN news_categories ON (news_categories.id = news.category_id)  ORDER BY news.id DESC) AS D)";
            sql += " ORDER BY news.id DESC; SELECT COUNT(*) FROM news INNER JOIN news_categories ON (news_categories.id = news.category_id)";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    News news = new News();
                    news.Id = dr.GetInt32(0);
                    news.Title = dr.GetString(1);
                    news.Content = dr.GetString(2);
                    news.CreateTime = dr.GetDateTime(3);
                    news.Category = new NewsCategory();
                    news.Category.Id = dr.GetInt32(4);
                    news.Category.Name = dr.GetString(5);

                    result.Results.Add(news);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }


        public void CreateNews(News news)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@title", 100, news.Title),
                SqlUtilities.GenerateInputParameter("@content", SqlDbType.Text, news.Content),
                SqlUtilities.GenerateInputIntParameter("@category_id", news.Category.Id),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", news.CreateTime),
                SqlUtilities.GenerateInputParameter("@is_display", SqlDbType.Bit, news.IsDisplay)
            };
            string sql = "INSERT INTO news(title, content, category_id, create_time, is_display) VALUES (@title, @content, @category_id, @create_time, @is_display)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);

        }

        public News GetNewsById(int id)
        {
            News news = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };

            string sql = "SELECT id, title ,content ,create_time, is_display, category_id FROM news WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    news = new News();
                    news.Id = dr.GetInt32(0);
                    news.Title = dr.GetString(1);
                    news.Content = dr.GetString(2);
                    news.CreateTime = dr.GetDateTime(3);
                    news.IsDisplay = dr.GetBoolean(4);
                    news.Category = new NewsCategory();
                    news.Category.Id = dr.GetInt32(5);
                    news.Category.Name = GetNewsCategoryById(news.Category.Id).Name;
                }
            }
            return news;
        }

        public PaginationQueryResult<News> GetNewsByCategoryId(PaginationQueryCondition condition, int catId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", catId)
            };
            PaginationQueryResult<News> result = new PaginationQueryResult<News>();

            string sql = "SELECT TOP " + condition.PageSize + " news.id, title, content, create_time, news.category_id, news_categories.name FROM news INNER JOIN news_categories ON (news_categories.id = news.category_id) WHERE news.category_id = @id";
            if (condition.CurrentPage > 1)
                sql += " AND news.id<(SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM news INNER JOIN news_categories ON (news_categories.id = news.category_id) WHERE news.category_id = @id ORDER BY id DESC) AS D)";
            sql += " ORDER BY news.id DESC; SELECT COUNT(*) FROM news INNER JOIN news_categories ON (news_categories.id = news.category_id)  WHERE news.category_id = @id";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    News news = new News();
                    news.Id = dr.GetInt32(0);
                    news.Title = dr.GetString(1);
                    news.Content = dr.GetString(2);
                    news.CreateTime = dr.GetDateTime(3);
                    news.Category = new NewsCategory();
                    news.Category.Id = dr.GetInt32(4);
                    news.Category.Name = dr.GetString(5);

                    result.Results.Add(news);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }

        public List<News> GetNewsByCategoryId(int catId, int amount)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", catId),
                SqlUtilities.GenerateInputIntParameter("@amount", amount)
            };
            List<News> result = new List<News>();

            string sql = "SELECT TOP "+amount+" news.id, title, content, create_time, news.category_id, news_categories.name FROM news INNER JOIN news_categories ON (news_categories.id = news.category_id) WHERE news.category_id = @id AND news.is_display='True' ORDER BY news.id DESC ";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    News news = new News();
                    news.Id = dr.GetInt32(0);
                    news.Title = dr.GetString(1);
                    news.Content = dr.GetString(2);
                    news.CreateTime = dr.GetDateTime(3);
                    news.Category = new NewsCategory();
                    news.Category.Id = dr.GetInt32(4);
                    news.Category.Name = dr.GetString(5);

                    result.Add(news);
                }                
            }
            return result;
        }

        public List<News> GetNewsByCategoryId(int catId)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", catId)
            };
            List<News> result = new List<News>();

            string sql = "SELECT news.id, title, content, create_time, news.category_id, news_categories.name FROM news INNER JOIN news_categories ON (news_categories.id = news.category_id) WHERE news.category_id = @id AND news.is_display='True' ORDER BY news.id DESC ";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    News news = new News();
                    news.Id = dr.GetInt32(0);
                    news.Title = dr.GetString(1);
                    news.Content = dr.GetString(2);
                    news.CreateTime = dr.GetDateTime(3);
                    news.Category = new NewsCategory();
                    news.Category.Id = dr.GetInt32(4);
                    news.Category.Name = dr.GetString(5);

                    result.Add(news);
                }
            }
            return result;
        }

        public void UpdateNews(News news)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", news.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@title", 100, news.Title),
                SqlUtilities.GenerateInputParameter("@content", SqlDbType.Text, news.Content),
                SqlUtilities.GenerateInputIntParameter("@category_id", news.Category.Id),
                SqlUtilities.GenerateInputDateTimeParameter("@create_time", news.CreateTime),
                SqlUtilities.GenerateInputParameter("@is_display", SqlDbType.Bit, news.IsDisplay)
            };
            string sql = " UPDATE news SET  title = @title, content = @content, category_id = @category_id, create_time = @create_time, is_display = @is_display WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteNewsById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };

            string sql = "DELETE FROM news WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }
    }
}
