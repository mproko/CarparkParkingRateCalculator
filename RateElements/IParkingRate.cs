using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarparkParkingRateCalculator.RateElements
{
    /// <summary>
    /// Iterface that defines contract for each Individual Single Rate.
    /// <param name="RateName">Used to specify used Rate Name</param>
    /// <param name="RateBasePrice">Used to specify Base Rate Price</param>
    /// </summary>
    interface IParkingRate
    {
        string RateName { get; }
        decimal RateBasePrice { get; }

        /// <summary>
        /// Calculate Output (stored in CalculatedRate object)
        /// from this Rate for specified EntryTime and ExitTime DateTime values.
        /// <returns>CalculatedRate type object if this Rate conditions are met 
        /// otherwise returns emty object</returns>
        /// </summary>
        CalculatedRate getCalculatedRate(DateTime EntryTime, DateTime ExitTime);
    }

}
