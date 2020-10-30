using Calco.BLL.Commands;
using Calco.BLL.Models;
using Calco.BLL.Services.Validator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using static Calco.Common.Constants;

namespace Calco.BLL.Services
{
    public class SudokuService : ISudokuService
    {
        public readonly ISudokuValidator _sudokuValidator;
        public readonly ISudokuSolver _sudokuSolver;
        public SudokuService(ISudokuValidator sudokuValidator)
        {
            _sudokuValidator = sudokuValidator;
        }

        public SudokuSolverResult Solve(List<int?> values)
        {
            var validate = _sudokuValidator.Validate(values);
            if (!string.IsNullOrEmpty(validate))
                return new SudokuSolverResult()
                {
                    Message = validate,
                    Success = false,
                    Solution = null
                };

            var result = _sudokuSolver.Solve(values);

            return result;
        }
    }
}
