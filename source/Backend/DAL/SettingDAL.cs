using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Utilities;


namespace Backend.DAL
{
    public class SettingDAL
    {
        public void CreateSetting(Setting setting)
        {
            SqlParameter[] param = new SqlParameter[]{            
                SqlUtilities.GenerateInputNVarcharParameter("@title",200,setting.Title),
                SqlUtilities.GenerateInputNVarcharParameter("@keyword",500,setting.Keyword),
                SqlUtilities.GenerateInputNVarcharParameter("@description",500,setting.Description),
                SqlUtilities.GenerateInputNVarcharParameter("@phone",100,setting.Phone),
                SqlUtilities.GenerateInputNVarcharParameter("@fax",100,setting.Fax),
                SqlUtilities.GenerateInputNVarcharParameter("@email",50,setting.Email),
                SqlUtilities.GenerateInputNVarcharParameter("@msn",50,setting.Msn),
                SqlUtilities.GenerateInputNVarcharParameter("@postalcode",10,setting.Postalcode),
                SqlUtilities.GenerateInputNVarcharParameter("@address",200,setting.Address),
                SqlUtilities.GenerateInputNVarcharParameter("@copyright",200,setting.Copyright),
                SqlUtilities.GenerateInputNVarcharParameter("@record",100,setting.Record)

            };
            string sql = "INSERT INTO settings (title, keyword, description, phone, fax, email, postalcode, address, copyright, record, msn ) VALUES (@title, @keyword, @description, @phone, @fax, @email, @postalcode, @address, @copyright, @record, @msn )";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public Setting GetSetting()
        {
            Setting setting = null;
            string sql = "SELECT id, title, keyword, description, phone, fax, email, postalcode, address, copyright, record, msn FROM settings";
            using(SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while(dr.Read())
                {
                    setting = new Setting();
                    setting.Id = dr.GetInt32(0);
                    setting.Title = dr.GetString(1);
                    setting.Keyword = dr.GetString(2);
                    setting.Description = dr.GetString(3);
                    setting.Phone = dr.GetString(4);
                    setting.Fax = dr.GetString(5);
                    setting.Email = dr.GetString(6);
                    setting.Postalcode = dr.GetString(7);
                    setting.Address = dr.GetString(8);
                    setting.Copyright = dr.GetString(9);
                    setting.Record = dr.GetString(10);
                    setting.Msn = dr.GetString(11);
                }
            }
            return setting;
        }

        public void UpdateSetting(Setting setting)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id",setting.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@title",200,setting.Title),
                SqlUtilities.GenerateInputNVarcharParameter("@keyword",500,setting.Keyword),
                SqlUtilities.GenerateInputNVarcharParameter("@description",500,setting.Description),
                SqlUtilities.GenerateInputNVarcharParameter("@phone",100,setting.Phone),
                SqlUtilities.GenerateInputNVarcharParameter("@fax",100,setting.Fax),
                SqlUtilities.GenerateInputNVarcharParameter("@email",50,setting.Email),
                SqlUtilities.GenerateInputNVarcharParameter("@msn",50,setting.Msn),
                SqlUtilities.GenerateInputNVarcharParameter("@postalcode",10,setting.Postalcode),
                SqlUtilities.GenerateInputNVarcharParameter("@address",200,setting.Address),
                SqlUtilities.GenerateInputNVarcharParameter("@copyright",200,setting.Copyright),
                SqlUtilities.GenerateInputNVarcharParameter("@record",100,setting.Record)
            };
            string sql = "UPDATE settings SET title = @title, keyword = @keyword, description = @description, phone = @phone, fax = @fax, email= @Email, msn = @msn, postalcode = @postalcode, copyright = @copyright, address = @Address, record = @record WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }
                
        public void CreateAd(Ad ad)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@title",100,ad.Title),
                SqlUtilities.GenerateInputNVarcharParameter("@path",100,ad.Path),
                SqlUtilities.GenerateInputNVarcharParameter("@url",100,ad.Url),
                SqlUtilities.GenerateInputIntParameter("@sort_num",ad.SortNum),
                SqlUtilities.GenerateInputNVarcharParameter("@create_time",200,ad.CreateTime)
            };
            string sql = "INSERT INTO ads(title, path, url, create_time, sort_Num)VALUES(@title, @path, @url, @create_time, @sort_num)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);

        }

        public void UpdateAd(Ad ad)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", ad.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@title",100,ad.Title),
                SqlUtilities.GenerateInputNVarcharParameter("@path",100,ad.Path),
                SqlUtilities.GenerateInputNVarcharParameter("@url",100,ad.Url),
                SqlUtilities.GenerateInputIntParameter("@sort_num",ad.SortNum),
                SqlUtilities.GenerateInputNVarcharParameter("@create_time",200,ad.CreateTime)
            };
            string sql = "UPDATE ads SET title = @title, path = @path, url = @url, create_time = @create_time, sort_num = @sort_num WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);

        }

        public void DeleteAdById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@Id",id)
            };
            string sql = "DELETE FROM ads WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public Ad GetAdbyId(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@Id",id)
            };
            Ad ad = null;
            string sql = "SELECT id, title, path, url, create_time, sort_num FROM ads WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ad = new Ad();
                    ad.Id = dr.GetInt32(0);
                    ad.Title = dr.GetString(1);
                    ad.Path = dr.GetString(2);
                    ad.Url = dr.GetString(3);
                    ad.CreateTime = dr.GetDateTime(4);
                    ad.SortNum = dr.GetInt32(5);
                }

            }
            return ad;
        }

        public List<Ad> GetAdSortByNum()
        {
            List<Ad> result = new List<Ad>();
            string sql = "SELECT id, title, path, url, create_time, sort_num FROM ads ORDER BY sort_num DESC,id ASC";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    Ad ad = new Ad();
                    ad.Id = dr.GetInt32(0);
                    ad.Title = dr.GetString(1);
                    ad.Path = dr.GetString(2);
                    ad.Url = dr.GetString(3);
                    ad.CreateTime = dr.GetDateTime(4);
                    ad.SortNum = dr.GetInt32(5);
                    result.Add(ad);
                }

            }
            return result;
        }
    }
}
