using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_5
{
    /// <summary>
    /// Класс экзамена
    /// </summary>
    class Examination : Ispitanie
    {
        // поля
        private Question one;
        private Question two;

        // конструкторы и методы
        public Examination(string name, string time, string q1, string a1, string q2, string a2) : base(name, time)
        {
            Name = name;
            Time = time;
            one = new Question(q1, a1);
            two = new Question(q2, a2);
        }
        public override string ToString() { return $"Экзамен: {Name}, время: {Time}, вопросы:\n{one.ToString()}\n{two.ToString()}\n"; }
    }
}
