using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_4
{
    class Program
    {
        static void Main()
        {
            Set s1 = new Set();
            s1++;
            s1++;
            s1++;
            s1++;
            s1++;
            Console.WriteLine("Множества S.");
            Console.WriteLine($"S1, {s1.Elements.Count} элементов:\n{s1.ToString()}");
            Set s2 = new Set();
            s2++;
            s2++;
            s2++;
            s2++;
            Console.WriteLine($"S2, {s2.Elements.Count} элементов:\n{s2.ToString()}");
            s1 += s2;
            Console.WriteLine($"S1 += S2:\n{s1.ToString()}");

            Console.WriteLine("\nСравнение множеств (по мощностям).");
            Console.WriteLine($"Мощность множества s1 = {s1 + 0}");
            Console.WriteLine($"Мощность множества s2 = {s2 + 0}");
            Console.WriteLine($"s1 >= s2: {s1 >= s2}");
            Console.WriteLine($"s1 <= s2: {s1 <= s2}");

            Owner owner = new Owner(0, "Unnamed.", "Unnamed.");

            Set.Date date = new Set.Date(2, 11, 2000);
            Console.WriteLine($"Дата создания: {date.ToString()}.");

            string str = "The world around me.";
            Console.WriteLine($"Шифрование строки. Оригинал:\n{str}\nШифрованная:\n{str.Encode(1)}");

            Console.WriteLine("\nDone.");

            s1.Owner.Id = 1;



            Console.ReadKey();
        }
    }
}
