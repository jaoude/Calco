using System;
using System.Collections.Generic;
using System.Text;
using static Calco.Common.Constants;

namespace Calco.BLL.Services.Validator
{
    public class BoardValidator
    {
        public string IsValid(List<int?> values) => values.Count == NBR_SQUARES_IN_SUDOKU ? null : WRONG_NBR_OF_SQUARES_ERROR;
    }
}
