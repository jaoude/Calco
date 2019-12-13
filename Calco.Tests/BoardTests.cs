using Calco.BLL.Models;
using NUnit.Framework;

namespace Calco.Tests
{
    [TestFixture]
    public class BoardTests
    {

        int?[,] a = new int?[9, 9];
        
       
        public void Setup()
        { 
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    a[i, j] = null;

            a[0, 0] = 5; a[0, 1] = 3; a[0, 4] = 7;
            a[1, 0] = 6; a[1, 3] = 1; a[1, 4] = 9; a[1, 5] = 5;
            a[2, 1] = 9; a[2, 2] = 8; a[2, 7] = 6;

            a[3, 0] = 8; a[3, 4] = 6; a[3, 8] = 3;
            a[4, 0] = 4; a[4, 3] = 8; a[4, 5] = 3; a[4, 8] = 1;
            a[5, 0] = 7; a[5, 4] = 2; a[5, 8] = 6;

            a[6, 1] = 6; a[6, 6] = 2; a[6, 7] = 8;
            a[7, 3] = 4; a[7, 4] = 1; a[7, 5] = 9; a[7, 8] = 5;
            a[8, 4] = 8; a[8, 7] = 7; a[8, 8] = 9;

        }

        [Test]
        public void AssertTostringReturns()
        {
            // Prepare
            Setup();
            Board board = new Board(a);

            string expectedResult = "\r\n5\t3\t\t\t7\t\t\t\t\t\r\n6\t\t\t1\t9\t5\t\t\t\t\r\n\t9\t8\t\t\t\t\t6\t\t\r\n8\t\t\t\t6\t\t\t\t3\t\r\n4\t\t\t8\t\t3\t\t\t1\t\r\n7\t\t\t\t2\t\t\t\t6\t\r\n\t6\t\t\t\t\t2\t8\t\t\r\n\t\t\t4\t1\t9\t\t\t5\t\r\n\t\t\t\t8\t\t\t7\t9\t";

            //  Assert.Pass();
            string actualResult = board.ToString();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}