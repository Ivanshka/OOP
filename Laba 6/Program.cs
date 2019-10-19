using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Laba_6
{
    interface ICheck
    {
        string Name { get; set; }
        string Time { get; set; }
        void Test();
    }

    abstract partial class Ispitanie : Printer, ICheck
    {
        // свойства
        public string Name { get; set; }
        public string Time { get; set; }
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
        static void Main()
        {
            SLaba a = new SLaba(5, "Пятница");
            Console.WriteLine(a.ToString());
            Moduls moduls = Moduls.ABCObjects;
            Console.WriteLine($"Текущий модуль: {moduls.ToString()}");

            // объекты для списка
            string[] questions = { "Что такое дилектрик?", "Что делает электродвигатель на 5 В при подключении 55 В??" };
            string[] answers = { "Это изолятор, пропускающий ток", "Сгорает к чертям" };
            Examination ex1 = new Examination("Физика", "8:00", "Крутой Гумманитарий", questions, answers);

            questions = new string[]{ "Самый страшный Звэр на свете?", "Кто такой Бедодел?"};
            answers = new string[]{ "Бедодел", "Рейд-босс первашей." };
            Examination ex2 = new Examination("ОАиП", "8:30", "Бедодел", questions, answers);

            questions = new string[] { "Академический язык программирования?", "Зачем он нужен?" };
            answers = new string[] { "Сы плас плас", "Чтобы тратить нервы" };
            Examination ex3 = new Examination("ОАиП", "9:30", "Бедодел", questions, answers);

            questions = new string[] { "Что такое ОС?", "Что такое ОЗУ?", "Что такое ЦП?", "Зачем он нужен?", "Чем знаменит философ Зенон?" };
            answers = new string[] { "Набор прог", "Оперативное запоминающее устройство", "Центральный процессор", "Он - \"мозг\" компа", "Да хз ваще"};
            Test test1 = new Test("ОС", "8:30", questions, answers);

            questions = new string[]{ "Что такое парсек?", "Где находится Черная дыра?", "Газовые гиганты Солнечной системы?", "Созвездие в виде буквы W?", "Звезда, переливающаяся зеленым, желтым и синим цветами?" };
            answers = new string[]{ "Единица измерения расстояния, равная расстоянию до объекта. :D ", "В центре галактики", "Юпитер, Сатурн, Уран, Нептун", "Кассиопея", "Капелла" };
            Test test2 = new Test("Астрономия", "10:05", questions, answers);
            
            Session s = new Session();
            s.Add(ex1);
            s.Add(ex2);
            s.Add(ex3);
            s.Add(test1);
            s.Add(test2);

            s.Show();

            Console.WriteLine("Общее количество испытаний (экзов) в сессии: "+ s.GetCountIspitanie());
            Console.WriteLine("\nКоличество тестов с заданным числом вопросов (ищем по 5-ке): " + s.GetCountOfTestsByQuestions(5));
            Console.WriteLine("\nИщем экзамены по заданному предмету. Ищем по - ОАиПу:\n" + s.SearchExaminationsByName("ОАиП"));
            

            Console.WriteLine("\nDone.");
            Console.ReadKey();
        }
    }
}
