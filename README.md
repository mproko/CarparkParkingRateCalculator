# CarparkParkingRateCalculator
CarparkParkingRateCalculator Demonstration Code

Setup as ASP.NET Core Web API function: 
// GET: calc/EntryDateTime, ExitDateTime

CarparkParkingRateCalculator Class is the core object which uses the rest of the objects for the calcualtion. 
CarparkParkingRateCalculator.getParkingRate is the main method which calculate the Parking Rate based on provided EntryDate and ExitDate values.
Result Parking Rate is returned as CalculatedRate Object.
Each Individual CarPark Rate is defined as Individual Rate Class and they all implement the IParkingRate Interface. These are the Classes: RateEarlyBird, RateNightRate, RateWeekendRate and RateStandard.
CarparkParkingRateCalculator Class contains RateList ArrayList which holds all of the Individual Rate Class (RateStandard is included 4 times, each time for different Hourly Interval Type).
CarparkParkingRateCalculator.getParkingRate Method for selected pair of EntryDate and ExitDate (DateTime) values, calls every Rate Element from RateList ArrayList and select result from the one which returns lowes RateTotalPrice value.

This way each Individual Rate Class is separate in own file and their values are only setup in one location. This way will be easy to add new Types of Rates or modify existing ones without having impact on the rest of the project. 

CarparkParkingRateCalculatorUML.jpeg is picture of UML diagram which shows how classes are linked together.

For demostration, comments are only included RateEarlyBird and CarparkParkingRateCalculator Classes. 
CarparkParkingRateCalculatorTestProject Project for Unit Testing in only created for the RateEarlyBird and CarparkParkingRateCalculator Classes too, and it covers only subset of the tests. 
