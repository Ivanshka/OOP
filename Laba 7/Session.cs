using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_7
{
    /// <summary>
    /// Класс-контейнер
    /// </summary>
    class Session
    {
        public List<Ispitanie> list;
        /// <summary>
        /// Количество всех испытаний
        /// </summary>
        public int Count;

        // вместо методов get и set, требуемых в лабе проще и разумнее сделать индексатор
        public Ispitanie this[int index] { get { return list[index]; } set { list[index] = value; } }

        // итератор для фозможности использования foreach
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
                yield return list[i];
        }

        public Session() { list = new List<Ispitanie>(); Count = list.Count; }
        public void Add(Ispitanie isp) { list.Add(isp); Count++; }
        public void Delete(int index) { list.RemoveAt(index); Count--; }
        public void Delete(Ispitanie isp) { list.Remove(isp); Count--; }
        public void Show()
        {
            Console.WriteLine("\nСписок:");
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(i + 1 + ") " + list[i].ToString());
        }
    }
}
