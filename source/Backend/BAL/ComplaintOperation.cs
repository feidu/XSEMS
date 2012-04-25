using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.Models.Pagination;
using Backend.DAL;

namespace Backend.BAL
{
    public class ComplaintOperation
    {
        private static readonly ComplaintDAL dal = new ComplaintDAL();

        public static void CreateComplaint(Complaint comp)
        {
            dal.CreateComplaint(comp);
        }

        public static void UpdateComplaintIsReply(Complaint complaint)
        {
            dal.UpdateComplaintIsReply(complaint);
        }

        public static Complaint GetComplaintById(int id)
        {
            return dal.GetComplaintById(id);
        }

        public static PaginationQueryResult<Complaint> GetComplaintByClientId(PaginationQueryCondition condition, int clientId)
        {
            return dal.GetComplaintByClientId(condition, clientId);
        }

        public static PaginationQueryResult<Complaint> GetComplaint(PaginationQueryCondition condition)
        {
            return dal.GetComplaint(condition);
        }

        public static PaginationQueryResult<Complaint> GetComplaintByCompanyId(PaginationQueryCondition condition, int compId)
        {
            return dal.GetComplaintByCompanyId(condition, compId);
        }

        public static PaginationQueryResult<Complaint> GetComplaintByClientIdAndIsReply(PaginationQueryCondition condition, int clientId, bool isReply)
        {
            return dal.GetComplaintByClientIdAndIsReply(condition, clientId, isReply);
        }

        public static PaginationQueryResult<Complaint> GetComplaintByCompanyIdAndIsReply(PaginationQueryCondition condition, int compId, bool isReply)
        {
            return dal.GetComplaintByCompanyIdAndIsReply(condition, compId, isReply);
        }

        public static void DeleteComplaintByIds(string ids)
        {
            if (ids == null)
            {
                return;
            }
            string[] array=ids.Split(',');
            foreach (string sId in array)
            {
                int id = 0;
                if (int.TryParse(sId, out id))
                {
                    dal.DeleteComplaintById(id);
                }
            }
        }

        public static void CreateComplaintReply(ComplaintReply compReply)
        {
            dal.CreateComplaintReply(compReply);
        }

        public static ComplaintReply GetComplaintReplyByComplaintId(int compId)
        {
            return dal.GetComplaintReplyByComplaintId(compId);
        }

    }
}
