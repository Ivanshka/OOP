using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_4
{
    class Set
    {
        // СВОЙСТВА
        /// <summary>
        /// Хранит элементы множества.
        /// </summary>
        public List<int> Elements { get; set; }
        /// <summary>
        /// Хранит владельца множества.
        /// </summary>
        public Owner Owner{ get; set; }

        // ИНДЕКСАТОРЫ
        public int this[int i]
        {
            get { return Elements[i]; }
            set { Elements[i] = value; }
        }

        // ОПЕРАТОРЫ: методы, перегружающие операторы, не должны менять значения своих параметров. Это допустимо, но неправильно.
        public static Set operator ++(Set s)
        {
            Random r = new Random();
            List<int> l = new List<int>(s.Elements);
            l.Add(r.Next());
            return new Set(l, s.Owner);
        }

        public static Set operator +(Set s1, Set s2)
        {
            List<int> l = new List<int>(s1.Elements);
            for (int i = 0; i < s2.Elements.Count; i++)
                l.Add(s2.Elements[i]);
            return new Set(l, s1.Owner);
        }

        public static bool operator >=(Set s1, Set s2)
        {
            if (s1.Elements.Count >= s2.Elements.Count)
                return true;
            else
                return false;
        }

        public static bool operator <=(Set s1, Set s2)
        {
            if (s1.Elements.Count <= s2.Elements.Count)
                return true;
            else
                return false;
        }

                    //explicit - если преобразование должно быть явное
        public static implicit operator int(Set s) { return s.Elements.Count; }
        public static int operator %(Set s, int pos) { return s.Elements[pos]; }


        // КОНКТРУКТОРЫ
        /// <summary>
        /// Создает пустое множество с неизвестным создателем.
        /// </summary>
        public Set() { Elements = new List<int>(); Owner = new Owner(0, "Безымянный", "Безымянный"); }
        /// <summary>
        /// Создает множество с переданными элементами и указанным создателем.
        /// </summary>
        /// <param name="elements"></param>
        public Set(IEnumerable<int> collection, int OwnerId, string OwnerName, string OwnerOrg) { Elements = new List<int>(collection); Owner = new Owner(OwnerId, OwnerName, OwnerOrg); }
        public Set(IEnumerable<int> collection, Owner owner) { Elements = new List<int>(collection); Owner = owner; }

        // МЕТОДЫ
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(Elements.Count);
            for (int i = 0; i < Elements.Count; i++) {
                builder.Append(this[i]);
                if (i != Elements.Count - 1)
                    builder.Append(' ');
            }
            return builder.ToString();
        }

        // ПОДКЛАСС
        /// <summary>
        /// Дата создания.
        /// </summary>
        public class Date
        {
            private uint day, month;
            /// <summary>
            /// День создания.
            /// </summary>
            public uint Day { get { return day; } set { if ((value > 0) && (value < 31)) day = value; else day = 1; } }
            /// <summary>
            /// Месяц создания.
            /// </summary>
            public uint Month { get { return month; } set { if ((value > 0) && (value < 13)) month = value; else month = 0; } }
            /// <summary>
            /// Год создания.
            /// </summary>
            public uint Year { get; set ; }
            /// <summary>
            /// Создает объкт Date с указанной датой.
            /// </summary>
            /// <param name="day">День создания.</param>
            /// <param name="month">Месяц создания.</param>
            /// <param name="year">Год создания.</param>
            public Date(uint day, uint month, uint year) { Day = day; Month = month; Year = year; }
            public override string ToString() { return $"{Day}.{Month}.{Year}"; }
        }
        
    }
    /// <summary>
    /// Класс владельца.
    /// </summary>
    class Owner
    {
        /// <summary>
        /// Идентификатор владельца.
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// Имя владельца.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Организация владельца.
        /// </summary>
        string Organization { get; set; }
        public Owner(int id, string name, string company) { Id = id; Name = name; Organization = company; }
    }

    static class MathOperations
    {
        /// <summary>
        /// Возвращает максимальный элемент множества s.
        /// </summary>
        /// <param name="s">Множество Set, из которого получаем максимальное.</param>
        /// <returns>Максимальный эдемент множества s.</returns>
        public static int GetMaxElement(Set s)
        {
            int max = s.Elements[0];
            for (int i = 0; i < s.Elements.Count; i++)
                if (max < s.Elements[i])
                    max = s.Elements[i];
            return max;
        }

        /// <summary>
        /// Возвращает минимальный элемент множества s.
        /// </summary>
        /// <param name="s">Множество Set, из которого получаем минимальное.</param>
        /// <returns>Минимальный эдемент множества s.</returns>
        public static int GetMinElement(Set s)
        {
            int min = s.Elements[0];
            for (int i = 0; i < s.Elements.Count; i++)
                if (min > s.Elements[i])
                    min = s.Elements[i];
            return min;
        }

        /// <summary>
        /// Возвращает количество элементов множества s.
        /// </summary>
        /// <param name="s">Множество, количество элементов которого нужно узнать.</param>
        /// <returns>Количество элементов множества s.</returns>
        public static int GetCount(Set s) { return s.Elements.Count; }
    }

    static class Extensions
    {
        /// <summary>
        /// Шифрует строку статичным сдвигом символов по таблице символов.
        /// </summary>
        /// <param name="step">Шаг, на который сдвигается код каждого символа.</param>
        /// <returns></returns>
        public static string Encode(this string str, int step)
        {
            int count = str.Count();
            StringBuilder builder = new StringBuilder(count);
            for (int i = 0; i < count; i++)
                builder.Append((char)((int)str[i] + step));
            return builder.ToString();
        }

        /// <summary>
        /// роверяет упорядоченность множества s.   
        /// </summary>
        /// <param name="s">Проверяемое множество.</param>
        /// <returns>Упорядочено или нет.</returns>
        public static bool CheckSort(this Set s)
        {
            for (int i = 0; i < (int)s - 1; i++)
                if (s[i] <= s[i + 1])
                    continue;
                else return false;
            return true;
        }
    }

    class Program
    {
        static void Main()
        {
            Set s1 = new Set();
            s1++;
            s1++;
            s1++;
            s1++;
            s1++;
            Console.WriteLine("Множества S.");
            Console.WriteLine($"S1, {s1.Elements.Count} элементов:\n{s1.ToString()}");
            Set s2 = new Set();
            s2++;
            s2++;
            s2++;
            s2++;
            Console.WriteLine($"S2, {s2.Elements.Count} элементов:\n{s2.ToString()}");
            s1 += s2;
            Console.WriteLine($"S1 += S2:\n{s1.ToString()}");

            Console.WriteLine("\nСравнение множеств (по мощностям).");
            Console.WriteLine($"Мощность множества s1 = {s1.Elements.Count}");
            Console.WriteLine($"Мощность множества s2 = {s2.Elements.Count}");
            Console.WriteLine($"s1 >= s2: {s1 >= s2}");
            Console.WriteLine($"s1 <= s2: {s1 <= s2}");

            Owner owner = new Owner(0, "Unnamed.", "Unnamed.");

            Set.Date date = new Set.Date(2, 11, 2000);
            Console.WriteLine($"Дата создания: {date.ToString()}.");

            string str = "The world around me.";
            Console.WriteLine($"Шифрование строки. Оригинал:\n{str}\nШифрованная:\n{str.Encode(1)}");

            Console.WriteLine("\nDone.");
            Console.ReadKey();
        }
    }
}
