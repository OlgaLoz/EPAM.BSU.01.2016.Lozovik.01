using System;
using static System.Math;

namespace NewtonMethod
{
    public static class Newton
    {
        public static double Root(double number, int power, double eps = 1e-10)
        {
            if (power <= 1)
            {
                throw new ArgumentException("Power must be higher than 1!");
            }

            if (eps <= 0)
            {
                throw new ArgumentException("Accuracy of the calculation must be positive!");
            }

            if ((power % 2 == 0) && (number < 0))
            {
                throw new ArgumentException("Negative number! Even power!");
            }

            if (number == 0)
            {
                return 0;
            }

            double x1 = 1;  
            double x = Pow(power, -1) * ((power - 1) * x1 + number / Pow(x1, power - 1));

            while (Abs(x - x1) > eps)
            {
                x1 = x;
                x = Pow(power, -1) * ((power - 1) * x1 + number / Pow(x1, power - 1));
            }
            return x;           
        }
    }
}
