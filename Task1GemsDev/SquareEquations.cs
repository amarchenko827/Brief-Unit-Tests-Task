using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Task1GemsDev
{
    public class SquareEquations
    {
        public static void Menu() // главное меню
        {
            Console.WriteLine("\nВыберите действие:\n1 - Ввод с клавиатуры\n2 - Чтение из файла\n");
            var ch = int.Parse(Console.ReadLine()); // какую кнопку нажал пользователь
            MenuInput(ch);
        }

        public static void MenuInput(int key) // действия в меню
        {
            var ch = key;
            switch (ch)
            {
                case 1: // выбор решения с помощью ввода. аргументы - параметры
                    Console.WriteLine("\na = ");
                    var a = double.Parse(Console.ReadLine());
                    Console.WriteLine("b = ");
                    var b = double.Parse(Console.ReadLine());
                    Console.WriteLine("c = ");
                    var c = double.Parse(Console.ReadLine());
                    EquationKeyboard(a, b, c);
                    break;
                case 2: // выбор решения с помощью чтения данных из файла
                    EquationFile();
                    break;
                default: // возврат к выборам при неправильном действии
                    Console.WriteLine("\nТакого действия нет, попробуйте снова");
                    Menu();
                    break;
            }
        }

        public static void MenuOrClose() // выбор вернуться в меню или закрыть программу после решения уравнения
        {
            Console.WriteLine("\nВыберите действие:\n1 - Вернуться в меню\n2 - Выйти из программы\n");
            var ch = int.Parse(Console.ReadLine());
            MenuOrCloseInput(ch);
        }

        public static void MenuOrCloseInput(int key) // действия после решения уравнения
        {
            var ch = key;
            switch (ch)
            {
                case 1: // возврат в меню
                    Menu();
                    break;
                case 2: // закрыть программу
                    Environment.Exit(0);
                    break;
                default: // возврат к выборам при неправильном действии
                    Console.WriteLine("\nТакого действия нет, попробуйте снова");
                    MenuOrClose();
                    break;
            }
        }

        public static void EquationKeyboard(double arg1, double arg2, double arg3) // решение с помощью ввода
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

            //MenuOrClose();
        }

        public static void EquationFile() // решение с помощью чтения данных из файла
        {
            Console.WriteLine("Идёт чтение файла...\n");
            var path = Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\netcoreapp3.1", "\\Arguments.txt"); // делаем динамический путь, с помощью которого можно открыть программу на любом пк. Arguments.txt - файл с данными
            Console.WriteLine(path);
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default)) // экземпляр класса для чтения из файла
                {
                    string line;
                    while ((line = sr.ReadLine()) != null) // построчное чтение. насколько я понял задания. программа должна считывать аргументы из каждой строки в файле и решать уравнения на их основе. сколько строк - столько и будет решено уравнений
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

                        // такое же решение уравнений (можно сделать это вообще отдельной функцией, чтобы код не повторялся, это очень легко, но не успел)
                        var a = argsArray[0];
                        var b = argsArray[1];
                        var c = argsArray[2];

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
                //MenuOrClose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //MenuOrClose();
            }
        }
    }
}
