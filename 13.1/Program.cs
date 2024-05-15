using System;

namespace TaylorSeriesApp
{
    public class Program
    {
        static double x_p, x_k, dx, epsilon, x, seriesSum;
        static int termsCount;

        static void Main(string[] args)
        {
            Console.Write("x_p = ");
            x_p = Convert.ToDouble(Console.ReadLine());

            Console.Write("x_k = ");
            x_k = Convert.ToDouble(Console.ReadLine());

            Console.Write("dx = ");
            dx = Convert.ToDouble(Console.ReadLine());

            Console.Write("epsilon = ");
            epsilon = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("|   x   |   Taylor Series Sum   |   Exact   | n |");
            Console.WriteLine("-------------------------------------------------");

            x = x_p;
            while (x <= x_k)
            {
                seriesSum = CalculateLn(x, epsilon, out termsCount);
                Console.WriteLine($"| {x,5:F2} | {seriesSum,18:F10} | {Math.Log(x),8:F6} | {termsCount,2} |");
                x += dx;
            }

            Console.WriteLine("-------------------------------------------------");
            Console.ReadLine();
        }

        public static double CalculateLn(double x, double epsilon, out int terms)
        {
            double sum = 0.0;
            double term = x - 1;  // Перший доданок
            terms = 0;

            // Обчислення суми ряду з потрібною точністю
            while (Math.Abs(term) > epsilon)
            {
                sum += term;
                terms++;
                term = CalculateNextLnTerm(term, x, terms);
            }

            return sum;
        }

        public static double CalculateNextLnTerm(double currentTerm, double x, int n)
        {
            // Обчислення наступного доданка ряду
            return -currentTerm * (x - 1) / (n + 1);
        }
    }
}


//x_p = 1
//x_k = 2
//dx = 0.1
//epsilon = 0.0001