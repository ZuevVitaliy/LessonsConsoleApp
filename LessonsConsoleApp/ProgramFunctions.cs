using Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsConsoleApp
{
    public partial class Program
    {
        public static void StreamsLesson()
        {
            FileStream FStream = new FileStream("D:\\license.txt", FileMode.Open);
            StreamReader reader = new StreamReader(FStream, Encoding.GetEncoding(1251));
            string txt = reader.ReadToEnd();
            reader.Close();
            string[] array = txt.Split('\n');
            Console.WriteLine("Введите подстроку: ");
            var s = Console.ReadLine();
            for (int i = 0; i < array.Length; i++)
            {
                int check = array[i].IndexOf('\r');
                if (check < 0) continue;
                array[i] = array[i].Remove(check);
                Console.WriteLine(CountOfSubstrings(array[i], s));
            }

            Console.ReadKey();
        }

        public static int CountOfSubstrings(string str, string substr)
        {
            int sum = 0;
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(substr))
                return sum;

            while (str.Contains(substr))
            {
                str = str.Substring(str.IndexOf(substr) + substr.Length);
                sum++;
            }

            return sum;
        }

        public static void Trycatch()
        {
            int[] array = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(50);
                Console.WriteLine(array[i]);
            }

            Console.WriteLine();

            string result = "";
            Console.WriteLine("Введите первое число:");
            Console.WriteLine("Введите второе число:");
            try
            {
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                result = (array[a] + array[b]).ToString();
            }
            catch (FormatException)
            {
                result = "Ошибка. Вы ввели не число";
            }
            catch (IndexOutOfRangeException)
            {
                result = "Вы зашли за границу массива";
            }

            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static void BinaryDecimalConverter()
        {
            ConsoleKey key;
            do
            {
                Console.WriteLine(
                    "В какую систему счисления вы хотите перевести число? (1 - двоичная; 2 - десятичная)");
                key = Console.ReadKey().Key;
                Console.WriteLine();
                Console.WriteLine("Введите число:");
                string number = Console.ReadLine();
                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine(ToBinary(number));
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine(ToDecimal(number));
                        break;
                }
            } while (key != ConsoleKey.D1 && key != ConsoleKey.NumPad1 &&
                     key != ConsoleKey.D2 && key != ConsoleKey.NumPad2);

            Console.ReadKey();
        }

        public static string ToDecimal(string number)
        {
            if (number.All(x => x != '0' || x != '1'))
            {
                return "Неверный формат числа";
            }
            int result = 0;
            int j = number.Length - 1;
            for (int i = 0; i < number.Length; i++)
            {
                int num = Convert.ToInt32(number[i].ToString());
                result = (int)(num * Math.Pow(2, j) + result);

                j--;
            }
            return result.ToString();
        }

        public static string ToBinary(string number)
        {
            if (CheckForDigit(number) == false)
            {
                return "Неверный формат числа";
            }
            int num = Convert.ToInt32(number);
            string result = "";

            do
            {
                int rem = num % 2;
                result = rem.ToString() + result;
                num /= 2;
            } while (num != 0);

            return result;
        }

        public static bool CheckForBinaryDigit(string number)
        {
            foreach (char sym in number)
            {
                if (sym != '0' || sym != '1')
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CheckForDigit(string number)
        {
            foreach (char sym in number)
            {
                if (!sym.IsDigit())
                {
                    return false;
                }
            }

            return true;
        }

        public static double Hypotenuse(double leg1, double leg2)
        {
            return Math.Sqrt(Math.Pow(leg1, 2) + Math.Pow(leg2, 2));
        }

        public static void FillRectangleArray_Obsolette(int[,] rectangleArray)
        {
            int a = 0;
            int i = 0;
            int j = 0;
            int jmax = 0;

            int rows = rectangleArray.GetLength(0);
            int columns = rectangleArray.GetLength(1);

            while (i < rows || j < columns)
            {
                if (i >= 0 && i < rows && j >= 0 && j < columns)
                {
                    rectangleArray[i, j] = a;
                    a++;
                }

                if (j < 0)
                {
                    i = -1;
                    j = ++jmax;
                }

                i++;
                j--;
            }
        }

        public static void FillRectangleArray(int[,] rectangleArray)
        {
            int a = 1;
            int i = 0;
            int j = 0;
            int jmax = 0;
            int imin = 0;

            int rows = rectangleArray.GetLength(0);
            int columns = rectangleArray.GetLength(1);

            while (i < rows && j < columns)
            {
                rectangleArray[i, j] = a;
                a++;
                i++;
                j--;

                if (j < 0 || i == rows)
                {
                    i = imin;
                    jmax = ++jmax >= columns ? columns : jmax;
                    j = jmax;
                }

                if (j >= columns)
                {
                    imin++;
                    i++;
                    j--;
                }
            }
        }

        public static void ShowRectangleArray(int[,] rectangleArray)
        {
            for (int i = 0; i < rectangleArray.GetLength(0); i++)
            {
                for (int j = 0; j < rectangleArray.GetLength(1); j++)
                {
                    Console.Write(rectangleArray[i, j]);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }

        public static void Sort(int[] digitals)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = i; j < 10; j++)
                {
                    if (digitals[i] > digitals[j])
                    {
                        int b = digitals[j]; // создали дополнительную переменную
                        digitals[j] = digitals[i]; // меняем местами
                        digitals[i] = b; // значения элементов
                    }
                }
            }

        }

        public static int Fibonacci(int num)
        {
            int result = 1;

            if (num < 1)
            {
                throw new ArgumentException("Ошибка: число не может быть меньше единицы.");
            }

            int a = 0;
            int b = 1;
            for (int i = 2; i <= num; i++)
            {
                result = a + b;
                a = b;
                b = result;
            }

            return result;

        }

        public static void ReplaceName(string[] names, string name, string newName)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == name)
                    names[i] = newName;
            }
        }

        public static void ShowArray(Array someArray)
        {
            foreach (var el in someArray)
            {
                Console.WriteLine(el);
            }
        }

        public static int GetMax(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return max;
        }

        /// <summary>
        /// Функция, которая меняет знак искомого числа на противоположный в заданном массиве.
        /// </summary>
        /// <param name="array">Заданный массив.</param>
        /// <param name="targetNum">Искомое число.</param>
        public static void InvertNum(int[] array, int targetNum)
        {
            //1) Нужно перебрать все элемента массива
            //2) В процессе перебора найти совпадающие числа с введенным числом
            //3) Каждому совпадающему числу нужно поменять знак
            for (int i = 0; i < array.Length; i++)
            {
                if (targetNum == array[i])
                {
                    array[i] *= -1;
                }
            }
        }

        public static int MinNum(int a, int b, int c)
        {
            return a < b ? (a < c ? a : c) : (b < c ? b : c);
        }

        public static int GetMin(params int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }
            return min;
        }
    }
}
