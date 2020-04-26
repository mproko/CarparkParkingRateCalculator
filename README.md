# CarparkParkingRateCalculator
CarparkParkingRateCalculator Demonstration Code

Setup as ASP.NET Core Web API function: 
// GET: calc/EntryDateTime, ExitDateTime

•	CarparkParkingRateCalculator Class is the main Class designed to complete the calculation and create the output result. It initialises and contains links to all other classes and is using their functionality to creates the output.
•	CarparkParkingRateCalculator.getParkingRate is the main method for the calculation based on provided EntryDate and ExitDate values.
•	Result Parking Rate is returned as CalculatedRate Object.
•	Each Individual CarPark Rate is defined as Individual Rate Class and they all implement the IParkingRate Interface. These are the Classes: RateEarlyBird, RateNightRate, RateWeekendRate and RateStandard.
•	CarparkParkingRateCalculator Class contains RateList ArrayList which holds all of the Individual Rate Class (RateStandard is created and included 4 times, each time for different Hourly Interval Type: "0-1 Hours", "1-2 Hours", "2-3 Hours" and "3+ Hours").
•	CarparkParkingRateCalculator.getParkingRate Method for selected pair of EntryDate and ExitDate (DateTime) values, calls every Rate Element from RateList ArrayList and select result from the one which returns lowest RateTotalPrice value.
•	This way the setup for each Individual Rate Class is separate from the others and sits in single file together with their parameters. This way each Rate change or updated is only done in one place and is easy to add new Types of Rate with minimal impact on the rest of the project.
•	CarparkParkingRateCalculatorUML.jpeg is picture of UML diagram and it shows links between the classes.
•	For demonstration, comments are only included for RateEarlyBird and CarparkParkingRateCalculator Classes.
•	CarparkParkingRateCalculatorTestProject Project is used for Unit Testing. It contains test cases only for two Classes: RateEarlyBird and CarparkParkingRateCalculator, and it covers only subset of the tests for each one (only for demonstration).
 
