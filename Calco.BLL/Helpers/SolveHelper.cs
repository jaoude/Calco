using Calco.BLL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Calco.BLL.Helpers
{
    public class SolveHelper : ISolveHelper
    {


        private Board _board = null;

        public SolveHelper() { }

        public void FillStartingGame( int?[,] numbers)
        {
            _board = new Board(numbers);
        }

        public void RunGame()
        {
            _board.Solve();
        }
    }
}
