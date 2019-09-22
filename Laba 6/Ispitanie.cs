using System;

namespace Laba_6
{
    abstract partial class Ispitanie : Printer, ICheck
    {
        // конструкторы и медоты
        public Ispitanie(string name, string time) { Name = name; Time = time; }
        public override string ToString() { return $"Имя: {Name}, время: {Time}"; }
        public void Test() { Console.WriteLine("*Это текст-реализация для абстрактного класса."); }
        void ICheck.Test() { Console.WriteLine("*Это текст-реализация для интерфейса."); }
    }
}
