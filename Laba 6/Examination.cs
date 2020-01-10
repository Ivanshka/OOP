using System;
using System.Text;

namespace Laba_6
{
    class Examination : Ispitanie, ICheck
    {
        // поля
        private Question[] Questions;
        public string Teacher { get; }

        public override string Name { get; set; }
        public override string Time { get; set; }

        // конструкторы и методы
        public Examination(string name, string time, string teacher, string[] questions, string[] answers) : base(name, time)
        {
            Name = name;
            Time = time;
            Teacher = teacher;
            int count = Math.Min(questions.Length, answers.Length);
            Questions = new Question[count];
            for (int i = 0; i < count; i++)
                Questions[i] = new Question(questions[i], answers[i]);
        }

        public override void Method()
        {
            Console.WriteLine("Реализация для класса " + typeof(Examination));
        }
        void ICheck.Method()
        {
            Console.WriteLine("Реализация для интерфейса ICheck");
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder($"Экзамен: {Name}, время: {Time}, препод: {Teacher}, вопросы:\n");
            for (int i = 0; i < Questions.Length; i++)
                str.Append(Questions[i].ToString() + '\n');
            return str.ToString();
        }
    }
}
