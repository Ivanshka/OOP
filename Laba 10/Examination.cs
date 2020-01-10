using System;

namespace Laba_10
{
    /// <summary>
    /// Класс экзамена
    /// </summary>
    class Examination : Ispitanie, ICheck
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

        public override string Name { get; set; }
        public override string Time { get; set; }

        public override void Method()
        {
            Console.WriteLine("Реализация для класса " + typeof(Examination));
        }
        void ICheck.Method()
        {
            Console.WriteLine("Реализация для интерфейса ICheck");
        }
        public override string ToString() { return $"Экзамен: {Name}, время: {Time}, вопросы:\n{one.ToString()}\n{two.ToString()}\n"; }
    }
}
