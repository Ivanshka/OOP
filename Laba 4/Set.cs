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
        public Owner Owner { get; set; }

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
            for (int i = 0; i < Elements.Count; i++)
            {
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
            public uint Year { get; set; }
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
}
