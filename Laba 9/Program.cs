﻿using System;

namespace Laba_9
{
    class Program
    {
        static void Main()
        {
            Boss Boss1 = new Boss(100);
            Boss1.TurnOn += (int v) => { if (Boss1.IsAlive) if (v > Boss1.WorkingVoltage) { Console.WriteLine($"Аж {v}? Умираааа-аа-а-аю..."); Boss1.IsAlive = false; } else { Console.WriteLine("Готовься умереть!"); } else { Console.WriteLine("*Boss1 мертв и не издает звуков*"); } } ;
            Boss1.Upgrade += (int v) => Console.WriteLine("Boss1 готов к работе! Новое напряжение = " + v);
            Console.WriteLine("Запускаю босса 1 c напряжением 220 В...");
            Boss1.Start(220);

            Boss Boss2 = new Boss(220);
            Boss2.TurnOn += (int v) => { if (Boss2.IsAlive) if (v > Boss2.WorkingVoltage) { Console.WriteLine($"Я ЕЩЕ ВЕРНУСЬ!!!"); Boss2.IsAlive = false; } else { Console.WriteLine("Настала твоя очередь отключиться навсегда!"); } else { Console.WriteLine("*Boss2 мертв и не издает звуков*"); } };
            Boss2.Upgrade += (int v) => Console.WriteLine("Boss2 готов к работе! Новое напряжение = " + v);
            Console.WriteLine("Запускаю босса 2 c напряжением 500 В...");
            Boss2.Start(500);

            Console.WriteLine("\nСнова запускаю босса 1 c напряжением 220 В...");
            Boss1.Start(220);
            Console.WriteLine("Снова запускаю босса 2 c напряжением 500 В...");
            Boss2.Start(500);

            Console.WriteLine("Ремонтируем роботов...");
            Boss1.Repair(220);
            Boss1.Repair(500);

            Console.WriteLine("\nСнова запускаю босса 1 c напряжением 220 В...");
            Boss1.Start(220);
            Console.WriteLine("Снова запускаю босса 2 c напряжением 500 В...");
            Boss2.Start(500);


            Console.WriteLine("Задание 2");
            string str = "Здравствуй,        ABCDEFG                                    маманя.!?(\"'…:;)";
            Console.WriteLine("Оригинальная строка:\n" + str + "\nСтрока после обработки:\n");

            Func<string, char, int, string> AddChars = StringExtends.AddChars;
            Func<string, string> RemPunct = StringExtends.RemovePunctuation;
            Func<string, string> RemSp = StringExtends.RemoveSpaces;
            Func<string, string> ToLower = StringExtends.ToLowerCase;
            Func<string, string> ToUpper = StringExtends.ToUpperCase;

            str = AddChars(str, 'q', 10);
            Console.WriteLine(str);
            str = RemPunct(str);
            Console.WriteLine(str);
            str = RemSp(str);
            Console.WriteLine(str);
            str = ToLower(str);
            Console.WriteLine(str);
            str = ToUpper(str);
            Console.WriteLine(str);
            
            Console.ReadLine();
        }
    }
}