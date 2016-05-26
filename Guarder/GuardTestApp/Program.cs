using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guarder;
namespace GuardTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool success = false;

            while (!success)
            {
                try
                {
                    Console.WriteLine("Enter a number less than 100");
                    string strNum = Console.ReadLine();
                    Guard.IsInt(strNum, "strNum");
                    PrintNumbersFromVarTo100(Convert.ToInt32(strNum));
                    success = true;
                }
                catch (ArgumentException aEx)
                {
                    Console.WriteLine(aEx.Message);
                }
            }
            Console.ReadLine();
        }


        static void PrintNumbersFromVarTo100(int var)
        {
            Guard.LessThan(var, 100, "var");

            for (int x = var; x <= 100; x++)
            {
                Console.WriteLine(x);
            }
        }
    }
}
