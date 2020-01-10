using System;

namespace Laba_5
{
    /// <summary>
    /// Класс с полиморфным методом для вывода на консоль.
    /// </summary>
    class Printer
    {
        public virtual void iAmPrinting(Ispitanie test)
        {
            if (test is Test)
                Console.WriteLine($"Тип: Test. Вызываю ToString()...\n" + test.ToString());
            if (test is Examination)
                Console.WriteLine($"Тип: Examination. Вызываю ToString()...\n" + test.ToString());
            if (test is FinalExamination)
                Console.WriteLine($"Тип: FinalExamination. Вызываю ToString()...\n" + test.ToString());
        }
    }
}
