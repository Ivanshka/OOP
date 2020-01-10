namespace Laba_5
{
    /// <summary>
    /// Интерфейс "ЯПроверяемый"
    /// </summary>
    interface ICheck
    {
        void Method();
    }

    /// <summary>
    /// Абстрактный класс испытания
    /// </summary>
    abstract class Ispitanie : Printer
    {
        // свойства
        public abstract string Name { get; set; }
        public abstract string Time { get; set; }

        // конструкторы и методы
        public Ispitanie(string name, string time) { Name = name; Time = time; }
        public abstract void Method();
    }
}
