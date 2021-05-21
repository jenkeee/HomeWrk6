using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ6
{
    class Helpdz1
    {
        /// <summary>
        /// Вывод значения функции в консоль
        /// </summary>
        /// <param name="fun">Функция</param>
        /// <param name="a">Добавка</param>
        /// <param name="x">Аргумент начальный</param>
        /// <param name="end">Предел аргумента</param>
        internal static void TableToConsole(Fun fun, double a, double x, double end)
        {
            Console.WriteLine("-------- A -------- X -------- Y -");
            while (x <= end)
            {
                Console.WriteLine($"| {a,8:F3} | {x,8:F3} | {fun(a, x),8:F3} |");
                x++;
            }
            Console.WriteLine("----------------------------------");
        }
        /// <summary>
        /// Описание типа делеагата
        /// </summary>
        /// <param name="a">добавка</param>
        /// <param name="x">аргумент</param>
        /// <returns>значение функции</returns>
        internal delegate double Fun(double a, double x);
        /// <summary>
        /// Куб функция
        /// </summary>
        /// <param name="a">добавка</param>
        /// <param name="x">аргумент</param>
        /// <returns>значение функции</returns>
        internal static double MyFunc1(double a, double x) => x * x * x;
        /// <summary>
        /// Возведение в квадрат
        /// </summary>
        /// <param name="a">добавка</param>
        /// <param name="x">аргумент</param>
        /// <returns>значение функции</returns>
        internal static double MyFunc2(double a, double x) => a * Math.Pow(x, 2);
        /// <summary>
        /// Синус функции
        /// </summary>
        /// <param name="a">добавка</param>
        /// <param name="x">аргумент</param>
        /// <returns>значение функции</returns>
        internal static double MyFunc3(double a, double x) => a * Math.Sin(x);
    }

    public delegate double Fun(double x); // делегат надо создать до всех манипуляций над ним
    public delegate double Fun2(double x, double y);
    class Helpdz1_1
    {
        // Создаем метод, который принимает делегат
        // На практике этот метод сможет принимать любой метод
        // с такой же сигнатурой, как у делегата
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double x)
        {
            HelpCS.GetNumberFromConsole(out double a);
            double y = a * Math.Pow(x, 2);
            return y;
        }
        public static double MyFunc(double x, double y)
        {
            HelpCS.GetNumberFromConsole(out double a);
            double o = a * Math.Pow(x, 2);
            return o;
        }
        public static void Table(Fun2 F, double x, double y, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, y);
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
    }
}

