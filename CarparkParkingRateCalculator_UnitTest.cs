using NUnit.Framework;
using System;
using CarparkParkingRateCalculator;
using CarparkParkingRateCalculator.RateElements;

namespace CarparkParkingRateCalculatorTestProject
{
    public class CarparkParkingRateCalculator_UnitTest
    {
        private CarparkParkingRateCalculator.CarparkParkingRateCalculator _calculator;
        private CalculatedRate result;

        [SetUp]
        public void Setup()
        {
            _calculator = new CarparkParkingRateCalculator.CarparkParkingRateCalculator();
        }

        [Test]
        public void Test_CarparkParkingRateCalculator_RateEarlyBird01()
        {
            DateTime EntryTime = new DateTime(2020, 04, 23, 9, 0, 0);
            DateTime ExitTime = new DateTime(2020, 04, 23, 23, 30, 0);

            result = _calculator.getParkingRate(EntryTime, ExitTime);
            Assert.AreEqual(new RateEarlyBird().getCalculatedRate(EntryTime, ExitTime).RateTotalPrice, result.RateTotalPrice, "Date Parameters: {0}, {1}", EntryTime, ExitTime);
        }

        [Test]
        public void Test_CarparkParkingRateCalculator_RateNightRate01()
        {
            DateTime EntryTime = new DateTime(2020, 04, 23, 18, 0, 0);
            DateTime ExitTime = new DateTime(2020, 04, 24, 23, 30, 0);

            result = _calculator.getParkingRate(EntryTime, ExitTime);
            Assert.AreEqual(new RateNightRate().getCalculatedRate(EntryTime, ExitTime).RateTotalPrice, result.RateTotalPrice, "Date Parameters: {0}, {1}", EntryTime, ExitTime);
        }

        [Test]
        public void Test_CarparkParkingRateCalculator_RateWeekendRate01()
        {
            DateTime EntryTime = new DateTime(2020, 04, 25, 0, 0, 0);
            DateTime ExitTime = new DateTime(2020, 04, 26, 23, 59, 59);

            result = _calculator.getParkingRate(EntryTime, ExitTime);
            Assert.AreEqual(new RateWeekendRate().getCalculatedRate(EntryTime, ExitTime).RateTotalPrice, result.RateTotalPrice, "Date Parameters: {0}, {1}", EntryTime, ExitTime);
        }

        [Test]
        public void Test_CarparkParkingRateCalculator_RateWeekendRate02()
        {
            DateTime EntryTime = new DateTime(2020, 04, 25, 0, 0, 0);
            DateTime ExitTime = new DateTime(2020, 04, 25, 02, 0, 1);

            result = _calculator.getParkingRate(EntryTime, ExitTime);
            Assert.AreEqual(new RateWeekendRate().getCalculatedRate(EntryTime, ExitTime).RateTotalPrice, result.RateTotalPrice, "Date Parameters: {0}, {1}", EntryTime, ExitTime);
        }

        [Test]
        public void Test_CarparkParkingRateCalculator_RateStandard01()
        {
            DateTime EntryTime = new DateTime(2020, 04, 25, 0, 0, 0);
            DateTime ExitTime = new DateTime(2020, 04, 25, 1, 0, 0);

            result = _calculator.getParkingRate(EntryTime, ExitTime);
            Assert.AreEqual(new RateStandard(5, "0-1 Hours", 0, 1).getCalculatedRate(EntryTime, ExitTime).RateTotalPrice, result.RateTotalPrice, "Date Parameters: {0}, {1}", EntryTime, ExitTime);
        }

        [Test]
        public void Test_CarparkParkingRateCalculator_RateStandard02()
        {
            DateTime EntryTime = new DateTime(2020, 04, 25, 0, 0, 0);
            DateTime ExitTime = new DateTime(2020, 04, 25, 1, 0, 1);

            result = _calculator.getParkingRate(EntryTime, ExitTime);
            Assert.AreEqual(new RateStandard(10, "1-2 Hours", 1, 2).getCalculatedRate(EntryTime, ExitTime).RateTotalPrice, result.RateTotalPrice, "Date Parameters: {0}, {1}", EntryTime, ExitTime);
        }

        [Test]
        public void Test_CarparkParkingRateCalculator_RateStandard03()
        {
            DateTime EntryTime = new DateTime(2020, 04, 23, 11, 0, 0);
            DateTime ExitTime = new DateTime(2020, 04, 23, 13, 0, 1);

            result = _calculator.getParkingRate(EntryTime, ExitTime);
            Assert.AreEqual(new RateStandard(15, "2-3 Hours", 2, 3).getCalculatedRate(EntryTime, ExitTime).RateTotalPrice, result.RateTotalPrice, "Date Parameters: {0}, {1}", EntryTime, ExitTime);
        }

        [Test]
        public void Test_CarparkParkingRateCalculator_RateStandard04()
        {
            DateTime EntryTime = new DateTime(2020, 04, 23, 11, 0, 0);
            DateTime ExitTime = new DateTime(2020, 04, 23, 14, 0, 1);

            result = _calculator.getParkingRate(EntryTime, ExitTime);
            Assert.AreEqual(new RateStandard(20, "3+ Hours", 3, -1).getCalculatedRate(EntryTime, ExitTime).RateTotalPrice, result.RateTotalPrice, "Date Parameters: {0}, {1}", EntryTime, ExitTime);
        }

        [Test]
        public void Test_CarparkParkingRateCalculator_RateStandard05()
        {
            DateTime EntryTime = new DateTime(2020, 04, 23, 11, 0, 0);
            DateTime ExitTime = new DateTime(2020, 04, 23, 14, 0, 1);

            result = _calculator.getParkingRate(EntryTime, ExitTime);
            Assert.AreEqual(new RateStandard(20, "3+ Hours", 3, -1).getCalculatedRate(EntryTime, ExitTime).RateTotalPrice, result.RateTotalPrice, "Date Parameters: {0}, {1}", EntryTime, ExitTime);
        }


    }
}
