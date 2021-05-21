using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stanislav
{
    /// <summary>
    /// Студент
    /// </summary>
    class Student
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Оценка (средний балл)
        /// </summary>
        public float Mark { get; set; }
    }

    class Program
    {
        
        static List<Student> LoadStudentsFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException();


            var students = new List<Student>();
            using (var reader = new FileInfo(fileName).OpenText())
            {
                while (!reader.EndOfStream)
                {
                    var studentParts = reader.ReadLine().Split(' ');
                    students.Add(new Student()
                    {
                        Surname = studentParts[0],
                        FirstName = studentParts[1],
                        Mark = float.Parse(studentParts[2])
                    });
                }
            }
            return students;
        }

        static void Main(string[] args)
        {
            var students = LoadStudentsFromFile(AppDomain.CurrentDomain.BaseDirectory + "StudentList.txt");

            // Словарь SortedDictionary (аналог Dictionary, только данные в словаре упорядоченны по ключу)
            // Ключ - средний балл студента
            // Значение - студенты, соответствующие среднему балу (ключу словаря)
            SortedDictionary<float, List<Student>> statistics = new SortedDictionary<float, List<Student>>();

            foreach (var student in students)
            {
                // Словарь содержит ключ? (средний балл студента?)
                if (statistics.ContainsKey(student.Mark))
                {
                    // Да

                    // Добавляем в статистику значений нового студента

                    // Обращение к словарю по ключу (средний балл)
                    statistics[student.Mark].Add(student);
                }
                else
                {
                    // Нет

                    // Добавим НОВУЮ запись в словарь, проинициализируем коллекцию значений
                    statistics.Add(student.Mark, new List<Student>() { student });
                }
            }

            // Мы заполнили словарь, теперь наши студенты разбиты по ключу (по среднему балу)

            // Как я писал ранее, SortedDictionary представляет коллекцию пар «ключ-значение», упорядоченных по ключу
            // Следовательно, средние баллы студентов идут в порядке возрастания


            // Выведу всех студентов в разрезе ТОП 3 худших средних баллов
            int counter = 0;
            // Пройдемся в цикле foreach по словарю statistics
            foreach (var studentKeyValue/*Каждое значение словаря - это пара «ключ-значение»*/ in statistics)
            {
                // Выведу на экран ключ (средний балл)
                Console.WriteLine($"Средний балл: {studentKeyValue.Key}\nСтуденты:");

                // Значение словаря - коллекция студентов, объединенных между собой одинаковым средним баллом,
                // выведу эту коллекцию на экран
                foreach (var student in studentKeyValue.Value)
                    Console.WriteLine($"\t{student.Surname} {student.FirstName}");
                counter++;
                if (counter >= 3)
                    break;
            }


            // Результат: 
            /*

            Средний балл: 1,5
            Студенты:
                            Афанасьева Екатерина
            Средний балл: 2
            Студенты:
                            Шестаков Клим
            Средний балл: 2,1
            Студенты:
                            Шубин Владлен
                            Лыткин Панкратий

             */

            Console.ReadKey();
        }
    }
}
