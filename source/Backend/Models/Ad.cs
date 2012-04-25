using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Ad
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _path;

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        private string _url;

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private DateTime _createTime;

        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
        private int _sortNum;

        public int SortNum
        {
            get { return _sortNum; }
            set { _sortNum = value; }
        }
    }
}
