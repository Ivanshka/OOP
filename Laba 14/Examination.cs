using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Laba_14
{
    /// <summary>
    /// Класс экзамена
    /// </summary>
    [Serializable]
    [XmlRoot]
    [DataContract]
    public class Examination
    {
        [XmlElement]
        [DataMember]
        public Question one;
        //[XmlElement]
        [DataMember]
        public Question two;

        public Examination()
        {
            Name = "Автоматическая инициализация: название не указано!";
            Time = "Автоматическая инициализация: время не указано!";
            one = two = null;
        }

        // конструкторы и методы
        public Examination(string name, string time, string q1, string a1, string q2, string a2)
        {
            Name = name;
            Time = time;
            one = new Question(q1, a1);
            two = new Question(q2, a2);
        }

        [XmlElement]
        [DataMember]
        public string Name { get; set; }
        [XmlElement]
        [DataMember]
        public string Time { get; set; }

        public void Method()
        {
            Console.WriteLine("Реализация для класса " + typeof(Examination));
        }
        public override string ToString() { return $"Экзамен: {Name}, время: {Time}, вопросы:\n{one.ToString()}\n{two.ToString()}\n"; }
    }
}
