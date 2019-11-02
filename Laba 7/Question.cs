using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_7
{
    sealed class Question // ГОТОВ
    {
        // свойства
        public string Answer { get; }
        public string Text { get; set; }

        // конструкторы и методы
        public Question(string question, string answer) { Text = question; Answer = answer; }
        public override string ToString() { return $"Вопрос: {Text} ({Answer})"; }
    }
}
