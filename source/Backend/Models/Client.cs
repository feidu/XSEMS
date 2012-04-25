using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Client : UserBase
    {
        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string _province;
	    public string Province
	    {
            get { return _province; }
            set { _province = value; }
	    }

        private string _city;
	    public string City
	    {
            get { return _city; }
            set { _city = value; }
	    }

        private byte _discount;
	    public byte Discount
	    {
            get { return _discount; }
            set { _discount = value; }
	    }

        private decimal _credit;
	    public decimal Credit
	    {
            get { return _credit; }
            set { _credit = value; }
	    }

        private decimal _balance;
        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        private bool _isMessage;
        /// <summary>
        /// 是否开通短信、邮件服务
        /// </summary>
	    public bool IsMessage
	    {
            get { return _isMessage; }
            set { _isMessage = value; }
	    }

        private bool _isFetchGoods;
        /// <summary>
        /// 是否取件
        /// </summary>
        public bool IsFetchGoods
	    {
            get { return _isFetchGoods; }
            set { _isFetchGoods = value; }
	    }

        private bool _isAbate;
        /// <summary>
        /// 挂号费是否打折
        /// </summary>
        public bool IsAbate
        {
            get { return _isAbate; }
            set { _isAbate = value; }
        }
    }
}
