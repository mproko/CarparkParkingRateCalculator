using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarparkParkingRateCalculator.RateElements;

namespace CarparkParkingRateCalculator.Controllers
{
    [Route("calc")]
    [ApiController]
    public class CarpartParkingRateCalculatorController : ControllerBase
    {
        private readonly ILogger<CarpartParkingRateCalculatorController> _logger;
        private readonly CarparkParkingRateCalculator _calculator;

        public CarpartParkingRateCalculatorController(ILogger<CarpartParkingRateCalculatorController> logger)
        {
            _logger = logger;
            _calculator = new CarparkParkingRateCalculator();
        }

        // GET: calc
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CalculatedRate> Get()
        {
            return BadRequest();
        }

        // GET: calc/EntryDateTime, ExitDateTime
        [HttpGet("{EntryDateTime},{ExitDateTime}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CalculatedRate> Get(string EntryDateTime, string ExitDateTime)
        {
            DateTime EntryDate = new DateTime(), ExitDate = new DateTime();

            try
            {
                EntryDate = DateTime.Parse(EntryDateTime);
            }
            catch (FormatException)
            {
                _logger.LogError("Unable to convert '{0}'.", EntryDateTime);
                return BadRequest();
            }

            try
            {
                ExitDate = DateTime.Parse(ExitDateTime);
            }
            catch (FormatException)
            {
                _logger.LogError("Unable to convert '{0}'.", ExitDateTime);
                return BadRequest();
            }

            if (EntryDate > ExitDate)
            {
                _logger.LogError("Wrong Date Values: '{0}' > '{1}'.", EntryDate, ExitDate);
                return BadRequest();
            }

            CalculatedRate ParkingRate;

            ParkingRate = _calculator.getParkingRate(EntryDate, ExitDate);
            if (ParkingRate != null)
                return Ok(ParkingRate);
            else
                return NotFound();
        }

    }
}
