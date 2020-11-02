using Calco.BLL.Services;
using Calco.BLL.Services.Validator;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using static Calco.Common.Constants;

namespace Calco.Tests.Bll.Services.Validator
{
    public class RowsValidatorTests
    {
        private readonly ISudokuHelper _sudokuHelper;
        private readonly RowsValidator _rowsValidator;
        public RowsValidatorTests()
        {
            _sudokuHelper = new SudokuHelper();
            _rowsValidator = new RowsValidator(_sudokuHelper);

        }

        [Fact]
        public void IsValid_ShouldReturnNull_WhenBoardIsValid()
        {
            //Prepare
            List<int?> values = new List<int?>
            {
                5,      3,      4,      null,   7,      null,   null,   null,   null,
                6,      null,   null,   1,      9,      5,      null,   null,   null,
                null,   9,      8,      null,   null,   null,   null,   6,      null,
                8,      null,   null,   null,   6,      null,   null,   null,   3,
                4,      2,      6,      8,      5,      3,      7,      9,      1,
                7,      null,   null,   null,   2,      null,   null,   null,   6,
                null,   6,      null,   null,   null,   null,   2,      8,      null,
                null,   null,   null,   4,      1,      9,      null,   null,   5,
                null,   null,   null,   null,   8,      null,   null,   7,      9
            };

            // Act/ Assert
            _rowsValidator.IsValid(values).Should().BeNull();
        }

        [Fact]
        public void IsValid_ShouldReturnError_WhenBoardIsInValid()
        {
            // Prepare
            List<int?> values = new List<int?>
            {
                5,      3,      4,      null,   7,      null,   null,   null,   null,
                6,      null,   null,   1,      9,      5,      null,   null,   null,
                null,   9,      8,      null,   null,   null,   null,   6,      null,
                8,      null,   null,   null,   6,      null,   null,   null,   3,
                4,      2,      6,      8,      5,      3,      7,      9,      1,
                7,      null,   null,   null,   2,      null,   null,   null,   6,
                null,   6,      null,   null,   null,   null,   2,      8,      null,
                null,   null,   null,   4,      1,      9,      null,   null,   5,
                null,   8,   null,   null,   8,      null,   null,   7,      9
            };

            // Act/ Assert
            _rowsValidator.IsValid(values).Should().Be(DUPLICATES_IN_ROW_ERROR);
        }
    }
}