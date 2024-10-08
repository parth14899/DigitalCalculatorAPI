using DigitalCalculatorAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCalculatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DigitalCalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public DigitalCalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet("add")]
        public ActionResult<double> Add(double a, double b)
        {
            return _calculatorService.Add(a, b);
        }

        [HttpGet("subtract")]
        public ActionResult<double> Subtract(double a, double b)
        {
            return _calculatorService.Subtract(a, b);
        }

        [HttpGet("multiply")]
        public ActionResult<double> Multiply(double a, double b)
        {
            return _calculatorService.Multiply(a, b);
        }

        [HttpGet("divide")]
        public ActionResult<double> Divide(double a, double b)
        {
            try
            {
                return _calculatorService.Divide(a, b);
            }
            catch (DivideByZeroException)
            {
                return BadRequest("Division by zero is not allowed.");
            }
        }
    }
}
