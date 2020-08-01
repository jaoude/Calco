using Calco.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static Calco.Common.Constants;

namespace Calco.BLL.Services
{
    public interface ISudokuHelper
    {
        List<Square> GetSquares(List<int?> values);
    }
}
