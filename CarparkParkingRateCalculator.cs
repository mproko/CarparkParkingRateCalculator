using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarparkParkingRateCalculator.RateElements;

namespace CarparkParkingRateCalculator
{
    /// <summary>
    /// Represent mechanism for caluclating the lowest   
    /// Calculated Parking Rate stored in CalculatedRate Object.
    /// Contains RateList ArrayList that is loaded with all 
    /// Rate Element Objects (have common IParkingRate interface)
    /// which are used for the calculation.
    /// </summary>
    public class CarparkParkingRateCalculator
    {
        private ArrayList RateList;

        public CarparkParkingRateCalculator()
        {
            RateList = new ArrayList();
            RateList.Add(new RateEarlyBird("Early Bird", 13));
            RateList.Add(new RateNightRate("Night Rate", 6.5m));
            RateList.Add(new RateWeekendRate("Weekend Rate", 10));
            
            RateList.Add(new RateStandard(5, "0-1 Hours", 0, 1));
            RateList.Add(new RateStandard(10, "1-2 Hours", 1, 2));
            RateList.Add(new RateStandard(15, "2-3 Hours", 2, 3));
            RateList.Add(new RateStandard(20, "3+ Hours", 3, -1));
        }

        public CarparkParkingRateCalculator(ArrayList NewList)
        {
            RateList = NewList;
        }

        /// <summary>
        /// getParkingRate Method for selected pair of EntryDate and ExitDate
        /// DateTime values, calls every Rate Element from RateList
        /// and select result from the one which returns lowes RateTotalPrice value.
        /// </summary>
        public CalculatedRate getParkingRate(DateTime EntryDate, DateTime ExitDate)
        {
            CalculatedRate workCalculatedRate = null, minCalculatedRate = null;
            foreach (IParkingRate workRate in RateList)
            {
                workCalculatedRate = workRate.getCalculatedRate(EntryDate, ExitDate);
                if (workCalculatedRate != null && minCalculatedRate == null)
                {
                    minCalculatedRate = workCalculatedRate;
                }
                else if(workCalculatedRate != null && minCalculatedRate != null 
                    && workCalculatedRate.RateTotalPrice < minCalculatedRate.RateTotalPrice)
                {
                    minCalculatedRate = workCalculatedRate;
                }

            }
            return minCalculatedRate;
        }

    }
}
