using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarparkParkingRateCalculator.RateElements
{
    /// <summary>
    /// Contains the Early Bird Flat Rate.
    /// EntryTime value is comapred with TIME_ENTRY_FROM and TIME_ENTRY_TO define time period 
    /// ExitTime value is comapred with TIME_EXIT_FROM and TIME_EXIT_TO define time period 
    /// </summary>
    public class RateEarlyBird : IParkingRate
    {
        // Constant Parameters
        private TimeSpan TIME_ENTRY_FROM = new TimeSpan(6, 0, 0);
        private TimeSpan TIME_ENTRY_TO = new TimeSpan(9, 0, 0);
        private TimeSpan TIME_EXIT_FROM = new TimeSpan(15, 30, 0);
        private TimeSpan TIME_EXIT_TO = new TimeSpan(23, 30, 0);

        private string _RateName = "Early Bird";
        private decimal _RateBasePrice = 13;

        public string RateName { get => _RateName; }
        public decimal RateBasePrice { get => _RateBasePrice; }

        public RateEarlyBird() { }

        public RateEarlyBird(string RateName, decimal RateBasePrice)
        {
            _RateName = RateName;
            _RateBasePrice = RateBasePrice;
        }

        public void setTimeBlocks(TimeSpan TimeEntryFrom, TimeSpan TimeEntryTo, TimeSpan TimeExitFrom, TimeSpan TimeExitTo)
        {
            TIME_ENTRY_FROM = TimeEntryFrom;
            TIME_ENTRY_TO = TimeEntryTo;
            TIME_EXIT_FROM = TimeExitFrom;
            TIME_EXIT_TO = TimeExitTo;
        }

        /// <summary>
        /// Check if this Rate can be used for the specified 
        /// EntryTime and ExitTime DateTime values. 
        /// Returns empty object if the conditions are not met,
        /// Otherwise returns CalculatedRate object
        /// </summary>
        public CalculatedRate getCalculatedRate(DateTime EntryTime, DateTime ExitTime)
        {
            decimal RateTotalPrice = 0;
            
            if (EntryTime.Date == ExitTime.Date &&
                    EntryTime.TimeOfDay >= TIME_ENTRY_FROM && EntryTime.TimeOfDay <= TIME_ENTRY_TO &&
                    ExitTime.TimeOfDay >= TIME_EXIT_FROM && ExitTime.TimeOfDay <= TIME_EXIT_TO)
            {
                RateTotalPrice = RateBasePrice;
                return new CalculatedRate(RateName, RateTotalPrice);
            }
            else return null;
        }
    }
}
