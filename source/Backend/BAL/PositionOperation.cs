using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;
using Backend.Models.Admin;

namespace Backend.BAL
{
    public class PositionOperation
    {
        private static readonly PositionDAL dal = new PositionDAL();

        public static bool CreatePosition(Position post)
        {
            if (dal.GetPositionByName(post.Name) != null)
            {
                return false;
            }
            dal.CreatePosition(post);
            return true;
        }

        public static void UpdatePosition(Position post)
        {
            dal.UpdatePosition(post);
        }

        public static Position GetPositionById(int id)
        {
            return dal.GetPositionById(id);
        }

        public static List<Position> GetPosition()
        {
            return dal.GetPosition();
        }

        public static void DeletePositionByIds(string ids)
        {
            if (ids == null)
            {
                return;
            }
            string[] array = ids.Split(',');
            foreach (string sId in array)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeletePositionById(id);
                }
            }
        }

        public static void UpdatePositionAuthorization(int postId, List<ModuleAuthorization> mas)
        {
            dal.UpdatePositionAuthorization(postId, mas);
        }
    }
}
