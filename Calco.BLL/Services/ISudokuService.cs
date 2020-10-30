using Calco.BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;

namespace Calco.BLL.Services
{
    public interface ISudokuService
    {
        SudokuSolverResult Solve(List<int?> values);

    }
}
