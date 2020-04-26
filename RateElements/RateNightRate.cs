using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarparkParkingRateCalculator.RateElements
{
    public class RateNightRate : IParkingRate
    {
        // Constant Parameters
        private TimeSpan TIME_ENTRY_FROM = new TimeSpan(18, 0, 0);
        private TimeSpan TIME_ENTRY_TO = new TimeSpan(23, 59, 59);
        private TimeSpan TIME_EXIT_FROM = new TimeSpan(15, 30, 0);
        private TimeSpan TIME_EXIT_TO = new TimeSpan(23, 30, 0);

        private string _RateName = "Night Rate";
        private decimal _RateBasePrice = 6.5m;

        public string RateName { get => _RateName; }
        public decimal RateBasePrice { get => _RateBasePrice; }

        public RateNightRate() { }

        public RateNightRate(string RateName, decimal RateBasePrice)
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

        public CalculatedRate getCalculatedRate(DateTime EntryTime, DateTime ExitTime)
        {
            decimal RateTotalPrice = 0;

            if((EntryTime.DayOfWeek != DayOfWeek.Saturday) && (EntryTime.DayOfWeek != DayOfWeek.Sunday) &&
                    ExitTime.Date == EntryTime.Date.AddDays(1) &&
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
