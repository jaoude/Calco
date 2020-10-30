using Calco.BLL.Services.Validator;
using System.Collections.Generic;

namespace Calco.BLL.Services
{
    public class SudokuValidator : ISudokuValidator
    {
        private readonly ISudokuHelper _sudokuHelper;

        public SudokuValidator(ISudokuHelper sudokuHelper)
        {
            _sudokuHelper = sudokuHelper;
        }

        public string Validate(List<int?> values)
        {
            return new BoardValidator().IsValid(values)
                ?? new RowsValidator(_sudokuHelper).IsValid(values)
                ?? new ColumnsValidator(_sudokuHelper).IsValid(values)
                ?? new BoxesValidator(_sudokuHelper).IsValid(values);
        }
    }
}
