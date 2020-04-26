using NUnit.Framework;
using System;
using CarparkParkingRateCalculator;
using CarparkParkingRateCalculator.RateElements;

namespace CarparkParkingRateCalculatorTestProject
{
    public class RateEarlyBird_UnitTest
    {
        private RateEarlyBird _RateEarlyBird;

        [SetUp]
        public void Setup()
        {
            _RateEarlyBird = new RateEarlyBird();
        }

        [Test]
        public void Test_RateEarlyBird_IsNull01()
        {
            DateTime EntryTime = new DateTime(2020, 04, 22, 8, 59, 20);
            DateTime ExitTime = new DateTime(2020, 04, 23, 16, 20, 20);

            CalculatedRate result = _RateEarlyBird.getCalculatedRate(EntryTime, ExitTime);
            Assert.IsNull(result, "Date Parameters: {0}, {1}", EntryTime, ExitTime);
        }

        [Test]
        public void Test_RateEarlyBird_IsNull02()
        {
            DateTime EntryTime = new DateTime(2020, 04, 23, 5, 59, 59);
            DateTime ExitTime = new DateTime(2020, 04, 23, 23, 20, 20);

            CalculatedRate result = _RateEarlyBird.getCalculatedRate(EntryTime, ExitTime);
            Assert.IsNull(result, "Date Parameters: {0}, {1}", EntryTime, ExitTime);
        }

        [Test]
        public void Test_RateEarlyBird_IsNull03()
        {
            DateTime EntryTime = new DateTime(2020, 04, 23, 6, 0, 0);
            DateTime ExitTime = new DateTime(2020, 04, 23, 23, 30, 1);

            CalculatedRate result = _RateEarlyBird.getCalculatedRate(EntryTime, ExitTime);
            Assert.IsNull(result, "Date Parameters: {0}, {1}", EntryTime, ExitTime);
        }

        [Test]
        public void Test_RateEarlyBird_Result01()
        {
            DateTime EntryTime = new DateTime(2020, 04, 23, 9, 0, 0);
            DateTime ExitTime = new DateTime(2020, 04, 23, 23, 30, 0);

            CalculatedRate result = _RateEarlyBird.getCalculatedRate(EntryTime, ExitTime);
            Assert.AreEqual(_RateEarlyBird.RateBasePrice, result.RateTotalPrice, "Date Parameters: {0}, {1}", EntryTime, ExitTime);
        }

        [Test]
        public void Test_RateEarlyBird_Result02()
        {
            DateTime EntryTime = new DateTime(2020, 04, 23, 6, 0, 0);
            DateTime ExitTime = new DateTime(2020, 04, 23, 15, 30, 0);

            CalculatedRate result = _RateEarlyBird.getCalculatedRate(EntryTime, ExitTime);
            Assert.AreEqual(_RateEarlyBird.RateBasePrice, result.RateTotalPrice, "Date Parameters: {0}, {1}", EntryTime, ExitTime);
        }
    }
}