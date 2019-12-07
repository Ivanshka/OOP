using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_11
{
    class Circle
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

        // КОНСТРУКТОРЫ

        /// <summary>
        /// Статический конструктор класса. Инициализирует множитель хэша.
        /// </summary>
        static Circle()
        {
            Multiplier = 3;
        }

        /// <summary>
        /// Приватный конструктор. Инициализирует окружность с координатами (0; 0) и указанным радиусом.
        /// </summary>
        /// <param name="r">Радиус окружности.</param>
        private Circle(double r)
        {
            X = 0; Y = 0; Radius = r;
            ID = GetHashCode();
            Counter++;
        }

        /// <summary>
        /// Инициализирует окружность с координатами и радиусом, равными 1.
        /// </summary>
        public Circle()
        {
            X = 1; Y = 1; Radius = 1;
            ID = GetHashCode();
            Counter++;
        }

        /// <summary>
        /// Инициализирует окружность с заданными координатами и радиусом.
        /// </summary>
        /// <param name="x">Координата по оси X.</param>
        /// <param name="y">Координата по оси Y.</param>
        /// <param name="r">Радиус окружности.</param>
        public Circle(int x, int y, double r)
        {
            X = x; Y = y; Radius = r;
            ID = GetHashCode();
            Counter++;
        }

        /// <summary>
        /// Инициализирует окружность радиусом 1 с координатами (1; 1), если они не были заданы.
        /// </summary>
        /// <param name="x">Координата по оси X.</param>
        /// <param name="y">Координата по оси Y.</param>
        public Circle(int x = 1, int y = 1)
        {
            X = x; Y = y; Radius = 1;
            ID = GetHashCode();
            Counter++;
        }

        // МЕТОДЫ

        /// <summary>
        /// Недохэш-функция для ID.
        /// </summary>
        /// <returns>Хэш.</returns>
        public override int GetHashCode() { return (int)(X * Y * Multiplier + Radius); }
        /// <summary>
        /// Выдает координаты и радиус окружности.
        /// </summary>
        /// <returns>Общая информация об окружности</returns>
        public override string ToString() { return "Координаты: X = " + X + ", Y = " + Y + ", радиус = " + Radius; }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Circle c = obj as Circle; // оператор as возвращает null если объект нельзя привести к типу Circle
            if (c as Circle == null)
                return false;
            return c.X == X && c.Y == Y && c.Radius == Radius; // X == this.X, и т.д.
        }
        public double GetArea() { return Math.PI * Radius * Radius; }
        public double GetLength() { return 2 * Math.PI * Radius; }
        /// <summary>
        /// Возвращает прощадь, а через out-пераметр length - длину окружности
        /// </summary>
        /// <returns></returns>
        public double GetInfo(out double length) { length = 2 * Math.PI * Radius; return Math.PI * Radius * Radius; }
        public static string ClassInfo() { return "Класс для работы с окружностями."; }
    }
}
