using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.BAL;
using System.Web.Caching;

namespace Backend.Utilities
{
    public class CacheHelper
    {
        private static readonly string CACHE_NAME = "Cache_Setting";

        public static Setting GetSetting()
        {
            Setting setting = null;
            Cache cache = System.Web.HttpContext.Current.Cache;
            if (cache[CACHE_NAME] == null)
            {
                setting = SettingOperation.LoadSetting();
                cache[CACHE_NAME] = setting;
            }
            else
            {
                setting = cache[CACHE_NAME] as Setting;
            }
            return setting;
        }

        public static void ClearCache()
        {
            Cache cache = System.Web.HttpContext.Current.Cache;
            if (cache[CACHE_NAME] != null)
                cache.Remove(CACHE_NAME);
        }
    }
}

