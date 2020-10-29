using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Calco.Common.Constants;

namespace Calco.BLL.Services.Validator
{
    public class BoxesValidator
    {
        public string IsValid(List<int?> values)
        { 
            return (new SudokuHelper().GetSquares(values)
                .Where(c => c.Val != null)
                .GroupBy(c => new { c.Val, c.Box })
                .Where(g => g.Count() > 1).Any())
            ? DUPLICATES_IN_BOX_ERROR
            : null;
        }
    }
}
