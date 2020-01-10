using System;

namespace Laba_10
{
    /// <summary>
    /// Класс вопроса
    /// </summary>
    sealed class Question: IComparable
    {
        // свойства
        public string Answer { get; }
        public string Text { get; set; }

        // конструкторы и методы
        public Question(string question, string answer) { Text = question; Answer = answer; }
        public override string ToString() { return $"Вопрос: {Text} ({Answer})"; }

        public int CompareTo(object obj)
        {
            Question temp = obj as Question;
            return Text.CompareTo(temp.Text);
        }
    }
}
