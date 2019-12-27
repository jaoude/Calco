using System.Collections.Generic;

namespace Calco.BLL.Models
{
    public class Square
    {
        public int? Val { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public int Box { get; set; }
        
        public List<int> AllowedValues { get; set; }

        public int Idx { get; set; }
        public Square() { }
        public Square(int? val, int row, int col)
        {
            this.Val = val;
            this.Row = row;
            this.Col = col;
            this.Box = GetBox(row, col);
            AllowedValues = new List<int>();
            Idx = 0;
        }

        private int GetBox(int row, int col)
        {
            if (row < 3)
            {
                if (col < 3) return 1;
                else if (col > 5) return 3;
                else return 2;
            }
            if (row > 5)
            {
                if (col < 3) return 7;
                else if (col > 5) return 9;
                else return 8;
            }
            else
            {
                if (col < 3) return 4;
                else if (col > 5) return 6;
                else return 5;
            }
        }
    }
}
