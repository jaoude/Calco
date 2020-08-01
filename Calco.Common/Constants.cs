using System;

namespace Calco.Common
{
    public static class Constants
    {
        public const int NBR_SQUARES_IN_SUDOKU = NBR_ROWS_IN_SUDOKU * NBR_COLUMNS_IN_SUDOKU;
        public const int NBR_ROWS_IN_SUDOKU = 9;
        public const int NBR_COLUMNS_IN_SUDOKU = 9;
        public const string WRONG_NBR_OF_SQUARES_ERROR = "The number of squares passed is not 9 rows by 9 columns i.e. 81 squares";
        public const string DUPLICATES_IN_ROW_ERROR = "DUPLICATES_IN_ROW_ERROR";
        public const string DUPLICATES_IN_COLUMN_ERROR = "DUPLICATES_IN_COLUMN_ERROR";
        public const string DUPLICATES_IN_BOX_ERROR = "DUPLICATES_IN_BOX_ERROR";
    }
}
