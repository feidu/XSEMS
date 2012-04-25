using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Utilities;

namespace Backend.DAL
{
    public class AreaCountryDAL
    {
        
        public void CreateAreaCountry(AreaCountry ac)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@carrier_area_id", ac.CarrierArea.Id),
                SqlUtilities.GenerateInputIntParameter("@country_id", ac.Country.Id)
            };
            string sql = "INSERT INTO area_countries(carrier_area_id, country_id) VALUES(@carrier_area_id, @country_id)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }




        public List<AreaCountry> GetAreaCountryByCarrierAreaId(int id)
        {
            List<AreaCountry> result = new List<AreaCountry>();
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@carrier_area_id", id)
            };
            string sql = "SELECT id, carrier_area_id, country_id FROM area_countries WHERE carrier_area_id = @carrier_area_id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    AreaCountry ac = new AreaCountry();
                    ac.Id = dr.GetInt32(0);
                    CarrierArea ca = new CarrierAreaDAL().GetCarrierAreaById(dr.GetInt32(1));
                    ac.CarrierArea = ca;
                    Country country = new CountryDAL().GetCountryById(dr.GetInt32(2));
                    ac.Country = country;
                    result.Add(ac);
                }
            }
            return result;
        }

        public void DeleteAreaCountryByCarrierAreaId(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@carrier_area_id", id)
            };
            string sql = "DELETE FROM area_countries WHERE carrier_area_id = @carrier_area_id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }
    }
}