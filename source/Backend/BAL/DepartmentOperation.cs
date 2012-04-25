using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.DAL;

namespace Backend.BAL
{
    public class DepartmentOperation
    {
        private static readonly DepartmentDAL dal = new DepartmentDAL();

        public static bool CreateDepartment(Department dept)
        {
            if (dal.GetDepartmentByName(dept.Name)!= null)
            {
                return false;
            }
            dal.CreateDepartment(dept);
            return true;
        }

        public static void UpdateDepartment(Department dept)
        {
            dal.UpdateDepartment(dept);
        }

        public static Department GetDepartmentById(int id)
        {
            return dal.GetDepartmentById(id);
        }

        public static List<Department> GetDepartmentByCompanyId(int compId)
        {
            return dal.GetDepartmentByCompanyId(compId);
        }

        public static void DeleteDepartmentByIds(string ids)
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
                    dal.DeleteDepartmentById(id);
                }
            }
        }
    }
}
