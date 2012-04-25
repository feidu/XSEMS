using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Country
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _englishName;
        public string EnglishName
        {
            get { return _englishName; }
            set { _englishName = value; }
        }

        private string _chineseName;
        public string ChineseName
        {
            get { return _chineseName; }
            set { _chineseName = value; }
        }

        private string _code;
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private byte _continent;
        public byte Continent
        {
            get { return _continent; }
            set { _continent = value; }
        }


        private bool _isFront;
        public bool IsFront
        {
            get { return _isFront; }
            set { _isFront = value; }
        }
    }
}
