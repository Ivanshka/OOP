using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Laba_14
{
    /// <summary>
    /// Класс вопроса
    /// </summary>
    [XmlRoot]
    [Serializable]
    [DataContract]
    public class Question // ГОТОВ
    {
        // свойства
        [XmlElement]
        [DataMember]
        public string Answer { get; set; }
        [XmlElement]
        [DataMember]
        public string Text { get; set; }

        // конструкторы и методы
        public Question() { Text = "Автоматическая инициализация: вопрос не указан!"; Answer = "Автоматическая инициализация: ответ не указан!"; }
        public Question(string question, string answer) { Text = question; Answer = answer; }
        public override string ToString() { return $"Вопрос: {Text} ({Answer})"; }
    }
}
