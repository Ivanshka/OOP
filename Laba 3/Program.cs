using System;

namespace Laba_3
{
    // вариант 7
    partial class Circle
    {
        // ПОЛЯ
        private int x;
        private int y;
        private double radius;
        public const float PI = 3.14f;
        public static int Counter = 0;
        /// <summary>
        /// Идентификатор окружности.
        /// </summary>
        public readonly int ID;

        // СВОЙСТВА
        public int X { get { return x; } set { if (value >= 0) x = value; else x = 0; } }
        public int Y { get { return y; } set { if (value >= 0) y = value; else y = 0; } }
        public double Radius { get { return radius; } set { if (value >= 0) radius = value; else radius = 0; } }
        /// <summary>
        /// Множитель для ID. Выбирается случайно в статическом конструкторе, чтобы он не был прям вообще бесполезным.
        /// </summary>
        private static int Multiplier;
        /// <summary>
        /// Свойство, ограниченное по set.
        /// </summary>
        public static string Name { get; } = "Окружность";
    }
    
    class Program
    {
        static void Main()
        {
            Console.Title = "Лаба 3";

            Circle c1 = new Circle();
            Circle c2 = new Circle(7, 7);
            Circle c3 = new Circle(5, 5, 3);

            Console.WriteLine($"Координаты объекта c1: ({c1.X}, {c1.Y})");
            Console.WriteLine($"Координаты объекта c2: ({c2.X}, {c2.Y})");
            Console.WriteLine($"Равенство c1 и c2: {c1.Equals(c2)}");
            Console.WriteLine($"Информация о классе: {Circle.ClassInfo()}");
            Console.WriteLine($"Тип объекта c3: {c3.GetType()}");
            Console.WriteLine($"Строковое представление объекта c1: {c1.ToString()}");

            // анонимный тип 
            Console.WriteLine("\nАнонимный тип");
            var anon = new {X = 3, Y = 5, Radius = 3.14f};
            Console.WriteLine($"Объект anon. Информация: X = {anon.X}, Y = {anon.Y}, радиус = {anon.Radius}\n");

            Console.WriteLine("Работа с массивом объектов");

            Circle[] circles = new Circle[5];
            circles[0] = new Circle();
            circles[1] = new Circle();
            circles[2] = new Circle(2, 2, 1);
            circles[3] = new Circle(4, 4, 2);
            circles[4] = new Circle(3, 5, 0.5);

            Console.WriteLine("Общая информация об окружностях:");
            for (int i = 0; i < circles.Length; i++)
            {
                Console.WriteLine(circles[i].ToString());
            }

            // задание А
            // проверка принадлежности точки прямой
            // x - x0    y - y0
            // ------- = -------
            // x1 - x0   y1 - y0

            Console.WriteLine("\nЗадание А - ищем группы окружностей, центры которых лежат на одной прямой.");
            // перебираем все возможные прямые из пяти центров окружностей
            for (int start = 0; start < circles.Length - 1; start++) //точка-начало нашей прямой. она будет сдвигаться. -1, т.к. остановиться надо на предпоследней, иначе начало и конец совпадут
            {
                for (int end = start + 1; end < circles.Length; end++) // точка-конец. тоже будет сдвигаться. +1 по вышеуказанной причине
                {
                    if (circles[start].X != circles[end].X && circles[start].Y != circles[end].Y)
                    {
                        Console.Write($"Группа из окружностей {start} - {end} прямой ({circles[start].X}, {circles[start].Y}) - ({circles[end].X}, {circles[end].Y}): ");
                        for (int check = 0; check < 5; check++) // цикл, в котором будут подставляться в уравнение на проверку все точки, не явл точками начала / конца
                        {
                            if ((check != start) && (check != end))
                            {
                                if ((circles[check].X - circles[start].X) / (circles[end].X - circles[start].X) == (circles[check].Y - circles[start].Y) / (circles[end].Y - circles[start].Y))
                                    Console.Write($"{check}, ");
                            }
                        }
                        Console.WriteLine();
                    }
                    else { Console.WriteLine($"Начало и конец совпадают ({circles[start].X}, {circles[start].Y}) -> пропускаем."); }
                }
            }

            // задание Б - ищем наиб и наим по площади объект
            Console.WriteLine("\nЗадание Б - ищем наибольший и наименьший по площади объект.");
            double pi = Math.PI;
            double minArea = circles[0].GetArea(ref pi), maxArea = 0;

            for (int i = 0; i < 5; i++)
            {
                if (minArea > circles[i].GetArea(ref pi))
                    minArea = circles[i].GetArea(ref pi);
                if (maxArea < circles[i].GetArea(ref pi))
                    maxArea = circles[i].GetArea(ref pi);
            }

            Console.WriteLine($"Минимальная площадь = {minArea}, максимальная = {maxArea}.");

            Console.WriteLine("\nDone.");
            Console.ReadKey();
        }
    }
}

/* ToString()
 * GetHashCode()
 * GetType()
 * Equals()
 * Finalize() (c)
*/