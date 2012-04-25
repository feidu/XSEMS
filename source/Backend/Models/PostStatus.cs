using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class PostStatus
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _barCode;
        public string BarCode
        {
            get { return _barCode; }
            set { _barCode = value; }
        }

        private int _year;
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _location;
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        private string _toCountry;
        public string ToCountry
        {
            get { return _toCountry; }
            set { _toCountry = value; }
        }

        private DateTime _disposalTime;
        public DateTime DisposalTime
        {
            get { return _disposalTime; }
            set { _disposalTime = value; }
        }

        private bool _isArrive;
        public bool IsArrive
        {
            get { return _isArrive; }
            set { _isArrive = value; }
        }

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
          
    }
}
