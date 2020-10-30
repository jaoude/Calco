using System.Collections.Generic;
using System.Linq;
using static Calco.Common.Constants;

namespace Calco.BLL.Services.Validator
{
    public class ColumnsValidator : IValidator
    {
        private readonly ISudokuHelper _sudokuHelper;
        
        public ColumnsValidator(ISudokuHelper sudokuHelper)
        {
            _sudokuHelper = sudokuHelper;
        }

        public string IsValid(List<int?> values)
        {
            var duplicate = _sudokuHelper.GetSquares(values)
                .Where(c => c.Val != null)
                .GroupBy(c => new { c.Val, c.Col })
                .Where(g => g.Count() > 1);

            if (duplicate.Any())
                return DUPLICATES_IN_COLUMN_ERROR;

            return null;
        }
    }
}
