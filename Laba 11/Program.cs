using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Ссылки:
 * https://metanit.com/sharp/tutorial/15.1.php
 */

namespace Laba_11
{
    class Program
    {
        /*...
        public static bool Check()
        {
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
        }*/

        static void Main()
        {
            Console.WriteLine("\nЗадание 1\n");
            string[] months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            int n = 5; // длина слова для запроса
            var byLength = from s in months
                           where s.Length == n
                           select s;

            var byMonth = from s in months
                          where s == "June" || s == "Jule" || s == "August" || s == "December" || s == "January" || s == "February"
                          select s;

            var byAlphabet = from s in months
                             orderby s
                             select s;

            var by = from s in months
                     where s.Contains('u') && s.Length >= 4
                     select s;

            Console.WriteLine("Результат 1-й запроса по длине слова:");
            foreach (string s in byLength)
                Console.WriteLine(s);

            Console.WriteLine("\nРезультат 2-го запроса по месяцам:");
            foreach (string s in byMonth)
                Console.WriteLine(s);

            Console.WriteLine("\nРезультат 3-го запроса: вывод в алфавитном порядке:");
            foreach (string s in byAlphabet)
                Console.WriteLine(s);

            Console.WriteLine("\nРезультат 4-го запроса по длине слова и наличию символа:");
            foreach (string s in by)
                Console.WriteLine(s);

            Console.WriteLine("\nЗадание 2-3\n");

            List<Circle> l = new List<Circle>
            {
                new Circle(),
                new Circle(),
                new Circle(2, 2, 1),
                new Circle(4, 4, 2),
                new Circle(3, 5, 0.5)
            };

            Console.WriteLine($"Окружности с радиусом, равным 1: {(from c in l where c.Radius == 1 select c).Count()}");

            Console.WriteLine($"Упорядоченный список окружностей по площади:");
            (from c in l.AsParallel() orderby c.GetArea() select c).ForAll((a) => Console.WriteLine(a));

            Console.WriteLine($"Окружность с наименьшей площадью: {l.OrderBy(a => a.GetArea()).First()}");
            Console.WriteLine($"Окружность с наибольшей площадью: {l.OrderByDescending(a => a.GetArea()).First()}");
            Console.WriteLine($"Окружность в 1-й четверти: { (from c in l where (c.X > 0 && c.Y > 0) select c).First()}");

            Console.WriteLine("\nЗадание 4\n");

            var answer = months.Where((s) => s.Contains('a')).Take(5).Select(s => s.Contains('u')).Where(s => true).Count();
            Console.WriteLine(answer);

            Console.WriteLine("\nЗадание 5\n");

            List<Game> games = new List<Game>()
            {
                new Game { Name = "Prime World", Developer ="Nival" },
                new Game { Name = "WarCraft", Developer ="Blizzard Entertainment" }
            };
            List<Player> players = new List<Player>()
            {
                new Player {Name="Виталя", Game="Prime World"},
                new Player {Name="Лера", Game="WarCraft"},
                new Player {Name="Валера", Game="Prime World"}
            };

            var result = from pl in players
                         join g in games on pl.Game equals g.Name
                         select new { Name = pl.Name, Game = pl.Game, Developer = g.Developer };

            foreach (var info in result)
            {
                Console.WriteLine($"{info.Name} - {info.Game} ({info.Developer})");
            }

            Console.ReadLine();
        }

        class Player
        {
            public string Name { get; set; }
            public string Game { get; set; }
        }
        class Game
        {
            public string Name { get; set; }
            public string Developer { get; set; }
        }
    }
}
