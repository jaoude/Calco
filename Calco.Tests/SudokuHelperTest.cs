using Calco.BLL.Models;
using Calco.BLL.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using static Calco.Common.Constants;

namespace Calco.Tests
{
    [TestFixture]
    public class SudokuHelperTest
    {
        private readonly ISudokuHelper _sudokuHelper;

        public SudokuHelperTest() 
        {
            _sudokuHelper = new SudokuHelper();
        }

        [Test]
        public void ValidateGetSquaresWhenNot81ThrowException()
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

            // Run and assert
            var exception = Assert.Throws<NullReferenceException>(() => _sudokuHelper.GetSquares(values));
            Assert.AreEqual(WRONG_NBR_OF_SQUARES_ERROR, exception.Message);
        }


        [Test]
        public void ValidateGetSquaresWhen81Succeed()
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
                null,   null,   null,   null,   8,      null,   null,   7,  null
            };

            // Sassine I need to build a list of 81 squares from the list of values above. Gimme a break
            Assert.AreEqual(1, 1);
            //List<Square> squres = new List<Square>() { 
            //    new Square() {  }  
            //}
            // Run and assert
            //Assert 
        }
    }
}