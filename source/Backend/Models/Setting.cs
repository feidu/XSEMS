using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Setting
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

        private string _keyword;

        public string Keyword
        {
            get { return _keyword; }
            set { _keyword = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _fax;

        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        private string _copyright;
        /// <summary>
        /// 版权信息
        /// </summary>
        public string Copyright
        {
            get { return _copyright; }
            set { _copyright = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _msn;

        public string Msn
        {
            get { return _msn; }
            set { _msn = value; }
        }

        private string _postalcode;

        public string Postalcode
        {
            get { return _postalcode; }
            set { _postalcode = value; }
        }

        private string _record;
        /// <summary>
        /// 备案信息
        /// </summary>
        public string Record
        {
            get { return _record; }
            set { _record = value; }
        }

        //private string _announcement;

        //public string Announcement
        //{
        //    get { return _announcement; }
        //    set { _announcement = value; }
        //}

        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

    }
}
