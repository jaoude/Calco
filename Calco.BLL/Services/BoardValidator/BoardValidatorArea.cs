using Calco.BLL.Models;
using System.Collections.Generic;
using static Calco.Common.Constants;

namespace Calco.BLL.Services.BoardValidator
{
    public abstract class BoardValidatorArea : BoardValidator
    {
        protected internal List<Square> Squares;

        public BoardValidatorArea(List<int?> values) : base(values) 
        {
            Squares = new SudokuHelper().GetSquares(values);
        }

        public abstract override string IsValid();
    }
}
