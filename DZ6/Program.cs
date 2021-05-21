
/*
Домашнее задание 
2.	Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата. 
а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум. Использовать массив (или список) делегатов, в котором хранятся различные функции.
б) *Переделать функцию Load, чтобы она возвращала массив считанных значений. Пусть она возвращает минимум через параметр (с использованием модификатора out). 

3.	Переделать программу Пример использования коллекций для решения следующих задач:
а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
в) отсортировать список по возрасту студента;
г) *отсортировать список по курсу и возрасту студента;

4.	**Считайте файл различными способами. Смотрите “Пример записи файла различными способами”. Создайте методы, которые возвращают массив byte (FileStream, BufferedStream), 
строку для StreamReader и массив int для BinaryReader.

 */




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ6
{

    class Program
    {

        #region menu
        ///////////////////////////cсоздадим метод проверки ввода
        static int Checktoparse(string message)
        {
            string num_before;
            bool flag_ornum;
            int num_after;
            do
            {
                num_before = Console.ReadLine();

                flag_ornum = int.TryParse(num_before, out num_after);
            } while (!flag_ornum);
            return num_after;

        }
        static void Main(string[] args)
        {
            int value;
            do
            {
                Console.Title = ("Меню");
                Console.Clear();
                HelpCS.MyHeader(text: "Главное меню.");
                Console.WriteLine("Введите номер задачи от 1 до 4. принимаются только целые числа.");
                value = Checktoparse(""); // даем значение велью методом GetValue // и там метод уже либо пропустит int32 либо будет бесконечно вызыватся, пока ты не напишиш цифры удовлетворяющие условия
                // гет валью дает нам проверку на вводимы знаки, а диапазон мы сдесь даже не ставили У НАС ВСЕГО 3 КЕЙСА

                HelpCS.MyFooter();
                switch (value)
                {
                    case 1:
                        dz1();
                        break;
                    case 2:
                        dz2();
                        break;
                    case 3:
                        dz3();
                        break;
                    case 4:
                            dz4();
                            break;

                }
            } while (true);
            #endregion
        }

        #region задание 1
        /// <summary>
        /// 1.	Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). 
        /// Продемонстрировать работу на функции с функцией a* x^2 и функцией a* sin(x).
        /// </summary>

        static void dz1()
        {
            ///////////////// все понятно кроме всего  /////////////////////////////////////////////////////////
            Console.Clear();
            HelpCS.MyHeader(text: "1. Изменить программу вывода таблицы:");
            ///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Таблица функции возведения в куб числа (y = x * x * x):");
            Helpdz1.TableToConsole(Helpdz1.MyFunc1, 0, -5, 5);
            HelpCS.MyPause();
            Console.WriteLine("Таблица функции возведения в квадрат числа с прибавкой (y = a * x ^ 2):");
            Helpdz1.TableToConsole(Helpdz1.MyFunc2, 3, -5, 5);
            HelpCS.MyPause();
            Console.WriteLine("Таблица функции синуса с прибавкой (y = a * sin(x)):");
            Helpdz1.TableToConsole(Helpdz1.MyFunc3, 3, -5, 5);
            ///////////////////////////////////////////////////////////////////////////////////
            HelpCS.MyFooter();

            /*
            int x_1 = 0;
            int y_1 = 0;
            int h = 0;
            // Создаем новый делегат и передаем ссылку на него в метод Table
            Console.WriteLine("Таблица функции MyFunc:");
            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            Helpdz1_1.Table(new Fun(Helpdz1_1.MyFunc),x_1,y_1); // (Helpdz1_1.MyFunc), -2, 2); указываем путь к классу в нашем неймспейс
            Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
            // Упрощение(c C# 2.0).Делегат создается автоматически.            
            Helpdz1_1.Table(Helpdz1_1.MyFunc, -2, 2);
            Console.WriteLine("Таблица функции Sin:");
            Helpdz1_1.Table(Math.Sin, -2, 2);      // Можно передавать уже созданные методы
            Console.WriteLine("Таблица функции x^2:");
            // Упрощение(с C# 2.0). Использование анонимного метода
            Helpdz1_1.Table(delegate (double x) { return x * x; }, 0, 3);

            Helpdz1_1.Table(new Fun2(Helpdz1_1.MyFunc), 1, 2, 3);
            Helpdz1_1.Table(delegate (double x) { return x * x; }, 0, 3);
            Console.ReadKey();*/
        }


        #endregion
        #region задание 2

        /// <summary>
        /// Задача 2
        /// Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию
        /// в виде делегата. 
        /// а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и
        /// на каком отрезке находить минимум. Использовать массив (или список) делегатов, в котором
        /// хранятся различные функции.
        /// б) *Переделать функцию Load, чтобы она возвращала массив считанных значений. Пусть она
        /// возвращает минимум через параметр (с использованием модификатора out). 
        /// </summary>
        static void dz2()
        {
            Console.Clear();
            HelpCS.MyHeader(text: "2. Модифицировать программу нахождения минимума функции ");
            ///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Пункт задания А. Меню с различными функциями.");
            while (Helpdz6_2.GetSwitchFromConsole(out int swtch)) //выбор функции в консоли
            {
                MinOfFunc.MyFunc func = MinOfFunc.GetMyFunc(swtch);
                MinOfFunc.SaveFunc(func, @"..\..\data.bin", 0, 10, 1);
                double min = MinOfFunc.LoadAndMin(@"..\..\data.bin");
                Console.WriteLine($"Минимум функции равен = {min:F2}\n\n__________________________________________________________________________");
            }
            HelpCS.MyPause();
            ///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Пункт задания Б. Массив считанных значений.");
            Console.WriteLine("Записанные в последний раз числа в файл:");
            List<double> list = MinOfFunc.LoadToListAndMin(@"..\..\data.bin", out double min2);
            list.ForEach(Console.WriteLine);
            Console.WriteLine($"Минимум функции равен = {min2:F2}\n\n__________________________________________________________________________");
            ///////////////////////////////////////////////////////////////////////////////////
            HelpCS.MyFooter();
            //HelpCS.MyHeader(text: "2. Модифицировать программу нахождения минимума функции ");
            /////////////////////////////////////////////////////////////////////////////////////
            //Console.WriteLine("Пункт задания А. Меню с различными функциями.");
            //while (Helpdz6_2.GetSwitchFromConsole(out int swtch)) //выбор функции в консоли
            //{
            //    MinOfFunc.MyFunc func = MinOfFunc.GetMyFunc(swtch);
            //    MinOfFunc.SaveFunc(func, @"..\..\data.bin", 0, 10, 1);
            //    double min = MinOfFunc.LoadAndMin(@"..\..\data.txt");
            //    Console.WriteLine($"Минимум функции равен = {min:F2}\n\n__________________________________________________________________________");
            //}
            //HelpCS.MyPause();
            /////////////////////////////////////////////////////////////////////////////////////
            //Console.WriteLine("Пункт задания Б. Массив считанных значений.");
            //Console.WriteLine("Записанные в последний раз числа в файл:");
            //List<double> list = MinOfFunc.LoadToListAndMin(@"..\..\data.txt", out double min2);
            //list.ForEach(Console.WriteLine);
            //Console.WriteLine($"Минимум функции равен = {min2:F2}\n\n__________________________________________________________________________");
            /////////////////////////////////////////////////////////////////////////////////////
            //HelpCS.MyFooter();
        }

        #endregion
        #region задание 3
        /// <summary>
        /// Задача 3
        /// Переделать программу Пример использования коллекций для решения следующих задач:
        /// а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
        /// б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
        /// в) отсортировать список по возрасту студента;
        /// г) *отсортировать список по курсу и возрасту студента;  
        /// </summary>
        static void dz3()
        {
            Console.Clear();
            HelpCS.MyHeader(text: "Задача 3. Использование коллекций.");
            ///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Пункт задания А. Подсчитать количество студентов учащихся на 5 и 6 курсах.");
            Students students = default;
            try
            {
                students = new Students(@"..\..\students.csv");
            }
            catch (Exception e)
            {
                Console.WriteLine("Не удалось открыть файл исходных данных! Работа программы невозможна!\n" + e.Message);
                Console.ReadKey();
                return;
            }
            Console.WriteLine($"Всего студентов: {students.Count}");
            var (bak, mag) = students.DetailCount;
            Console.WriteLine($"Магистров: {mag}");
            Console.WriteLine($"Бакалавров: {bak}");
            var (five, six) = students.FiveSixCount;
            Console.WriteLine($"Из них студентов пятых {five} и шестых {six} курсов");
            Console.WriteLine("Список студентов:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i]);
            }
            HelpCS.MyPause();
            ///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Пункт задания Б. Подсчитать количество студентов в возрасте от 18 до 20 лет на каком курсе учатся.");
            Console.WriteLine("Количество студентов по курсам в возрасте от 18 до 20 лет:");
            Dictionary<int, int> dict = students.GetCourseForAges(18, 20);
            foreach (var el in dict)
            {
                Console.WriteLine($"{el.Key} курс = {el.Value} студентов");
            }
            HelpCS.MyPause();
            ///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Пункт задания В. Откортировать студентов по возрасту студентов.");
            Console.WriteLine("Отсортированный список студентов:");
            students.SortAge();
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i]);
            }
            HelpCS.MyPause();
            ///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Пункт задания Г. *отсортировать список по курсу и возрасту студента.");
            Console.WriteLine("Отсортированный по 2-м параметрам список студентов:");
            students.SortDual();
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i]);
            }
            //Students.GenNSaveStudentsToFile(@"..\..\students.csv");
            ///////////////////////////////////////////////////////////////////////////////////
            HelpCS.MyFooter();
        }
        #endregion
        #region Задание 4
        /// <summary>
            /// Считайте файл различными способами. Смотрите “Пример записи файла различными способами”. 
                            /// Создайте методы, которые возвращают массив byte (FileStream, BufferedStream),  строку для StreamReader и массив int для BinaryReader.
            /// </summary>
        static void dz4()
        {
            Console.Clear();
            HelpCS.MyHeader(text: "4. Чтение файла различными способами.");
            ///////////////////////////////////////////////////////////////////////////////////
            long size = 1024;
            ReadWrite.WriteFileStream(@"..\..\TextFile1.txt", size);
            ReadWrite.WriteBinary(@"..\..\TextFile2.txt", size);
            ReadWrite.WriteStreamWriter(@"..\..\TextFile3.txt", size);
            ReadWrite.WriteBufferedStream(@"..\..\TextFile4.txt", size);
            HelpCS.MyPause("Данные в файлы записаны. Для продолжения нажмите кнопку ...");
            /////////////////////////////////////////
            Console.WriteLine("Прочитанные данные из файла FileStream:");
            byte[] arr = ReadWrite.ReadFileStream(@"..\..\TextFile1.txt");
            foreach (var el in arr)
            {
                Console.Write($"{el} ");
            }
            Console.WriteLine();
            HelpCS.MyPause();
            /////////////////////////////////////////
            Console.WriteLine("Прочитанные данные из файла BinaryReader:");
            int[] arrInt = ReadWrite.ReadBinary(@"..\..\TextFile2.txt");
            foreach (var el in arrInt)
            {
                Console.Write($"{el} ");
            }
            Console.WriteLine();
            HelpCS.MyPause();
            /////////////////////////////////////////
            Console.WriteLine("Прочитанные данные из файла StreamReader:");
            string str = ReadWrite.ReadStreamReader(@"..\..\TextFile3.txt");
            Console.WriteLine(str);
            HelpCS.MyPause();
            /////////////////////////////////////////
            Console.WriteLine("Прочитанные данные из файла BufferedStream:");
            byte[] arr2 = ReadWrite.ReadFileStream(@"..\..\TextFile4.txt");
            foreach (var el in arr2)
            {
                Console.Write($"{el} ");
            }
            Console.WriteLine();
            HelpCS.MyPause();
            ///////////////////////////////////////////////////////////////////////////////////
            HelpCS.MyFooter();
        }
        #endregion
        // Сианислав, я вот собираю гербарий и я понимаю зависимости переменных и связи какие мы им задаем. Но в любом случае это ужастно сложго. Я уверен что ближе к концу обучения мы вернемся к теме репетиторства
        // я наработал себе кучу шпаргалок, но по прежнему я чувствую себя на уровне hello world
    }
}