using Calco.BLL.Helpers;
using System;

namespace Calco.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IBoardLoadHelper load = new BoardLoadHelper();
            Console.WriteLine(load.DoOCR());
            Console.ReadKey();
        }
    }
}
