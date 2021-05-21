using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ6
{
    /// <summary>
    /// Все студенты
    /// </summary>
    class Students
    {
        private List<Student> list;
        /// <summary>
        /// Конструктор списка студентов по файлу
        /// </summary>
        /// <param name="fileName"></param>
        public Students(string fileName)
        {
            list = new List<Student>();
            StreamReader reader = new StreamReader(fileName);
            while (!reader.EndOfStream)
            {
                string s = reader.ReadLine();
                string[] ss = s.Split(';');
                list.Add(new Student(ss[0], ss[1], ss[2], ss[3],
                    ss[4], int.Parse(ss[5]), int.Parse(ss[6]), int.Parse(ss[7]), ss[8]));// чувствителен к принимаемым данным
            }
        }

        //доступ на чтeние через индексатор
        public string this[int i] => list[i].ToString();
        public int Count => list.Count;
        /// <summary>
        /// Количество бакалавров и магистров
        /// </summary>
        public (int Bak, int Mag) DetailCount
        {
            get
            {
                int bak = 0;
                int mag = 0;
                foreach (Student el in list)
                {
                    if (el.Course < 5)
                        bak++;
                    else
                        mag++;
                }
                return (bak, mag);
            }
        }
        /// <summary>
        /// Количество студентов на пятых шестых курсах
        /// </summary>
        public (int Five, int Six) FiveSixCount
        {
            get
            {
                int five = 0;
                int six = 0;
                foreach (Student el in list)
                {
                    if (el.Course == 5)
                        five++;
                    else if (el.Course == 6)
                        six++;
                }
                return (five, six);
            }
        }
        /// <summary>
        /// Количество студентов на каком курсе учатся
        /// </summary>
        /// <param name="ageDown">возраст от</param>
        /// <param name="ageUp">возраст до</param>
        /// <returns>словарь</returns>
        public Dictionary<int, int> GetCourseForAges(int ageDown, int ageUp)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (Student el in list)
            {
                if (el.Age >= ageDown && el.Age <= ageUp)
                {
                    if (dict.ContainsKey(el.Course))
                        dict[el.Course]++;
                    else
                        dict.Add(el.Course, 1);
                }
            }
            return dict;
        }
        /// <summary>
        /// Сортировка по возрасту
        /// </summary>
        public void SortAge() => list.Sort(((st, st1) => st.Age - st1.Age));

        public void SortDual()
        {
            list.Sort(((st, st1) =>
            {
                if (st.Course == st1.Course)
                    return st.Age - st1.Age;
                else
                    return st.Course - st1.Course;
            }));
        }
        /// <summary>
        /// Один студент
        /// </summary>
        private class Student
        {
            public string FirstName;
            public string LastName;            
            public string University;
            public string Facilty;
            public string Department;
            public int Age;
            public int Course;            
            public int Group;
            public string City;
            public Student(string firstName, string lastName, string university,
                string facilty, string department, int age, int course, int group, string city)
            {
                LastName = lastName;
                FirstName = firstName;
                University = university;
                Facilty = facilty;
                Course = course;
                Department = department;
                Group = group;
                City = city;
                Age = age;
            }
            public override string ToString()
            {
                return $"{FirstName,-10} {LastName,-14} {Age,5} лет курс: {Course,-5} город: {City,-12} ун-т: {University,8}";
            }
        }
        /// <summary>
        /// Создание файла с исходными данными
        /// </summary>
        /// <param name="fileName">имя файла</param>
        public static void GenNSaveStudentsToFile(string fileName)
        {
            List<Student> list = new List<Student>
            {
                new Student("Петров", "Дмитрий", "МГУ", "Мехмат", "Механический", 1, 1, 3, "Москва"),
                new Student("Петров", "Дмитрий", "МГУ", "Мехмат", "Механический", 1, 1, 3, "Москва"),
                new Student("Петров", "Дмитрий", "МГУ", "Мехмат", "Механический", 1, 1, 3, "Москва"),
                new Student("Петров", "Дмитрий", "МГУ", "Мехмат", "Механический", 1, 1, 3, "Москва"),
                new Student("Петров", "Дмитрий", "МГУ", "Мехмат", "Механический", 1, 1, 3, "Москва"),
                new Student("Петров", "Дмитрий", "МГУ", "Мехмат", "Механический", 1, 1, 3, "Москва"),
                new Student("Петров", "Дмитрий", "МГУ", "Мехмат", "Механический", 1, 1, 3, "Москва"),
                new Student("Петров", "Дмитрий", "МГУ", "Мехмат", "Механический", 1, 1, 3, "Москва"),
                //new Student("Теплов", "Андрей", "СПГУ", "Мехмат", 1, "Механический", 2, "Петербург", 23),
                //new Student("Гавасяв", "Емеля", "МГУ", "Инженерный", 3, "Математический", 1, "Москва", 22),
                //new Student("Юров", "Вася", "МГУ", "Логический", 3, "Математический", 2, "Владивосток", 21),
                //new Student("Берендеев", "Сергей", "СПУ", "Логический", 4, "Математический", 1, "Петербург", 18),
                //new Student("Жуликов", "Алексей", "МГУ", "Мехмат", 4, "Механический", 3, "Петербург", 25),
                //new Student("Иванов", "Андрей", "МГУ", "Инженерный", 5, "Механический", 1, "Москва", 24),
                //new Student("Логинов", "Михаил", "МГУ", "Инженерный", 5, "Механический", 4, "Москва", 19),
                //new Student("Пужев", "Степан", "МГУ", "Мехмат", 6, "Биологический", 5, "Владивосток", 21),
                //new Student("Жуков", "Иван", "МГУ", "Мехмат", 6, "Гуманитарный", 4, "Владивосток", 22),
                //new Student("Лужков", "Дмитрий", "МГУ", "Мехмат", 2, "Математический", 1, "Москва", 19),
                //new Student("Варьянов", "Андрей", "СПГУ", "Мехмат", 2, "Механический", 2, "Петербург", 23),
                //new Student("Восресеньев", "Федя", "ПГУ", "Мехмат", 1, "Механический", 3, "Пенза", 23),
            };
            StreamWriter writer = new StreamWriter(fileName);
            foreach (Student el in list)
            {
                string s = string.Join(";", el.FirstName, el.LastName, el.University, el.Facilty, el.Department,
                    el.Age, el.Group, el.Course, el.City); 
                writer.WriteLine(s);
            }
        }

    }
}