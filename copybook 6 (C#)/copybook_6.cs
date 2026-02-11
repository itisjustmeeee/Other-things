/*using System;
using System.Runtime.CompilerServices;

namespace DelegateSorting
{
    class Program
    {
        delegate int StringComparisonDelegate(string a, string b);
        static void Main()
        {

            string[] words = ["lol", "script", "english", "roblox", "sink", "sticker", "loading"];

            Console.WriteLine("Исходный массив");
            PrintArray(words);

            while (true)
            {
                Console.WriteLine("\nВыберите способ сортировки:");
                Console.WriteLine("1. По длине строки (от короткой к длинной)");
                Console.WriteLine("2. По алфавиту");
                Console.WriteLine("3. По количеству гласных букв");
                Console.WriteLine("0. Выход");

                string? choice = Console.ReadLine();

                StringComparisonDelegate? comparison = null;

                switch (choice)
                {
                    case "1":
                        comparison = CompareByLength;
                        break;
                    case "2":
                        comparison = CompareByAlphabet;
                        break;
                    case "3":
                        comparison = CompareByVowelCount;
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор");
                        continue;
                }

                string[] sorted = (string[])words.Clone();
                BubbleSort(sorted, comparison);

                Console.WriteLine("\nОтсортированный массив");
                PrintArray(sorted);

            }
        }

        static void PrintArray(string[] array)
        {
            foreach(string c in array)
            {
                Console.WriteLine(c + " ");
            }
            Console.WriteLine();
        }

        static void BubbleSort(string[] array, StringComparisonDelegate compare)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (compare(array[j], array[j + 1]) > 0)
                    {
                        string temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        static int CompareByLength(string a, string b)
        {
            return a.Length.CompareTo(b.Length);
        }

        static int CompareByAlphabet(string a, string b)
        {
            return string.Compare(a, b, StringComparison.OrdinalIgnoreCase);
        }

        static int CompareByVowelCount(string a, string b)
        {
            int CountVowels(string s)
            {
                string vowels = "eyuioaEYUIOA";
                int count = 0;
                foreach(char c in s)
                {
                    if (vowels.Contains(c))
                    {
                        count++;
                    }
                }
                return count;
            }
            return CountVowels(a).CompareTo(CountVowels(b));
        }
    }
}*/

/*using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaFiltering
{
    class Program
    {
        delegate bool StringFilterPredicate(string s);

        static void Main()
        {
            string[] words = ["lol", "script", "english", "roblox", "sink", "sticker", "loading"];

            Console.WriteLine("Исходный массив");
            PrintArray(words);

            while (true)
            {
                Console.WriteLine("\nВыберите критерий фильтрации:");
                Console.WriteLine("1. Строки, длина которых больше указанного числа");
                Console.WriteLine("2. Строки, начинающиеся с опрделенной буквы");
                Console.WriteLine("3. Строки, содержашие заданное количество гласных или более");
                Console.WriteLine("0. Выход");

                string? input = Console.ReadLine();
                string? choice = input.Trim();

                StringFilterPredicate? predicate = null;

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nВведите минимальную длину строки: ");
                        string? lenInput = Console.ReadLine();
                        if (!int.TryParse(lenInput, out int minLength))
                        {
                            Console.WriteLine("Ошибка: введите число");
                            continue;
                        }
                        predicate = s => s.Length > minLength;
                        break;
                    case "2":
                        Console.WriteLine("\nВведите букву, с которой будет начинаться строка");
                        string? charInput = Console.ReadLine();
                        if (string.IsNullOrEmpty(charInput))
                        {
                            Console.WriteLine("Ошибка: введите букву");
                            continue;
                        }
                        char startChar = char.ToLower(charInput[0]);
                        predicate = s => s.Length > 0 && char.ToLower(s[0]) == startChar;
                        break;
                    case "3":
                        Console.WriteLine("\nВведите минимальное количество гласных");
                        string? vowelsInput = Console.ReadLine();
                        if (!int.TryParse(vowelsInput, out int minVowels))
                        {
                            Console.WriteLine("Ошибка: введите число");
                            continue;
                        }
                        predicate = s =>
                        {
                            string vowels = "eyuioaEYUIOA";
                            int count = s.Count(c => vowels.Contains(c));
                            return count >= minVowels;
                        };
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор");
                        continue;
                }
                
                var filtered = words.Where(s => predicate(s)).ToList();

                Console.WriteLine("\nОтфильтрованный список");
                if (filtered.Count == 0)
                {
                    Console.WriteLine("Нет строк, удовлетворяющих условию");
                }
                else
                {
                    PrintArray(filtered.ToArray());
                }
            }
        }

        static void PrintArray(string[] array)
        {
            foreach (string c in array)
            {
                Console.WriteLine(c + " ");
            }
            Console.WriteLine();
        }
    }
}*/

using System;
using System.Threading;

namespace ThermostatSimulation
{
    class Thermostat
    {
        public event EventHandler<string>? OverHeat;
        public event EventHandler<string>? OverCool;

        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }

        private double currentTemperature;

        public Thermostat(double minTemp, double maxTemp)
        {
            MinTemperature = minTemp;
            MaxTemperature = maxTemp;
            currentTemperature = (minTemp + maxTemp) / 2;
        }

        public void SimulateTemperatureChange()
        {
            Random rand = new Random();
            double change = rand.NextDouble() * 10 - 5;
            currentTemperature += change;

            Console.WriteLine($"Текущая температура: {currentTemperature:F2}°C");

            CheckTemperature();
        }

        private void CheckTemperature()
        {
            if (currentTemperature > MaxTemperature)
            {
                OverHeat?.Invoke(this, $"Перегрев! Температура превысила {MaxTemperature}°C");
            }
            else if (currentTemperature < MinTemperature)
            {
                OverCool?.Invoke(this, $"Переохлаждение! Температура упала ниже {MinTemperature}°C");
            }
        }
    }

    class Program
    {
        private static bool _running = true;

        static void Main()
        {
            Console.WriteLine("=== Термостат симуляция ===\n");

            Console.WriteLine("\nВведите минимальную температуру");
            double minTemp;
            while (!double.TryParse(Console.ReadLine(), out minTemp))
            {
                Console.WriteLine("Ошибка! Введите число для минимальной температуры:");
            }

            Console.WriteLine("\nВведите максимальную температуру");
            double maxTemp;
            while (!double.TryParse(Console.ReadLine(), out maxTemp))
            {
                Console.WriteLine("Ошибка! Введите число для максимальной температуры:");
            }

            if (minTemp >= maxTemp)
            {
                Console.WriteLine("Ошибка: минимальная температура должна быть меньше максимальной!");
                return;
            }

            var thermostat = new Thermostat(minTemp, maxTemp);

            thermostat.OverHeat += OnOverHeat;
            thermostat.OverCool += OnOverCool;

            Console.WriteLine("\nСимуляция запущена. Температура меняется каждые 2 секунды.");
            Console.WriteLine("Для выхода нажмите любую клавишу (например Q)...\n");

            Thread simulationThread = new Thread(SimulateLoop);
            simulationThread.Start();

            Console.ReadKey(true);
            _running = false;

            Console.WriteLine("\nСимуляция остановлена.");
        }

        private static void SimulateLoop()
        {
            var thermostat = new Thermostat(0, 0);


            while (_running)
            {
                thermostat.SimulateTemperatureChange();
                Thread.Sleep(2000);
            }
        }

        private static void OnOverHeat(object? sender, string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void OnOverCool(object? sender, string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}