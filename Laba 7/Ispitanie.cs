namespace Laba_7
{
    abstract partial class Ispitanie : Printer
    {
        // конструкторы и медоты
        public Ispitanie(string name, string time) { Name = name; Time = time; }
        public abstract void Method();
    }
}
