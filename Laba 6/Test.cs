using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_6
{
    class Test : Ispitanie
    {
        // поля
        private Question[] Questions;
        // свойства
        /// <summary>
        /// Количество вопросов в тесте.
        /// </summary>
        public Byte CountOfQuestions { get; }
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
            CountOfQuestions = (byte)Math.Min(questions.Length, answers.Length);
            Questions = new Question[CountOfQuestions];
            for (int i = 0; i < CountOfQuestions; i++)
                Questions[i] = new Question(questions[i], answers[i]);
            Name = name;
            Time = time;
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder($"Тест: {Name}, время: {Time}, вопросы:\n");
            for (int i = 0; i < Questions.Length; i++)
                str.Append(Questions[i].ToString() + '\n');
            return str.ToString();
        }
    }
}
