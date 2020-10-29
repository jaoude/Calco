using Calco.BLL.Services.Validator;
using System.Collections.Generic;

namespace Calco.BLL.Services
{
    public class SudokuValidator : ISudokuValidator
    {
        public string Validate(List<int?> values)
        {
            return new BoardValidator().IsValid(values)
                ?? new RowsValidator().IsValid(values)
                ?? new ColumnsValidator().IsValid(values)
                ?? new BoxesValidator().IsValid(values);
        }
    }
}
