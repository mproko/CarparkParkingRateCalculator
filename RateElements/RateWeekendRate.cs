using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarparkParkingRateCalculator.RateElements
{
    public class RateWeekendRate : IParkingRate
    {
        // Constant Parameters
        private DayOfWeek[] _WeekendDays = {
            DayOfWeek.Sunday,
            DayOfWeek.Saturday };
        private int MAX_DAYS = 2;

        private string _RateName = "Weekend Rate";
        private decimal _RateBasePrice = 10;

        public string RateName { get => _RateName; }
        public decimal RateBasePrice { get => _RateBasePrice; }

        public RateWeekendRate() { }

        public RateWeekendRate(string RateName, decimal RateBasePrice)
        {
            _RateName = RateName;
            _RateBasePrice = RateBasePrice;
        }

        public void setTimeParameters(DayOfWeek[] WeekendDays)
        {
            _WeekendDays = WeekendDays;
            MAX_DAYS = _WeekendDays.Length;
        }

        public CalculatedRate getCalculatedRate(DateTime EntryTime, DateTime ExitTime)
        {
            decimal RateTotalPrice = 0;
            bool isWeekendEntry = false, isWeekendExit = false;
            TimeSpan timeInterval = ExitTime - EntryTime;

            foreach (DayOfWeek day in _WeekendDays)
            {
                if (EntryTime.DayOfWeek == day) isWeekendEntry = true;
                if (ExitTime.DayOfWeek == day) isWeekendExit = true;
            }
            if (timeInterval.Days <= MAX_DAYS && isWeekendEntry && isWeekendExit)
            {
                RateTotalPrice = RateBasePrice;
                return new CalculatedRate(RateName, RateTotalPrice);
            }
            else return null;
        }
    }
}
