using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");

            var firstIntegerOfTheRange = int.Parse(args[0]);
            var lastIntegerOfTheRange = int.Parse(args[1]);

            var fizzBuzz = new FizzBuzz.FizzBuzzWriter();
            for (int i = firstIntegerOfTheRange; i <= lastIntegerOfTheRange; i++)
            {
                Console.Write(string.Format("{0}{1}",
                                i == firstIntegerOfTheRange ? "" : " ",
                                fizzBuzz.Write(i)));
            }
            Console.WriteLine("");
            Console.Write(fizzBuzz.GenerateReport());
        }
    }
}
