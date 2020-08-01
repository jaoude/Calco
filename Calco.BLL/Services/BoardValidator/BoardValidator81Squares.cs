using System;
using System.Collections.Generic;
using System.Text;
using static Calco.Common.Constants;

namespace Calco.BLL.Services.BoardValidator
{
    public class BoardValidator81Squares : BoardValidator
    {
        public static string Error = WRONG_NBR_OF_SQUARES_ERROR;

        public BoardValidator81Squares(List<int?> values) : base(values) { }

        public override string IsValid()
        {
            if (Values.Count == NBR_SQUARES_IN_SUDOKU)
                return null;

            return Error;
        }
    }
}
