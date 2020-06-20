using System;
using System.IO;

namespace ex._5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines("matrix.txt");
                string[] numbers = { "0" };
                double[,] elements = new double[lines.Length, lines.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    numbers = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int k = 0; k < numbers.Length; k++)
                    {
                        elements[i, k] = double.Parse(numbers[k]);
                    }
                }
                if ((elements.Length % 2) != 0)
                {
                    int center = (numbers.Length - 1) / 2;
                    int top = center - 1, low = center + 1;
                    double max = elements[center, center];
                    for (int j = center + 1; j < numbers.Length; j++)
                    {
                        for (int i = top; i <= low; i++)
                        {
                            if (elements[i, j] > max)
                            {
                                max = elements[i, j];
                            }
                        }
                        top--;
                        low++;
                    }
                    Console.WriteLine(max);
                    Console.ReadKey();
                }
                else
                {
                    int top = numbers.Length / 2 - 1, low = numbers.Length / 2;
                    double max = elements[numbers.Length / 2, low];
                    for (int j = numbers.Length / 2; j < numbers.Length; j++)
                    {
                        for (int i = top; i <= low; i++)
                        {
                            if (elements[i, j] > max)
                            {
                                max = elements[i, j];
                            }
                        }
                        top--;
                        low++;
                    }
                    Console.WriteLine($"Максимальный элемент в заштрихованной части матрицы = {max}");
                    Console.ReadKey();
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("В матрице присутствуют литеры");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Не найден файл matrix.txt");
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("Матрица задана неверно");
            }
        }
    }
}
