using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Calco.BLL.Dtos;
using Calco.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Calco.Client.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalcoController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ISudokuSolver _solver;

        public CalcoController(ILogger<WeatherForecastController> logger, ISudokuSolver sudokuSolver)
        {
            _logger = logger;
            _solver = sudokuSolver;
        }

        [HttpPost]
        public IActionResult Solve([FromBody] List<int?> values)
        {
            string error = _solver.Validate(values);
            if (!string.IsNullOrEmpty(error))
                return BadRequest(new string(error));

            return Ok(_solver.Solve(values));
        }
    }
}