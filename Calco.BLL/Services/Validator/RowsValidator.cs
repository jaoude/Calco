﻿using System.Collections.Generic;
using System.Linq;
using static Calco.Common.Constants;

namespace Calco.BLL.Services.Validator
{
    public class RowsValidator : IValidator
    {
        private readonly ISudokuHelper _sudokuHelper;
        public RowsValidator(ISudokuHelper sudokuHelper)
        {
            _sudokuHelper = sudokuHelper;
        }

        public string IsValid(List<int?> values)
        {
            var duplicate = _sudokuHelper.GetSquares(values)
                .Where(c => c.Val != null)
                .GroupBy(c => new { c.Val, c.Row })
                .Where(g => g.Count() > 1);

            if (duplicate.Any())
                return DUPLICATES_IN_ROW_ERROR;

            return null;
        }
    }
}
