using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;
using Backend.Authorization;
using Backend.Models.Admin;
using Backend.Models.Pagination;
using Backend.Utilities;

namespace Backend.BAL
{
    public class UserOperation
    {
        private static readonly UserDAL dal = new UserDAL();

        public static void UpdateOperatorAuthorization(int operatorId, List<ModuleAuthorization> mas)
        {
            dal.UpdateOperatorAuthorization(operatorId, mas);
        }

        public static PaginationQueryResult<User> GetLightUser(PaginationQueryCondition condition)
        {
            return dal.GetLightUser(condition);
        }

        public static List<User> GetLightUser()
        {
            return dal.GetLightUser();
        }

        public static OperatorStaus CreateUser(User user)
        {
            User ur = dal.GetUserByUsername(user.Username);
            if (ur != null) return OperatorStaus.OPERATOR_USERNAME_EXISTED;
            user.Password = EncryptionHelper.EncryptString(user.Password);
            dal.CreateUser(user);
            return OperatorStaus.SUCCESS;
        }

        public static void DeleteUserById(int id)
        {            
            dal.DeleteUserById(id);
        }

        public static void UpdateUser(User user)
        {
            dal.UpdateUser(user);
        }

        public static void DeleteUserByIds(string ids)
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
                    dal.DeleteUserById(id);
                }
            }
        }

        public static void UpdateUserPassword(User user, string password)
        {
            int id = user.Id;
            string newPassword = EncryptionHelper.EncryptString(password);
            dal.UpdateUserPassword(id, newPassword);
        }

        public static User GetUserById(int id)
        {
            return dal.GetUserById(id);
        }

        public static User GetUserByUsername(string username)
        {
            return dal.GetUserByUsername(username);
        }

        public static OperatorStaus UserLogin(User user)
        {
            User ur = dal.GetUserByUsername(user.Username);
            if (ur == null) return OperatorStaus.OPERATOR_USERNAME_INCORROECT;
            if (ur.Password != EncryptionHelper.EncryptString(user.Password)) return OperatorStaus.OPERATOR_PASSWORD_INCORROECT;
            user.Id = ur.Id;
            user.CreateDate = ur.CreateDate;
            user.CompanyId = ur.CompanyId;
            user.RealName = ur.RealName;
            user.ModuleAuthorizations = ur.ModuleAuthorizations;
            return OperatorStaus.SUCCESS;
        }

        public static PaginationQueryResult<User> GetLightUserByCompanyId(PaginationQueryCondition condition, int compId)
        {
            return dal.GetLightUserByCompanyId(condition, compId);
        }

        public static List<User> GetLightUserByCompanyId(int compId)
        {
            return dal.GetLightUserByCompanyId(compId);
        }
    }
}
