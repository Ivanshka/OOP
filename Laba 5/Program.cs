using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba_5
{
    // C# Code Convention: http://rsdn.org/article/mag/200401/codestyle.XML#EX
    // Наследование, композиция, агрегация: https://habr.com/ru/post/354046/

    // Испытание, Тест, Экзамен, Выпускной экзамен, Вопрос

    /*
                          Схема наследования:
                          
                                  ICheck
                                    |
                         _______Испытание______
                        /           |          \
                      Тест       Экзамен    Вып.экз.

                           Схема композиции:

        Тест -> 5 х Вопрос
        Экзамен -> 2 х Вопрос
        Вып.экз. -> 4 х Вопрос

    */

    interface ICheck
    {
        string Name { get; set; }
        string Time { get; set; }
        void Test();
    }

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

    sealed class Question // ГОТОВ
    {
        // свойства
        public string Answer { get; }
        public string Text { get; set; }

        // конструкторы и методы
        public Question(string question, string answer) { Text = question; Answer = answer; }
        public override string ToString() { return $"Вопрос: {Text} ({Answer})"; }
    }
    
    abstract class Ispitanie : Printer, ICheck
    {
        // свойства
        public string Name { get; set; }
        public string Time { get; set; }

        // конструкторы и медоты
        public Ispitanie(string name, string time) { Name = name; Time = time; }
        public override string ToString() { return $"Имя: {Name}, время: {Time}"; }
        public void Test() { Console.WriteLine("*Это текст-реализация для абстрактного класса."); }
        void ICheck.Test() { Console.WriteLine("*Это текст-реализация для интерфейса."); }
    }

    class Test : Ispitanie
    {
        // поля
        private Question[] Questions;

        // конструкторы и методы
        /// <summary>
        /// Создает тест. Если кол-во вопросов и ответов не совпадает, добавляются только парные с ответами вопросы.
        /// </summary>
        /// <param name="name">Название теста</param>
        /// <param name="time">Время теста</param>
        /// <param name="questions">Массив вопросов</param>
        /// <param name="answers">Массив ответов</param>
        public Test(string name, string time, string[] questions, string[] answers) : base(name, time)
        {
            int count = Math.Min(questions.Length, answers.Length);
            Questions = new Question[count];
            for (int i = 0; i < count; i++)
                Questions[i] = new Question(questions[i], answers[i]);
            Name = name;
            Time = time;
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder($"Тест: {Name}, время: {Time}, вопросы:\n");
            for (int i = 0; i < Questions.Length; i++)
                str.Append(Questions[i].ToString());
            return str.ToString();
        }
    }

    class Examination : Ispitanie
    {
        // поля
        private Question one;
        private Question two;
        
        // конструкторы и методы
        public Examination(string name, string time, string q1, string a1, string q2, string a2) : base(name, time)
        {
            Name = name;
            Time = time;
            one = new Question(q1, a1);
            two = new Question(q2, a2);
        }
        public override string ToString() { return $"Экзамен: {Name}, время: {Time}, вопросы:\n{one.ToString()}\n{two.ToString()}\n"; }
    }

    class FinalExamination : Ispitanie
    {
        // поля
        private Question one;
        private Question two;
        private Question three;
        private Question four;

        public FinalExamination(string name, string time, string q1, string a1, string q2, string a2, string q3, string a3, string q4, string a4) : base(name, time)
        {
            Name = name;
            Time = time;
            one = new Question(q1, a1);
            two = new Question(q2, a2);
            three = new Question(q3, a3);
            four = new Question(q4, a4);
        }
        public override string ToString() { return $"Экзамен: {Name}, время: {Time}, вопросы:\n{one.ToString()}\n{two.ToString()}\n{three.ToString()}\n{four.ToString()}\n"; }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Вызываем метод Test() с разной реализацией для класса и интерфейса...");
            Examination ex1 = new Examination("Физика", "8:00", "Что такое дилектрик?", "Это изолятор, пропускающий ток", "Что делает электродвигатель на 5 В при подключении 55 В??", "Сгорает к чертям");
            ex1.Test();
            (ex1 as ICheck).Test(); // или же ((ICheck)examination).Test();

            Console.WriteLine("Создаем объекты различных классов выводим инфу через ссылки на абстрактный класс / интерфейс.");
            Examination ex2 = new Examination("ОАиП", "8:00", "Самый страшный Звэр на свете?", "Бедодел.", "Кто такой Бедодел?", "Рейд-босс первашей.");
            FinalExamination fex1 = new FinalExamination("ОС", "8:30", "Что такое ОС?", "Набор прог", "Что такое ОЗУ?", "Оперативное запоминающее устройство", "Что такое ЦП?", "Центральный процессор", "Зачем он нужен?", "Он - \"мозг\" компа");
            Console.WriteLine("Первый экзамен: " + (ex2 as ICheck).Name);
            Console.WriteLine("Время второго: " + (fex1 as Ispitanie).Time);
            
            Console.WriteLine($"\n Вызываем ToString() для объектов массива...");
            // сделаем один тест, а то попусту класс создан
            string[] questions = { "Что такое парсек?", "Где находится Черная дыра?", "Газовые гиганты Солнечной системы?", "Созвездие в виде буквы W?", "Звезда, переливающаяся зеленым, желтым и синим цветами?" };
            string[] answers = { "Единица измерения расстояния, равная расстоянию до объекта. :D ", "В центре галактики", "Юпитер, Сатурн, Уран, Нептун", "Кассиопея", "Капелла" };
            Test test = new Test("Астрономия", "10:05", questions, answers);

            Ispitanie[] mas = new Ispitanie[4];
            // заносим в массив ссылки на объекты производных классов
            mas[0] = ex1;
            mas[1] = ex2;
            mas[2] = fex1;
            mas[3] = test;
            // создаем принтер
            Printer p = new Printer();

            for (int i = 0; i < mas.Length; i++)
                p.iAmPrinting(mas[i]);
            
            Console.WriteLine("\nDone.");
            Console.ReadKey();
        }
    }
}
