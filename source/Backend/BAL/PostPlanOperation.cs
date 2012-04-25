using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.Models.Pagination;
using Backend.DAL;

namespace Backend.BAL
{
    public class PostPlanOperation
    {
        private static readonly PostPlanDAL dal = new PostPlanDAL();

        public static void CreatePostPlan(PostPlan pp)
        {
            dal.CreatePostPlan(pp);
        }

        public static void UpdatePostPlan(PostPlan pp)
        {
            dal.UpdatePostPlan(pp);
        }

        public static PostPlan GetPostPlanById(int id)
        {
            return dal.GetPostPlanById(id);
        }

        public static List<PostPlan> GetPostPlan()
        {
            return dal.GetPostPlan();
        }

        public static PaginationQueryResult<PostPlan> GetPostPlanByCompanyId(PaginationQueryCondition condition, int compId)
        {
            return dal.GetPostPlanByCompanyId(condition, compId);
        }

        public static PaginationQueryResult<PostPlan> GetPostPlanByCompanyIdAndDate(PaginationQueryCondition condition, int compId, DateTime startDate, DateTime endDate)
        {
            return dal.GetPostPlanByCompanyIdAndDate(condition, compId, startDate, endDate);
        }

        public static void DeletePostPlanById(int id)
        {
            dal.DeletePostPlanById(id);
        }

        public static void DeletePostPlanByIds(string ids)
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
                    dal.DeletePostPlanById(id);
                }
            }
        }
    }
}
