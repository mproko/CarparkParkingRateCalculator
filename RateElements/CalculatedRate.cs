using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarparkParkingRateCalculator.RateElements
{
    /// <summary>
    /// Contains the Calculated Result Rate Object from the CarparkParkingRateCalculator Object
    /// and its getParkingRate method. This type of Object is returned as result of the Web API.
    /// <param name="RateName">Used to specify used Rate Name</param>
    /// <param name="RateTotalPrice">Used to specify calulated Total Price</param>
    /// </summary>
    public class CalculatedRate
    {
        private string _RateName = "";
        private decimal _RateTotalPrice = 0;

        public string RateName { get => _RateName; }
        public decimal RateTotalPrice { get => _RateTotalPrice; }

        public CalculatedRate(string RateName, decimal RateTotalPrice)
        {
            _RateTotalPrice = RateTotalPrice;
            _RateName = RateName;
        }
    }
}
