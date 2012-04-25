using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;

namespace Backend.BAL
{
    public class PostStatusOperation
    {
        private static readonly PostStatusDAL dal = new PostStatusDAL();

        public static void CreatePostStatus(LogisticsStatus ls)
        {
            dal.CreatePostStatus(ls);
        }

        public static void DeletePostStatusByBarCode(string barCode)
        {
            dal.DeletePostStatusByBarcode(barCode);
        }
        
        public static List<PostStatus> GetPostStatusByBarcode(string barCode)
        {
            return dal.GetPostStatusByBarcode(barCode);
        }

        public static List<PostStatus> GetPostStatusByBarcodes(string barCodes)
        {
            return dal.GetPostStatusByBarcodes(barCodes);
        }
    }
}
