using System;

namespace Task1GemsDev
{
    public class SquareEquations
    {
        public static void EquationSolution(double arg1, double arg2, double arg3) // решение
        {
            var a = arg1;
            var b = arg2;
            var c = arg3;

            double x1, x2;
            var d = Math.Pow(b, 2) - 4 * a * c; // дискриминант
            Console.WriteLine($"D = {d}\n");
            if (d < 0)
                Console.WriteLine($"В квадратном уравнении {a}x^2+{b}x+{c} нет корней\n");
            else if (d > 0)
            {
                x1 = (-b + Math.Sqrt(d)) / (2 * a);
                x2 = (-b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine($"В квадратном уравнении с аргументами {a}x^2+{b}x+{c} два разных корня: x1 = {x1}, x2 = {x2}\n");
            }
            else
            {
                x1 = -b / (2 * a);
                x2 = x1;
                Console.WriteLine($"В квадратном уравнении с аргументами {a}x^2+{b}x+{c} два одинаковых корня: x1 = {x1}, x2 = {x2}\n");
            }
        }
    }
}
