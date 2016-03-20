using System;
using static System.Console;
using static System.Math;
using static NewtonMethod.Newton;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
              Print(64, 2);
              Print(64, 3);
              Print(-64, 3);
              Print(1000, 10);
              Print(0, 3); 

              try
              {
                  Print(-64, 2);
              }
              catch (Exception ex)
              {
                  WriteLine(ex.Message);
                  WriteLine();
              }

              try
              {
                  Print(78, -3);

              }
              catch (Exception ex)
              {
                  WriteLine(ex.Message);
                  WriteLine();
              }
            
            ReadKey();
        }
    
        private static void Print(double number, double power)
        {
            WriteLine($"Number: {number}, Power of the root: {power}");
            WriteLine($" Math.Pow: {Pow(number, 1 / power)}");
            WriteLine($"Newton Method: {Root(number, (int)power)}");
        }
    }
}
