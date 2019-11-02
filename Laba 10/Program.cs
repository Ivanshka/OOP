using System;
using System.Collections;
using System.Collections.Generic;

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

            // *больше нет способа добавления в коллекцию -> добавлю то, что удалил)

            for (int i = 1; i < 6; i++)
                sd.Add(tempArray[i], tempArray[i].Reverse());

            Console.WriteLine("\nКопируем данные в List<string>...\n");

            List<string> l = new List<string>();
            for (int i = 0; i < 9; i++)
                l.Add(sd[tempArray[i]]);

            Console.WriteLine("Вывод List<string>:");
            for (int i = 0; i < 9; i++)
                Console.WriteLine(l[i]);

            Console.WriteLine("\nПоиск элемента, содержащего букву 'q'.\nОтвет: " + l.Find(x => x.Contains("q")));//new Predicate<string>(Finder)));

            Console.WriteLine("\nЗАДАНИЕ 3\n");






            Console.ReadLine();
        }

        static bool Finder(string str)
        {
            if (str.Contains("q"))
                return true;
            else return false;
        }
    }
}
