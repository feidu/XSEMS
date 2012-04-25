using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;
using Backend.Models.Pagination;

namespace Backend.BAL
{
    public class InsuranceOperation
    {
        private static readonly InsuranceDAL dal = new InsuranceDAL();

        public static void CreateInsurance(Insurance insurance)
        {
            dal.CreateInsurance(insurance);
        }

        public static void UpdateInsurance(Insurance insurance)
        {
            dal.UpdateInsurance(insurance);
        }

        public static void DeleteInsuranceById(int id)
        {
            dal.DeleteInsuranceById(id);
        }

        public static Insurance GetInsuranceById(int id)
        {
            return dal.GetInsuranceById(id);
        }

        public static Insurance GetInsuranceByOrderDetailId(int id)
        {
            return dal.GetInsuranceByOrderDetailId(id);
        }

        public static PaginationQueryResult<Insurance> GetInsurance(PaginationQueryCondition condition)
        {
            return dal.GetInsurance(condition);
        }

        public static PaginationQueryResult<Insurance> GetInsuranceByParameters(PaginationQueryCondition condition, DateTime startDate, DateTime endDate, decimal insureWorth, string searchKey)
        {
            return dal.GetInsuranceByParameters(condition, startDate, endDate, insureWorth, searchKey);
        }
    }
}
