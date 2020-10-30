using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Calco.BLL.Dtos;
using Calco.BLL.Services;
using Calco.BLL.Services.Validator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Calco.Client.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalcoController : ControllerBase
    {
        private readonly ILogger<CalcoController> _logger;
        private readonly ISudokuService _sudokuSolver;

        public CalcoController(ILogger<CalcoController> logger, ISudokuService sudokuSolver)
        {
            _logger = logger;
            _sudokuSolver = sudokuSolver;
        }

        [HttpPost]
        public IActionResult Solve([FromBody] List<int?> values)
        {
            var result = _sudokuSolver.Solve(values);

            if(result.Success)
                return Ok(result.Solution);
            else
                return BadRequest(result.Message);
        }
    }
}