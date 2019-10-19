using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_5
{
    /// <summary>
    /// Абстрактный класс испытания
    /// </summary>
    abstract class Ispitanie : Printer, ICheck
    {
        // свойства
        public string Name { get; set; }
        public string Time { get; set; }

        // конструкторы и медоты
        public Ispitanie(string name, string time) { Name = name; Time = time; }
        public override string ToString() { return $"Имя: {Name}, время: {Time}"; }
        public void Test() { Console.WriteLine("*Это реализация метода для абстрактного класса."); }
        void ICheck.Test() { Console.WriteLine("*Это реализация метода для интерфейса."); }
    }
}
