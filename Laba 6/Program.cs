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

    sealed class Question // ГОТОВ
    {
        // свойства
        public string Answer { get; }
        public string Text { get; set; }

        // конструкторы и методы
        public Question(string question, string answer) { Text = question; Answer = answer; }
        public override string ToString() { return $"Вопрос: {Text} ({Answer})"; }
    }

    abstract partial class Ispitanie : Printer, ICheck
    {
        // свойства
        public string Name { get; set; }
        public string Time { get; set; }
    }

    class Test : Ispitanie
    {
        // поля
        private Question[] Questions;
        // свойства
        /// <summary>
        /// Количество вопросов в тесте.
        /// </summary>
        public Byte CountOfQuestions { get; }
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
            CountOfQuestions = (byte)Math.Min(questions.Length, answers.Length);
            Questions = new Question[CountOfQuestions];
            for (int i = 0; i < CountOfQuestions; i++)
                Questions[i] = new Question(questions[i], answers[i]);
            Name = name;
            Time = time;
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder($"Тест: {Name}, время: {Time}, вопросы:\n");
            for (int i = 0; i < Questions.Length; i++)
                str.Append(Questions[i].ToString() + '\n');
            return str.ToString();
        }
    }

    class Examination : Ispitanie
    {
        // поля
        private Question[] Questions;
        public string Teacher { get; }

        // конструкторы и методы
        public Examination(string name, string time, string teacher, string[] questions, string[] answers) : base(name, time)
        {
            Name = name;
            Time = time;
            Teacher = teacher;
            int count = Math.Min(questions.Length, answers.Length);
            Questions = new Question[count];
            for (int i = 0; i < count; i++)
                Questions[i] = new Question(questions[i], answers[i]);
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder($"Экзамен: {Name}, время: {Time}, препод: {Teacher}, вопросы:\n");
            for (int i = 0; i < Questions.Length; i++)
                str.Append(Questions[i].ToString() + '\n');
            return str.ToString();
        }
    }

    class Zachet : Ispitanie
    {
        // поля
        private Question one;
        private Question two;
        private Question three;
        private Question four;

        public Zachet(string name, string time, string q1, string a1, string q2, string a2, string q3, string a3, string q4, string a4) : base(name, time)
        {
            Name = name;
            Time = time;
            one = new Question(q1, a1);
            two = new Question(q2, a2);
            three = new Question(q3, a3);
            four = new Question(q4, a4);
        }
        public override string ToString() { return $"Зачет: {Name}, время: {Time}, вопросы:\n{one.ToString()}\n{two.ToString()}\n{three.ToString()}\n{four.ToString()}\n"; }
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

    /// <summary>
    /// Класс-контейнер
    /// </summary>
    class Session
    {
        public List<Ispitanie> list;
        /// <summary>
        /// Количество всех испытаний
        /// </summary>
        public int Count;

        // вместо методов get и set, требуемых в лабе проще и разумнее сделать индексатор
        public Ispitanie this[int index] { get { return list[index]; } set { list[index] = value; } }

        // итератор для фозможности использования foreach
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
                yield return list[i];
        }

        public Session() { list = new List<Ispitanie>(); Count = list.Count; }
        public void Add(Ispitanie isp) { list.Add(isp); Count++; }
        public void Delete(int index) { list.RemoveAt(index); Count--; }
        public void Delete(Ispitanie isp) { list.Remove(isp); Count--; }
        public void Show()
        {
            Console.WriteLine("\nСписок:");
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(i + 1 + ") " + list[i].ToString());
        }
    }

    /// <summary>
    /// Класс контроллера с методами расширения
    /// </summary>
    static class Controller
    {
        /// <summary>
        /// Подсчитывает количество испытаний в сессии
        /// </summary>
        /// <param name="session">Объект сессии</param>
        /// <returns>Количество испытаний в сессии</returns>
        public static byte GetCountIspitanie(this Session session)
        {
            // считаем только экзы
            byte Count = 0;
            for (int i = 0; i < session.Count; i++)
                if (session[i] is Examination)
                    Count++;
            return Count;
        }

        /// <summary>
        /// Возвращает количество тестов с заданным числом вопросов.
        /// </summary>
        /// <param name="session">Сессия, в которой подсчитываются тесты.</param>
        /// <param name="count">Количество тестов</param>
        /// <returns>Количество тестов с заданным числом вопросов.</returns>
        public static byte GetCountOfTestsByQuestions(this Session session, byte count)
        {
            byte Count = 0;
            for (int i = 0; i < session.Count; i++)
                if ((session[i] is Test) && ((session[i] as Test).CountOfQuestions == count))
                    Count++;
            return Count;
        }

        public static string SearchExaminationsByName(this Session session, string name)
        {
            byte str = 1;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < session.Count; i++)
                if ((session[i] is Examination) && ((session[i] as Examination).Name == name))
                {
                    result.Append(str + ") " + (session[i] as Examination).ToString());
                    str++;
                }
            return result.ToString();
        }
    }

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
