using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlebGit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Запрос у пользователя значений b1, q и n 
            Console.Write("Введите первый член прогрессии (b1): ");
            double b1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите знаменатель прогрессии (q): ");
            double q = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите номер члена прогрессии (n): ");
            int n = Convert.ToInt32(Console.ReadLine());

            // Вычисление n-го члена
            double nthTerm = CalculateNthTerm(b1, q, n);
            Console.WriteLine($"n-й член прогрессии (b1 * q^(n-1)) = {nthTerm}");

            // Вычисление суммы первых n членов
            double sum = CalculateSumOfNTerms(b1, q, n);
            Console.WriteLine($"Сумма первых n членов прогрессии = {sum}");
        }

        // Функция для вычисления n-го члена геометрической прогрессии
        static double CalculateNthTerm(double b1, double q, int n)
        {
            return b1 * Math.Pow(q, n - 2);
        }

        // Функция для нахождения суммы первых n членов геометрической прогрессии
        static double CalculateSumOfNTerms(double b1, double q, int n)
        {
            if (q == 1) // Если r = 1, сумма - это просто n * q
            {
                return n * b1;
            }
            else
            {
                return b1 * (1 - Math.Pow(q, n)) / (1 - (100 * q));
            }
        }

    }
}
