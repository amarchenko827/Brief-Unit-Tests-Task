using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Task1GemsDev
{
    public class DataGet : SquareEquations
    {
        public static void KeyboardEquation()
        {
            Console.WriteLine("\na = ");
            var a = double.Parse(Console.ReadLine());
            Console.WriteLine("b = ");
            var b = double.Parse(Console.ReadLine());
            Console.WriteLine("c = ");
            var c = double.Parse(Console.ReadLine());
            EquationSolution(a, b, c);
        }
        public static void FileEquation()
        {
            Console.WriteLine("Идёт чтение файла...");
            var path = Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\netcoreapp3.1", "\\Arguments.txt"); // делаем динамический путь, с помощью которого можно открыть программу на любом пк. Arguments.txt - файл с данными
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default)) // экземпляр класса для чтения из файла
                {
                    string line;
                    while ((line = sr.ReadLine()) != null) // построчное чтение аргументов каждой строки файла
                    {
                        int n = 0; // старт массива
                        MatchCollection matches = Regex.Matches(line, @"[+-]?\d+(?:\,\d+)?"); // поиск чисел
                        double[] argsArray = new double[matches.Count];

                        foreach (Match m in matches)
                        {
                            //Console.WriteLine(m.Value);
                            argsArray[n] = double.Parse(m.Value);
                            //Console.WriteLine(argsArray[n]);
                            n++;
                        }

                        var a = argsArray[0];
                        var b = argsArray[1];
                        var c = argsArray[2];

                        EquationSolution(a, b, c);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
