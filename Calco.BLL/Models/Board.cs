using Calco.BLL.Commands;
using Calco.BLL.Services;
using Calco.BLL.Services.BoardValidator;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calco.BLL.Models
{
    public class Board
    {     
        protected internal List<Square> Squares { get; set; }
        protected internal LinkedList<Square> LinkedSquares { get; set; }

        private readonly List<int> _possibleValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        #region  Constructor
        public Board(List<int?> values)
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

        public void Solve()
        {
            if (Squares.Count(sq => !sq.Val.HasValue) == 0)
                return;

            var square = LinkedSquares.First;
            square.Value.Idx = 0;
            GetAllowedValues(square.Value);
            square.Value.Val = square.Value.Val.HasValue ? square.Value.Val.Value : square.Value.AllowedValues[square.Value.Idx];
            var manager = new CommandManager();
            manager.Invoke(new ToNextCommand(this, square, manager));
        }
    }
}
