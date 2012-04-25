using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class News
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

        private string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private NewsCategory _category;

        public NewsCategory Category
        {
            get { return _category; }
            set { _category = value; }
        }

        private DateTime _createTime;

        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }


        private bool _isDisplay;

        public bool IsDisplay
        {
            get { return _isDisplay; }
            set { _isDisplay = value; }
        }
    }
}
