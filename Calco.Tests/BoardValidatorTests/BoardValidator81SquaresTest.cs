using Calco.BLL.Models;
using Calco.BLL.Services;
using Calco.BLL.Services.BoardValidator;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using static Calco.Common.Constants;

namespace Calco.Tests.BoardValidatorTests
{
    public class BoardValidator81SquaresTest
    {
        private IBoardValidator _boardValidator81Squares;

        public BoardValidator81SquaresTest()
        { }
           
        [Test]
        public void AssertIsValid()
        {
            // Prepare
            List <int?> values = new List<int?>
            {
                5,      3,      4,      null,   7,      null,   null,   null,   null,
                6,      null,   null,   1,      9,      5,      null,   null,   null,
                5,      9,      8,      null,   null,   null,   null,   6,      null,
                8,      null,   null,   null,   6,      null,   null,   null,   3,
                4,      2,      6,      8,      5,      3,      7,      9,      1,
                7,      null,   null,   null,   2,      null,   null,   null,   6,
                null,   6,      null,   null,   null,   null,   2,      8,      null,
                null,   null,   null,   4,      1,      9,      null,   null,   5,
                null,   null,   null,   null,   8,      null,   null,   7,      9
            };
            
            _boardValidator81Squares = new BoardValidator81Squares(values);
            
            // Run
            var result = _boardValidator81Squares.IsValid();

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void AssertIsNotValid()
        {
            // Prepare
            List<int?> values = new List<int?>
            {
                5,      3,      4,      null,   7,      null,   null,   null,   null,
                6,      null,   null,   1,      9,      5,      null,   null,   null,
                5,      9,      8,      null,   null,   null,   null,   6,      null,
                8,      null,   null,   null,   6,      null,   null,   null,   3,
                4,      2,      6,      8,      5,      3,      7,      9,      1,
                7,      null,   null,   null,   2,      null,   null,   null,   6,
                null,   6,      null,   null,   null,   null,   2,      8,      null,
                null,   null,   null,   4,      1,      9,      null,   null,   5,
                null,   null,   null,   null,   8,      null,   null,   7
            };

            _boardValidator81Squares = new BoardValidator81Squares(values);

            // Run
            var result = _boardValidator81Squares.IsValid();

            // Assert
            Assert.AreEqual(result, WRONG_NBR_OF_SQUARES_ERROR);
        }
    }
}
