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
    public class CountryDAL
    {
        public void CreateCountry(Country country)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@english_name", 50, country.EnglishName),
                SqlUtilities.GenerateInputNVarcharParameter("@chinese_name", 50, country.ChineseName),
                SqlUtilities.GenerateInputNVarcharParameter("@code", 50, country.Code),
                SqlUtilities.GenerateInputParameter("@continent",SqlDbType.TinyInt, country.Continent)
            };
            string sql = "INSERT INTO countries(english_name, chinese_name, code, continent) VALUES(@english_name, @chinese_name, @code, @continent)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateCountry(Country country)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", country.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@english_name", 50, country.EnglishName),
                SqlUtilities.GenerateInputNVarcharParameter("@chinese_name", 50, country.ChineseName),
                SqlUtilities.GenerateInputNVarcharParameter("@code", 50, country.Code),
                SqlUtilities.GenerateInputParameter("@continent",SqlDbType.TinyInt, country.Continent),
                SqlUtilities.GenerateInputParameter("@is_front", SqlDbType.Bit, country.IsFront)
            };
            string sql = "UPDATE countries SET english_name = @english_name, chinese_name = @chinese_name, code = @code, continent = @continent, is_front = @is_front WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteCountryById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "DELETE FROM countries WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public Country GetCountryById(int id)
        {
            Country country = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, english_name, chinese_name, code, continent, is_front FROM countries WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    country = new Country();
                    country.Id = dr.GetInt32(0);
                    country.EnglishName = dr.GetString(1);
                    country.ChineseName = dr.GetString(2);
                    country.Code = dr.GetString(3);
                    country.Continent = dr.GetByte(4);
                    country.IsFront = dr.GetBoolean(5);
                }
            }
            return country;
        }

        public Country GetCountryByEnglishName(string name)
        {
            Country country = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@english_name", 50, name)
            };
            string sql = "SELECT id, english_name, chinese_name, code, continent, is_front FROM countries WHERE english_name = @english_name";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    country = new Country();
                    country.Id = dr.GetInt32(0);
                    country.EnglishName = dr.GetString(1);
                    country.ChineseName = dr.GetString(2);
                    country.Code = dr.GetString(3);
                    country.Continent = dr.GetByte(4);
                    country.IsFront = dr.GetBoolean(5);
                }
            }
            return country;
        }

        public List<Country> GetCountry()
        {
            List<Country> result = new List<Country>();
            string sql = "SELECT id, english_name, chinese_name, code, continent, is_front FROM countries ORDER BY is_front DESC,english_name ASC";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Country country = new Country();
                    country.Id = dr.GetInt32(0);
                    country.EnglishName = dr.GetString(1);
                    country.ChineseName = dr.GetString(2);
                    country.Code = dr.GetString(3);
                    country.Continent = dr.GetByte(4);
                    country.IsFront = dr.GetBoolean(5);
                    result.Add(country);
                }
            }
            return result;
        }

        public List<Country> GetCountryForArea()
        {
            List<Country> result = new List<Country>();
            string sql = "SELECT id, english_name, chinese_name, code, continent, is_front FROM countries ORDER BY continent ASC";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Country country = new Country();
                    country.Id = dr.GetInt32(0);
                    country.EnglishName = dr.GetString(1);
                    country.ChineseName = dr.GetString(2);
                    country.Code = dr.GetString(3);
                    country.Continent = dr.GetByte(4);
                    country.IsFront = dr.GetBoolean(5);
                    result.Add(country);
                }
            }
            return result;
        }

        public List<Country> GetCountryBySearchKey(string searchKey)
        {
            List<Country> result = new List<Country>();
            string sql = "SELECT id, english_name, chinese_name, code, continent, is_front FROM countries WHERE english_name LIKE '" + searchKey + "%' OR chinese_name LIKE '" + searchKey + "%' ORDER BY is_front DESC,english_name ASC; SELECT id, english_name, chinese_name, code, continent, is_front FROM countries WHERE english_name LIKE '%" + searchKey + "%' OR chinese_name LIKE '%" + searchKey + "%' ORDER BY is_front DESC,english_name ASC";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Country country = new Country();
                    country.Id = dr.GetInt32(0);
                    country.EnglishName = dr.GetString(1);
                    country.ChineseName = dr.GetString(2);
                    country.Code = dr.GetString(3);
                    country.Continent = dr.GetByte(4);
                    country.IsFront = dr.GetBoolean(5);
                    result.Add(country);
                }
                if (result.Count <= 0)
                {
                    dr.NextResult();
                    while (dr.Read())
                    {
                        Country country = new Country();
                        country.Id = dr.GetInt32(0);
                        country.EnglishName = dr.GetString(1);
                        country.ChineseName = dr.GetString(2);
                        country.Code = dr.GetString(3);
                        country.Continent = dr.GetByte(4);
                        country.IsFront = dr.GetBoolean(5);
                        result.Add(country);
                    }
                }
            }
            return result;
        }

        public PaginationQueryResult<Country> GetCountry(PaginationQueryCondition condition)
        {
            PaginationQueryResult<Country> result = new PaginationQueryResult<Country>();
            string sql = "SELECT TOP " + condition.PageSize + " id, english_name, chinese_name, code, continent, is_front FROM countries";
            if (condition.CurrentPage > 1)
            {
                sql += " WHERE id< (SELECT MIN(id) FROM (SELECT TOP " + condition.PageSize * (condition.CurrentPage - 1) + " id FROM countries ORDER BY id DESC) AS C)";
            }
            sql += " ORDER BY id DESC; SELECT COUNT(*) FROM countries ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Country country = new Country();
                    country.Id = dr.GetInt32(0);
                    country.EnglishName = dr.GetString(1);
                    country.ChineseName = dr.GetString(2);
                    country.Code = dr.GetString(3);
                    country.Continent = dr.GetByte(4);
                    country.IsFront = dr.GetBoolean(5);
                    result.Results.Add(country);
                }
                dr.NextResult();
                while (dr.Read())
                {
                    result.TotalCount = dr.GetInt32(0);
                }
            }
            return result;
        }
    }
}
