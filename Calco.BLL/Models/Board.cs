using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calco.BLL.Models
{
    public class Board
    {
        public List<Square> Squares { get; set; }
        public List<LinkedSquare> LinkedSquares { get; set; }

        private List<int> _possibleValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private int BoardNumberOfSquares = 81;

        #region  Constructor
        public Board(int?[,] a)
        {
            Squares = new List<Square>();
            LinkedSquares = new List<LinkedSquare>();


            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var square = new Square(a[i, j], i, j);
                    Squares.Add(square);
                }
            }
            
            foreach ( var square in Squares.Where(c => !c.Val.HasValue).OrderBy(c => this.GetAllowedValues(c).Count).ToList())
            {
                if (!LinkedSquares.Any())
                    LinkedSquares.Add(new LinkedSquare(square));
                else
                {
                    var linkedSquare = new LinkedSquare(square);
                    LinkedSquare lastLinkedSquare = LinkedSquares.Last();
                    lastLinkedSquare.Next = linkedSquare;
                    linkedSquare.Previous = lastLinkedSquare;

                    LinkedSquares.Add(linkedSquare);
                }
            }
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


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int idx = 0;
            while (idx < BoardNumberOfSquares)
            {
                if (idx % 9 == 0)
                    sb.Append(System.Environment.NewLine);
                sb.Append(Squares[idx].Val.HasValue ? " " + Squares[idx].Val.ToString() + " " : string.Empty + "   ");

                idx++;
            }
            string result = sb.ToString();
            return result;
        }

        public List<int> GetAllowedValues(Square square)
        {
            List<int> allowedValues = new List<int>();

            if (square.Val.HasValue)
                return null;

            foreach(int val in _possibleValues)
            {
                square.Val = val;
                if (this.IsValid())
                {
                    allowedValues.Add(val);
                }
                square.Val = null;
            }

            return allowedValues;
        }

    }
}
