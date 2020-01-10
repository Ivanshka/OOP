using System;

namespace Laba_10
{
    class FinalExamination : Ispitanie
    {
        // поля
        private Question one;
        private Question two;
        private Question three;
        private Question four;

        public FinalExamination(string name, string time, string q1, string a1, string q2, string a2, string q3, string a3, string q4, string a4) : base(name, time)
        {
            Name = name;
            Time = time;
            one = new Question(q1, a1);
            two = new Question(q2, a2);
            three = new Question(q3, a3);
            four = new Question(q4, a4);
        }

        public override string Name { get; set; }
        public override string Time { get; set; }

        public override void Method()
        {
            Console.WriteLine("Реализация для класса " + typeof(FinalExamination));
        }

        public override string ToString() { return $"Экзамен: {Name}, время: {Time}, вопросы:\n{one.ToString()}\n{two.ToString()}\n{three.ToString()}\n{four.ToString()}\n"; }
    }
}
