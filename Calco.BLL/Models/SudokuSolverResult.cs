using System;
using System.Collections.Generic;
using System.Text;

namespace Calco.BLL.Models
{
    public class SudokuSolverResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IList<int> Solution { get; set; }
    }
}
