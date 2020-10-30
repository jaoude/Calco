using System;
using System.Collections.Generic;
using System.Text;

namespace Calco.BLL.Models
{
    public interface ISudokuSolver
    {
        SudokuSolverResult Solve(List<int?> values);
    }
}
