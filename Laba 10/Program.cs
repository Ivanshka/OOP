using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Laba_10
{
    static class Ex
    {
        public static int SearchValue(this ArrayList arrayList, object value)
        {
            for (int i = 0; i < arrayList.Count; i++)
                if (arrayList[i] == value)
                    return i;
            return -1;
        }

        public static string Reverse(this string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ЗАДАНИЕ 1\n");
            ArrayList al = new ArrayList();
            Random r = new Random(145);
            al.Add(r.Next());
            al.Add(r.Next());
            al.Add(r.Next());
            al.Add(r.Next());
            al.Add(r.Next());
            al.Add("ausdnlaksd");
            Student s1 = new Student("Нэйм", 1);
            Student s2 = new Student("Ноунэйм", 2);
            al.Add(s1);
            al.Add(s2);
            al.Remove(s2);

            Console.WriteLine("Элементы коллекции:");
            foreach (object a in al)
                Console.WriteLine(a);

            Console.WriteLine("Элемент найден по индексу: " + al.SearchValue(s1));

            Console.WriteLine("\nЗАДАНИЕ 2\n");
            
            string[] tempArray = new []{ "qwe", "asd", "zxc", "rty", "fgh", "vbn", "uio", "jkl", "m,." };

            SortedDictionary<string, string> sd = new SortedDictionary<string, string>();
            for (int i = 0; i < 9; i++)
                sd.Add(tempArray[i], tempArray[i].Reverse());


            Console.WriteLine("Вывод на консоль содержимого коллекции:");
            for(int i = 0; i < 9; i++)
                Console.WriteLine(sd[tempArray[i]]);

            // удаляю несколько последовательных элементов
            for(int i = 1; i < 6; i++)
                sd.Remove(tempArray[i]);

            for (int i = 1; i < 6; i++)
                sd.Add(tempArray[i], tempArray[i].Reverse());

            Console.WriteLine("\nКопируем данные в List<string>...\n");

            // создаем 2-ю коллекцию и заполняем ее
            List<string> l = new List<string>();
            for (int i = 0; i < 9; i++)
                l.Add(sd[tempArray[i]]);

            Console.WriteLine("Вывод List<string>:");
            for (int i = 0; i < 9; i++)
                Console.WriteLine(l[i]);

            Console.WriteLine("\nПоиск элемента, содержащего букву 'q'.\nОтвет: " + l.Find(x => x.Contains("q")));//new Predicate<string>(Finder)));

            Console.WriteLine("\nЗАДАНИЕ 3\n");

            SortedDictionary<Question, Question> sdq = new SortedDictionary<Question, Question>();
            string[] questions = { "Что такое парсек?", "Где находится Черная дыра?", "Газовые гиганты Солнечной системы?", "Созвездие в виде буквы W?", "Звезда, переливающаяся зеленым, желтым и синим цветами?", "Saint Asonia" };
            string[] answers = { "Единица измерения расстояния, равная расстоянию до объекта. :D ", "В центре галактики", "Юпитер, Сатурн, Уран, Нептун", "Кассиопея", "Капелла", "This August Day" };
            for (int i = 0; i < 3; i++)
                sdq.Add(new Question(questions[i], answers[i]), new Question(questions[i+1], answers[i+1]));

            // вывод на консоль
            Console.WriteLine("Вывод на консоль содержимого коллекции:");
            for (int i = 0; i < 3; i++)
                Console.WriteLine(sd[tempArray[i]]);
            
            // удаляю несколько последовательных элементов
            for (int i = 1; i < 2; i++)
                Console.WriteLine("Удалено: " + sdq.Remove(new Question(questions[i], answers[i])).ToString());

            // снова добавляю
            for (int i = 1; i < 2; i++)
                sdq.Add(new Question(questions[i], answers[i]), new Question(questions[i+1], answers[i+1]));
            
            
            // создаем 2-ю коллекцию и заполняем ее
            List<Question> lq = new List<Question>();
            for (int i = 0; i < 3; i++)
            {
                lq.Add(sdq[new Question(questions[i], answers[i])]);
            }

            Console.WriteLine("\nПоиск элемента, содержащего слово \"Saint\". Результат: " + lq.Find(x => x.Text.Contains("q")));//new Predicate<Question>(Checker)));
            
            Console.WriteLine("Вывод списка:");
            foreach (Question t in lq)
                Console.WriteLine(t);

            Console.WriteLine("\nЗАДАНИЕ 4\n");

            // коллекция и привязка события
            ObservableCollection<Question> oc = new ObservableCollection<Question>(lq);
            oc.CollectionChanged += (o, e) => Console.WriteLine("Collection has been changed!");
            // изменяем для демонстрации
            // удаляю несколько последовательных элементов
            for (int i = 0; i < 2; i++)
                Console.WriteLine("Удалено: " + oc.Remove(new Question(questions[i], answers[i])).ToString());

            // снова добавляю
            for (int i = 0; i < 2; i++)
                oc.Add(new Question(questions[i], answers[i]));

            Console.ReadLine();
        }

        static bool Checker(Question q)
        {
            if (q.Text.Contains("q"))
                return true;
            else return false;
        }
    }
}
