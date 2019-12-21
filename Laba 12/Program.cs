using System;

namespace Laba_12
{
    class Program
    {
        static void Main()
        {
            string type = "Laba_12.SomeClass"; // System.String
            Console.WriteLine("Пишу инфу о классе в файл...\n");
            Reflector.WriteClassInfo("Laba_12.SomeClass");
            Console.WriteLine("* * * МЕТОДЫ * * *");
            Reflector.GetMethods(type);

            Console.WriteLine("\n* * * СВОЙСТВА И ПОЛЯ * * *");
            Reflector.GetPropertiesAndFields(type);

            Console.WriteLine("\n* * * ИНТЕРФЕЙСЫ * * *");
            Reflector.GetInterfaces(type);

            Console.WriteLine("\n* * * МЕТОДЫ С ПАРАМЕТРАМИ ТИПА INT * * *\n");
            Reflector.GetMethodsByParam(type);

            Console.WriteLine("\n* * * ВЫЗОВ МЕТОДА * * *\n");
            Reflector.CallFunction("System.Console", "WriteLine");


            Console.WriteLine("DONE.");
            System.Diagnostics.Process.Start("info.txt");

            Console.ReadLine();
        }
    }

    class SomeClass
    {
        public int Age { get; set; }

        public SomeClass()
        {
        }

        public SomeClass(int age)
        {
            Age = age;
        }
    }
}
