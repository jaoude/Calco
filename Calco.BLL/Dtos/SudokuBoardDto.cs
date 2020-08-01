using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Calco.BLL.Dtos
{
    public class SudokuBoardDto
    {
        public List<int?> SquareValues { get; set; } 
    }
}
