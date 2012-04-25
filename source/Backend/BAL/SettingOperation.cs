using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.DAL;
using Backend.Models;

namespace Backend.BAL
{
    public class SettingOperation
    {
        private static readonly SettingDAL dal = new SettingDAL();

        public static void CreateSetting(Setting setting)
        {
            dal.CreateSetting(setting);
        }

        public static Setting LoadSetting()
        {
            return dal.GetSetting();
        }

        public static void UpdateSetting(Setting setting)
        {
            dal.UpdateSetting(setting);
        }

        public static void CreateAd(Ad ad)
        {
            dal.CreateAd(ad);
        }

        public static void UpdateAd(Ad ad)
        {
            dal.UpdateAd(ad);
        }

        public static void DeleteAdById(int id)
        {
            dal.DeleteAdById(id);
        }

        public static Ad GetAdbyId(int id)
        {
            return dal.GetAdbyId(id);
        }

        public static List<Ad> GetAdSortByNum()
        {
            return dal.GetAdSortByNum();
        }
    }
}
