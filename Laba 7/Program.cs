using System;
using System.Diagnostics;

namespace Laba_7
{
    // https://habr.com/ru/post/231585/
    // https://habr.com/ru/post/178805/

    interface ICheck
    {
        void Method();
    }

    abstract partial class Ispitanie : Printer
    {
        // поля
        private string time;
        private string name;
        // свойства
        public string Name { get { return name; } set { if (value.Length < 3) throw new InvalidNameException("Имя слишком короткое!", value); else name = value; } }
        public string Time { get { return time; } set { if (value.Length > 5) throw new InvalidTimeValueException("Некорректное значение времени!", value); else time = value; } }
    }

    // структура
    struct SLaba
    {
        public int Number;
        public string Str;
        public SLaba(int num, string s) { Number = num; Str = s; }
        public override string ToString() { return $"Число: {Number}, текст: \"{Str}\""; }
    }

    // перечисление
    enum Moduls { GraphABC, ABCObjects, ButtonsABC, Drawman };

    class Program
    {
        static void Func1()
        {
            Func2();
        }

        static void Func2()
        {
            Func3();
        }

        static void Func3()
        {
            Debug.Assert(1 == 2, "System.Diagnostics.Debug:\n");
        }

        static void Main()
        {
            Console.WriteLine("Генерация исключений:");

            Console.WriteLine("\nИсключение 1:");
            string[] questions = new string[] { "Что такое парсек?", "Где находится Черная дыра?", "Газовые гиганты Солнечной системы?", "Созвездие в виде буквы W?", "Звезда, переливающаяся зеленым, желтым и синим цветами?" };
            string[] answers = new string[] { "Единица измерения расстояния, равная расстоянию до объекта. :D ", "В центре галактики", "Юпитер, Сатурн, Уран, Нептун", "Кассиопея", "Капелла" };
            try
            {
                Test test = new Test("Астрономия", "10а:05", questions, answers);
            }
            catch (InvalidTimeValueException e)
            {
                Console.WriteLine("InvalidTimeValueException:\n" + e.ToString());
            }
            finally
            {
                Console.WriteLine("finally 1");
            }

            Console.WriteLine("\nИсключение 2:");
            try
            {
                Test test = new Test("Ас", "10:05", questions, answers);
            }
            catch (InvalidNameException e)
            {
                Console.WriteLine("InvalidNameException:\n" + e.ToString());
            }
            finally
            {
                Console.WriteLine("finally 2");
            }

            Console.WriteLine("\nИсключение 3:");
            try
            {
                ExceptionDemonstration test = new ExceptionDemonstration("asd");
            }
            catch (ObjectIsNotIntegerException e)
            {
                Console.WriteLine("ObjectIsNotIntegerException:\n" + e.ToString());
            }
            finally
            {
                Console.WriteLine("finally 3");
            }

            Console.WriteLine("\nИсключение 4:");
            string[] str = new string[5];
            try
            {
                str[6] = "anything";
                Console.WriteLine("It's OK");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("IndexOutOfRangeException:\n" + e.ToString());
            }
            finally
            {
                Console.WriteLine("finally 4");
            }
            
            Console.WriteLine("\nИсключение 5:");
            try
            {
                int zero = 0;
                int test = 100 / zero;
            }
            catch
            {
                Console.WriteLine("DivideByZeroException:\n");
            }
            finally
            {
                Console.WriteLine("finally 5");
            }

            Func1();

            Console.WriteLine("\nDone.");
            Console.ReadKey();
        }
    }
}
