using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_7
{
    class Printer
    {
        public virtual void iAmPrinting(Ispitanie test)
        {
            if (test is Test)
                Console.WriteLine($"Тип: Test. Вызываю ToString()...\n" + test.ToString());
            if (test is Examination)
                Console.WriteLine($"Тип: Examination. Вызываю ToString()...\n" + test.ToString());
            if (test is Zachet)
                Console.WriteLine($"Тип: FinalExamination. Вызываю ToString()...\n" + test.ToString());
        }
    }
}
