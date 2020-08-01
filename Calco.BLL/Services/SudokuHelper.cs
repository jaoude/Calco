using Calco.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static Calco.Common.Constants;

namespace Calco.BLL.Services
{
    public class SudokuHelper : ISudokuHelper
    {
        public List<Square> GetSquares(List<int?> values)
        {
            if (values.Count != NBR_SQUARES_IN_SUDOKU)
                throw new NullReferenceException(WRONG_NBR_OF_SQUARES_ERROR);

            var squares = new List<Square>();
            for (int row = 0; row < NBR_ROWS_IN_SUDOKU; row++)
            {
                for (int col = 0; col < NBR_COLUMNS_IN_SUDOKU; col++)
                {
                    var square = new Square(values[row * 9 + col], row, col);
                    squares.Add(square);
                }
            }
            return squares;
        }
    }
}
