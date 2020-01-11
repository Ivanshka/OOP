using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

/*
1. Создайте интерфейс Figure с виртуальным методом print. Создать класс Rectangle с
координатами x, y, длиной и шириной h, l и color (строка) цветом и реализацией
интерфейса. Метод print должен выводить прямоугольник на консоль.
2. Класс должен содержать: конструктор без параметров и с тремя, пятью
параметрами (используйте делигирование конструкторов), переопределите метода
ToString, оператор + int (добавление к ширине и высоте целого числа), метод
вычисления площади.
3. Создайте коллекцию List<> из 6 прямоугольников. Продемонстрируйте работу
оператора + и метода print.
4. Используя LINQ отсортируйте ее по x, а затем по y, затем по площади, возьмите
первый и последний объекты и выведите их.
5. Сериализуйте коллекцию в формате Json, координаты x, y — сделайте не сериализуемыми.
*/
namespace TestExam
{
    interface Figure
    {
        void print();
    }

    [DataContract]
    class Rectangle : Figure
    {
        //int x, y, w, h;

        [DataMember]
        public string Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        [DataMember]
        public int W { get; set; }
        [DataMember]
        public int H { get; set; }

        public void print()
        {
            Console.WriteLine("Я тип прямоугольник на консоли)");
        }

        public Rectangle() { X = Y = W = H = 0; Color = "Black"; }
        public Rectangle(int x, int y, string color) { X = x; Y = y; Color = color; }
        public Rectangle(int x, int y, string color, int w, int h):this(x, y, color) { W = w; H = h; }

        public override string ToString() { return $"X: {X}, Y: {Y}, W: {W}, H: {H}, Color: {Color}"; }

        public static Rectangle operator +(Rectangle r, int a) { r.H += a; r.W += a; return r; }

        public int GetArea() { return W * H; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            List<Rectangle> list = new List<Rectangle>();
            Console.WriteLine("Список");
            for (int i = 0; i < 6; i++)
            {
                list.Add(new Rectangle(r.Next(), r.Next(), "Black", r.Next(), r.Next()));
                Console.WriteLine(list[i]);
            }
            var sort = from l in list
                       orderby l.X, l.Y, l.GetArea()
                       select l;

            Console.WriteLine("Первый и последний");
            Console.WriteLine(sort.First());
            Console.WriteLine(sort.Last());

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Rectangle>));
            using (FileStream fs = new FileStream("data.json", FileMode.OpenOrCreate))
            {
                serializer.WriteObject(fs, list);
            }

            System.Diagnostics.Process.Start("data.json");
            Console.WriteLine("Сериализовано!");
            Console.ReadKey();
        }
    }
}
