using Calco.BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Calco.BLL.Services
{
    public interface ISudokuSolver
    {
        List<int> Solve(List<int?> squareValues);

        string Validate(List<int?> values);
    }
}
