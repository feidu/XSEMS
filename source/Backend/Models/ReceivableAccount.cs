using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class ReceivableAccount
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _companyId;
        public int CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }

        private string _companyName;
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        private PaymentMethod _paymentMethod;
        public PaymentMethod PaymentMethod
        {
            get { return _paymentMethod; }
            set { _paymentMethod = value; }
        }

        private string _accountNumber;
        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }

        private string _accountName;
        public string AccountName
        {
            get { return _accountName; }
            set { _accountName = value; }
        }

        private string _bankName;
        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }

        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

    }
}
