using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2MinFunc
{
    /// <summary>
    /// Нахождение минимального значения у функции
    /// </summary>
    static class MinOfFunc
    {
        public delegate double MyFunc(double x);

        /// <summary>
        /// Запись значений функции в файл
        /// </summary>
        /// <param name="func">функция</param>
        /// <param name="fileName">файл</param>
        /// <param name="go">начало</param>
        /// <param name="end">конец</param>
        /// <param name="step">шаг</param>
        public static void SaveFunc(MyFunc func, string fileName, double go, double end, double step)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fs);
            double run = go;
            while (run <= end)
            {
                writer.Write(func.Invoke(run));
                run += step;
            }writer.Close();
        }
        /// <summary>
        /// Чтение значений из файла и определение минимального значения
        /// </summary>
        /// <param name="fileName">файл</param>
        /// <returns>минимальное значение</returns>
        public static double LoadAndMin(string fileName)
        {
            double min = default;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fs);
            min = Double.MaxValue;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                double d = reader.ReadDouble();
                if (d < min)
                {
                    min = d;
                }
            }
            reader.Close();
            return min;
        }
        /// <summary>
        /// Чтение значений из файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>значения</returns>
        public static List<double> LoadToListAndMin(string fileName, out double min)
        {
            List<double> list = new List<double>();
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fs);
            min = Double.MaxValue;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                double d = reader.ReadDouble();
                list.Add(d);
                if (d < min)
                {
                    min = d;
                }
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Получение функции по номеру
        /// </summary>
        /// <param name="swtch">выбор</param>
        /// <returns>функция</returns>
        public static MinOfFunc.MyFunc GetMyFunc(int swtch)
        {
            switch (swtch)
            {
                case 1: return d => d * d;
                case 2: return d => d * d * d;
                case 3: return d => Math.Sin(d);
                case 4: return d => d * d - 50 * d + 50;
                default: throw new Exception("Out of range");
            }
        }
    }
}