namespace Laba_6
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
