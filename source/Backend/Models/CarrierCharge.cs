using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class CarrierCharge : IComparable
    {
        private Carrier _carrier;
        public Carrier Carrier
        {
            get { return _carrier; }
            set { _carrier = value; }
        }

        private CarrierArea _carrierArea;
        public CarrierArea CarrierArea
        {
            get { return _carrierArea; }
            set { _carrierArea = value; }
        }

        private ChargeStandard _chargeStandard;
        public ChargeStandard ChargeStandard
        {
            get { return _chargeStandard; }
            set { _chargeStandard = value; }
        }

        private decimal _clientPostCost;
        public decimal ClientPostCost
        {
            get { return _clientPostCost; }
            set { _clientPostCost = value; }
        }

        private decimal _clientTotalCost;
        public decimal ClientTotalCost
        {
            get { return _clientTotalCost; }
            set { _clientTotalCost = value; }
        }

        private decimal _selfPostCost;
        public decimal SelfPostCost
        {
            get { return _selfPostCost; }
            set { _selfPostCost = value; }
        }

        private decimal _selfTotalCost;
        public decimal SelfTotalCost
        {
            get { return _selfTotalCost; }
            set { _selfTotalCost = value; }
        }

        public int CompareTo(object obj)
        {
            if (obj is CarrierCharge)
            {
                CarrierCharge cc = obj as CarrierCharge;
                return this.ClientTotalCost.CompareTo(cc.ClientTotalCost);
            }
            throw new NotImplementedException("obj is not a CarrierCharge!");
        }
    }
}
