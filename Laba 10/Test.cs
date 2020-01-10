using System;
using System.Text;

namespace Laba_10
{
    /// <summary>
    /// Класс теста
    /// </summary>
    class Test : Ispitanie
    {
        // поля
        private Question[] Questions;

        // конструкторы и методы
        /// <summary>
        /// Создает тест. Если кол-во вопросов и ответов не совпадает, добавляются только парные с ответами вопросы.
        /// </summary>
        /// <param name="name">Название теста</param>
        /// <param name="time">Время теста</param>
        /// <param name="questions">Массив вопросов</param>
        /// <param name="answers">Массив ответов</param>
        public Test(string name, string time, string[] questions, string[] answers) : base(name, time)
        {
            int count = Math.Min(questions.Length, answers.Length);
            Questions = new Question[count];
            for (int i = 0; i < count; i++)
                Questions[i] = new Question(questions[i], answers[i]);
            Name = name;
            Time = time;
        }

        public override string Name { get; set; }
        public override string Time { get; set; }

        /// <summary>
        /// Метод, который реализуется отдельно для интерфейса и для абстрактного класса
        /// </summary>
        public override void Method()
        {
            Console.WriteLine("Реализация для класса " + typeof(Question));
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder($"Тест: {Name}, время: {Time}, вопросы:\n");
            for (int i = 0; i < Questions.Length; i++)
                str.Append(Questions[i].ToString());
            return str.ToString();
        }
    }
}
