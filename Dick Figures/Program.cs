using System;
using System.Threading;

namespace Dick_Figures
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Dick Figures";
            while (true)
            {
                Console.WriteLine("  ");
                Console.WriteLine("LOL   ROFL:ROFL:LOL:         ");
                Console.WriteLine("  \\         _____I_____");
                Console.WriteLine("    ========     |   |[\\");
                Console.WriteLine("            \\____O==____)");
                Console.WriteLine("            ____I_I___/");
                Thread.Sleep(50);
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(" L");
                Console.WriteLine(" O             :LOL:ROFL:ROFL");
                Console.WriteLine(" L\\         _____I_____");
                Console.WriteLine("    ========     |   |[\\");
                Console.WriteLine("            \\____O==____)");
                Console.WriteLine("            ____I_I___/");
                Thread.Sleep(50);
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
