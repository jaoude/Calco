using System;
using System.Collections.Generic;
using System.Text;

namespace Calco.BLL.Helpers
{
    public interface ISolveHelper
    {
        void FillStartingGame(int?[,] numbers);
        void RunGame();
    }
}
