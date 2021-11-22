using System;

namespace Task1GemsDev
{
    public class UserInterface : DataGet
    {
        public static void Menu()
        {
            Console.WriteLine("\nВыберите действие:\n1 - Ввод с клавиатуры\n2 - Чтение из файла\n");
            var key = Console.ReadLine(); // какую кнопку нажал пользователь
            switch (key)
            {
                case "1": // выбор решения с помощью ввода. аргументы - параметры
                    KeyboardEquation();
                    AfterMenu();
                    break;
                case "2": // выбор решения с помощью чтения данных из файла
                    FileEquation();
                    AfterMenu();
                    break;
                default: // возврат к выборам при неправильном действии
                    Console.WriteLine("\nТакого действия нет, попробуйте снова");
                    Menu();
                    break;
            }
        }
        public static void AfterMenu()
        {
            Console.WriteLine("\nВыберите действие:\n1 - Вернуться в меню\n2 - Выйти из программы\n");
            var key = Console.ReadLine();
            switch (key)
            {
                case "1": // возврат в меню
                    Menu();
                    break;
                case "2": // закрыть программу
                    Environment.Exit(0);
                    break;
                default: // возврат к выборам при неправильном действии
                    Console.WriteLine("\nТакого действия нет, попробуйте снова");
                    AfterMenu();
                    break;
            }
        }
    }
}
