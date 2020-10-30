using Calco.BLL.Commands;
using Calco.BLL.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Calco.BLL.Models
{

    public class SudokuSolver : ISudokuSolver
    {     
        protected internal List<Square> Squares { get; set; }
        protected internal LinkedList<Square> LinkedSquares { get; set; }

        private static readonly List<int> _possibleValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        #region  Constructor
        private void Init(List<int?> values)
        {
            Squares = new SudokuHelper().GetSquares(values);
            LinkedSquares = new LinkedList<Square>();
            Squares.Where(c => !c.Val.HasValue).ToList().ForEach(sqr => LinkedSquares.AddLast(sqr));
        }
        #endregion


        public bool IsValid()
        {
            foreach (var square in this.Squares)
            {
                if (Squares.Where(sq => sq.Row == square.Row && sq.Val.HasValue).GroupBy(n => n.Val).Any(c => c.Count() > 1)
                    || Squares.Where(sq => sq.Col == square.Col && sq.Val.HasValue).GroupBy(n => n.Val).Any(c => c.Count() > 1)
                    || Squares.Where(sq => sq.Box == square.Box && sq.Val.HasValue).GroupBy(n => n.Val).Any(c => c.Count() > 1))
                    return false;
            }
            return true;
        }

        public void GetAllowedValues(Square square)
        {
            square.AllowedValues = new List<int>();

            if (square.Val.HasValue)
                return;

            foreach(int val in _possibleValues)
            {
                square.Val = val;
                if (this.IsValid())
                {
                    square.AllowedValues.Add(val);
                }
                square.Val = null;
            }
        }

        public SudokuSolverResult Solve(List<int?> values)
        {
            Init(values);

            var square = LinkedSquares.First;
            square.Value.Idx = 0;
            GetAllowedValues(square.Value);
            square.Value.Val = square.Value.Val.HasValue ? square.Value.Val.Value : square.Value.AllowedValues[square.Value.Idx];
            var manager = new CommandManager();
            manager.Invoke(new ToNextCommand(this, square, manager));

            return new SudokuSolverResult()
            {
                Message = null,
                Success = true,
                Solution = this.Squares.Select(c => c.Val.Value).ToList()
            };
        }
    }
}
