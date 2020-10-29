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
    public class SudokuSolver : ISudokuSolver
    {
        public readonly ISudokuValidator _sudokuValidator;
        public SudokuSolver(ISudokuValidator sudokuValidator)
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
                    Success = true,
                    Solution = null
                };

            Board board = new Board(values.ToList());
            board.Solve();

            return new SudokuSolverResult()
            {
                Message = null,
                Success = true,
                Solution = board.Squares.Select(c => c.Val.Value).ToList()
            };
        }
    }
}
