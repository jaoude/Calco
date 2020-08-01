using Calco.BLL.Commands;
using Calco.BLL.Models;
using Calco.BLL.Services.BoardValidator;
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
        public string Validate(List<int?> values)
        {
            string error = new BoardValidator81Squares(values).IsValid()
                    ?? new BoardValidatorRow(values).IsValid()
                    ?? new BoardValidatorColumn(values).IsValid()
                    ?? new BoardValidatorBox(values).IsValid();
            return error;
        }

        public List<int> Solve(List<int?> values)
        {
            Board board = new Board(values);
            board.Solve();
            return board.Squares.Select(c => c.Val.Value).ToList();
        }
    }
}
