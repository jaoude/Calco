using Calco.BLL.Models;
using System;

namespace Calco.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            int?[,] a = new int?[9, 9];
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


            Console.WriteLine("Hello World!");
            Board board = new Board(a);

            Console.WriteLine(board.ToString());
            Console.ReadKey();
        }
    }
}
