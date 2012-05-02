using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Utilities;

namespace Backend.DAL
{
    public class ReceivableAccountDAL
    {
        public void CreateReceivableAccount(ReceivableAccount ra)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@account_number", 50, ra.AccountNumber),
                SqlUtilities.GenerateInputNVarcharParameter("@account_name", 50, ra.AccountName),
                SqlUtilities.GenerateInputNVarcharParameter("@bank_name", 50, ra.BankName),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 1000, ra.Remark)
            };
            string sql = "INSERT INTO receivable_accounts(account_number, account_name, bank_name, remark) VALUES(@account_number, @account_name, @bank_name, @remark)";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void UpdateReceivableAccount(ReceivableAccount ra)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", ra.Id),
                SqlUtilities.GenerateInputNVarcharParameter("@account_number", 50, ra.AccountNumber),
                SqlUtilities.GenerateInputNVarcharParameter("@account_name", 50, ra.AccountName),
                SqlUtilities.GenerateInputNVarcharParameter("@bank_name", 50, ra.BankName),
                SqlUtilities.GenerateInputNVarcharParameter("@remark", 1000, ra.Remark)
            };
            string sql = "UPDATE receivable_accounts SET account_number = @account_number, account_name = @account_name, bank_name = @bank_name, remark = @remark WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public void DeleteReceivableAccountById(int id)
        {
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "Update receivable_accounts SET is_delete = 1 WHERE id = @id";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
        }

        public ReceivableAccount GetReceivableAccountById(int id)
        {
            ReceivableAccount ra = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputIntParameter("@id", id)
            };
            string sql = "SELECT id, account_number, account_name, bank_name, remark FROM receivable_accounts WHERE id = @id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ra = new ReceivableAccount();
                    ra.Id = dr.GetInt32(0);                    
                    ra.AccountNumber = dr.GetString(1);
                    ra.AccountName = dr.GetString(2);
                    ra.BankName = dr.GetString(3);
                    ra.Remark = dr.GetString(4);
                }
            }
            return ra;
        }

        public ReceivableAccount GetReceivableAccountByNumber(string number)
        {
            ReceivableAccount ra = null;
            SqlParameter[] param = new SqlParameter[] { 
                SqlUtilities.GenerateInputNVarcharParameter("@account_number", 50, number)
            };
            string sql = "SELECT id, account_number, account_name, bank_name, remark FROM receivable_accounts WHERE account_number = @account_number";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                while (dr.Read())
                {
                    ra = new ReceivableAccount();
                    ra.Id = dr.GetInt32(0);                    
                    ra.AccountNumber = dr.GetString(1);
                    ra.AccountName = dr.GetString(2);
                    ra.BankName = dr.GetString(3);
                    ra.Remark = dr.GetString(4);
                }
            }
            return ra;
        }

        public List<ReceivableAccount> GetReceivableAccount()
        {
            List<ReceivableAccount> result = new List<ReceivableAccount>();
            string sql = "SELECT id, account_number, account_name, bank_name, remark FROM receivable_accounts";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, null))
            {
                while (dr.Read())
                {
                    ReceivableAccount ra = new ReceivableAccount();
                    ra.Id = dr.GetInt32(0);                    
                    ra.AccountNumber = dr.GetString(1);
                    ra.AccountName = dr.GetString(2);
                    ra.BankName = dr.GetString(3);
                    ra.Remark = dr.GetString(4);
                    result.Add(ra);
                }
            }
            return result;
        }

        //public List<ReceivableAccount> GetReceivableAccountByCompanyId(int compId)
        //{
        //    SqlParameter[] param = new SqlParameter[] { 
        //        SqlUtilities.GenerateInputIntParameter("@company_id", compId)
        //    };
        //    List<ReceivableAccount> result = new List<ReceivableAccount>();
        //    string sql = "SELECT id, account_number, account_name, bank_name, remark FROM receivable_accounts WHERE company_id = @company_id AND is_delete = 0";
        //    using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, param))
        //    {
        //        while (dr.Read())
        //        {
        //            ReceivableAccount ra = new ReceivableAccount();
        //            ra.Id = dr.GetInt32(0);                   
        //            ra.AccountNumber = dr.GetString(1);
        //            ra.AccountName = dr.GetString(2);
        //            ra.BankName = dr.GetString(3);
        //            ra.Remark = dr.GetString(4);
        //            result.Add(ra);
        //        }
        //    }
        //    return result;
        //}

    }
}
