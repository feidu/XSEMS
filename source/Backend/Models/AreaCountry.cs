using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class AreaCountry
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private CarrierArea _carrierArea;
        public CarrierArea CarrierArea
        {
            get { return _carrierArea; }
            set { _carrierArea = value; }
        }

        private Country _country;
        public Country Country
        {
            get { return _country; }
            set { _country = value; }
        }

    }
}
