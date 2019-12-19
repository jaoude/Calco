using Calco.BLL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Calco.BLL.Helpers
{
    public class SolveHelper : ISolveHelper
    {

        private Board _board = null;

        public void Solve(Board board, Square square, List<int> values, int idx)
        {
            if (board.Squares.Count(sq => !sq.Val.HasValue) == 0)
                return;

            if (square == null)
            {
                square = board.Squares.FirstOrDefault(sq => !sq.Val.HasValue);
                var allowedValues = board.GetAllowedValues(square);
                Solve(board, square, allowedValues, 0);
            }
            square.Val = values[idx];
            if (board.IsValid() && board.GetAllowedValues(square) != null && board.GetAllowedValues(square).Count > 0) 
            {
                var squareNext = board.Squares.FirstOrDefault(sq => !sq.Val.HasValue);
                var allowedValues = board.GetAllowedValues(squareNext);
                if (allowedValues.Count > 0)
                    Solve(board, squareNext, allowedValues, 0);
                else
                {
                    idx++;
                    Solve(board, square, values, idx);
                }

            }
            else
            {
                idx++;
                Solve(board, square, values, idx);
            }
        }
    }
}
