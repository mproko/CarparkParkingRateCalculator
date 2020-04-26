using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarparkParkingRateCalculator.RateElements
{
    /// <summary>
    /// Contains 
    /// Iterface that defines contract for each Individual Single Rate.
    /// <param name="RateName">Used to specify used Rate Name</param>
    /// <param name="RateBasePrice">Used to specify Base Rate Price</param>
    /// </summary>
    public class RateStandard : IParkingRate
    {
        private const string RATE_NAME_BASE = "Standard Rate";
        private string _RateName = "";
        private decimal _RateBasePrice = 0;
        private int _HourBlockFrom = 0;
        private int _HourBlockTo = 0;

        public string RateName { get => _RateName; }
        public decimal RateBasePrice { get => _RateBasePrice; }

        public RateStandard(decimal StandardRate, string StandardNameType, int StandardBlockFrom, int StandardBlockTo)
        {
            _RateBasePrice = StandardRate;
            _RateName = RATE_NAME_BASE + " " + StandardNameType;
            _HourBlockFrom = StandardBlockFrom;
            _HourBlockTo = StandardBlockTo;
        }

        public CalculatedRate getCalculatedRate(DateTime EntryTime, DateTime ExitTime)
        {
            decimal RateTotalPrice = 0;

            TimeSpan timeInterval = ExitTime - EntryTime;

            if ((_HourBlockFrom == -1 || timeInterval.TotalHours > _HourBlockFrom) &&
                    (_HourBlockTo == -1 || timeInterval.TotalHours <= _HourBlockTo))
            {
                if (_HourBlockTo == -1)
                {
                    // If StandardBlockTo value is -1 then 
                    // add _RateBasePrice rate amount to the RateTotalPrice value
                    // for each calendar day of parking. 
                    // Count the first and the last day as speacial cases.
                    // Need to stay at list StandardBlockFrom hours longer 
                    // in the first or in the last day in order each one to be  
                    // included as additional _RateBasePrice value 
                    // inside the RateTotalPrice value.

                    if (EntryTime.Day == EntryTime.AddHours(_HourBlockFrom).Day)
                    {
                        RateTotalPrice += RateBasePrice;
                    }
                    if (ExitTime.Date != EntryTime.Date && ExitTime.Day == ExitTime.AddHours(-1 * _HourBlockFrom).Day)
                    {
                        RateTotalPrice += RateBasePrice;
                    }
                    if (RateTotalPrice == 0) RateTotalPrice = RateBasePrice;
                    timeInterval = new DateTime(ExitTime.Year, ExitTime.Month, ExitTime.Day) 
                           - new DateTime(EntryTime.Year, EntryTime.Month, EntryTime.Day);
                    
                    if (timeInterval.Days - 1 > 0) RateTotalPrice += (timeInterval.Days - 1) * RateBasePrice;

                }
                else RateTotalPrice = RateBasePrice;
                return new CalculatedRate(RateName, RateTotalPrice);
            }
            else return null;
        }

    }
}
