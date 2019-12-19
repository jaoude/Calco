﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calco.BLL.Models
{
    public class Board
    {
        private List<Square> Squares = new List<Square>();
        private List<int> _possibleValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private int BoardNumberOfSquares = 81;

        #region  Constructor
        public Board(int?[,] a)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Squares.Add(new Square(a[i, j], i, j));
                }
            }
        }
        #endregion

        public void Solve()
        {
            foreach (var square in Squares)
            {
                var list = GetAllowedValues(square);
            }
        }

        public void Guess(Square square)
        {
            if (!square.Val.HasValue)
            {
                square.Val = _possibleValues.FirstOrDefault(val => Validate());
            }
        }

        public bool IsValid(Square square)
        {
            if (Squares.Where(sq => sq.Row == square.Row && sq.Val.HasValue).GroupBy(n => n.Val).Any(c => c.Count() > 1)
                || Squares.Where(sq => sq.Col == square.Col && sq.Val.HasValue).GroupBy(n => n.Val).Any(c => c.Count() > 1)
                || Squares.Where(sq => sq.Box == square.Box && sq.Val.HasValue).GroupBy(n => n.Val).Any(c => c.Count() > 1))
                return false;
            else
                return true;
        }

        public bool Validate()
        {
            return false;
            // return Squares.Sum(sq => IsValid(sq) == true);
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
                if (IsValid(square))
                {
                    allowedValues.Add(val);
                }
            }

            return allowedValues;
        }
    }
}
