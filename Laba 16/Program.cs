using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laba_16
{
    class Program
    {
        /// <summary>
        /// Пишет одну строку заданным цветов и переходит на следующую строку, вернув исходный цвет написания
        /// </summary>
        /// <param name="str">строка</param>
        /// <param name="c">цвет</param>
        public static void ColorWriteLine(object str, ConsoleColor c)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = c;
            Console.WriteLine(str);
            Console.ForegroundColor = color;
        }

        /// <summary>
        /// Перемножение матриц
        /// </summary>
        /// <param name="a">1-я матрица</param>
        /// <param name="b">2-я матрица</param>
        /// <returns>Произведение матриц</returns>
        public static int[,] Multiplication(int[,] a, int[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить!");
            int[,] r = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }

        public static int[,] PMultiplication(int[,] a, int[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить!");
            int[,] r = new int[a.GetLength(0), b.GetLength(1)];
            Parallel.For(0, b.GetLength(1), (i) =>
            {
                //for (int i = 0; i < a.GetLength(0); i++)
                //{
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    //Parallel.For(0, b.GetLength(0), (k) => r[i, j] += a[i, k] * b[k, j]);
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            });
            return r;
        }

        static int[,] A = new int[100, 100];
        static int[,] B = new int[100, 100];

        static void Main()
        {
            Console.WriteLine("Задание 1-2, 5");
            Task task1 = new Task(() =>
            {
                Console.WriteLine("Рандомим матрицы...");
                Random rand = new Random();
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        A[i, j] = rand.Next();
                        B[i, j] = rand.Next();
                    }
                }
                Stopwatch watch = new Stopwatch();
                Console.WriteLine("Перемножаем последовательно...");
                watch.Start();
                int[,] C = Multiplication(A, B);
                watch.Stop();
                Console.WriteLine($"Время последовательного вычисления: {watch.Elapsed}");
                watch.Reset();
                watch.Start();
                int[,] C2 = PMultiplication(A, B);
                watch.Stop();
                Console.WriteLine($"Время параллельного вычисления: {watch.Elapsed}");
            });
            task1.Start();

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            Task task2 = new Task(() =>
            {
                Console.WriteLine($"Задача {task1.Id}");
                Console.WriteLine("Рандомим матрицы...");
                Random rand = new Random();
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        A[i, j] = rand.Next();
                        B[i, j] = rand.Next();
                    }
                }
                Stopwatch watch = new Stopwatch();
                Console.WriteLine("Перемножаем последовательно...");
                watch.Start();
                int[,] C = Multiplication(A, B);
                watch.Stop();
                Console.WriteLine($"Время последовательного вычисления: {watch.Elapsed}");
                watch.Reset();
                watch.Start();
                int[,] C2 = PMultiplication(A, B);
                watch.Stop();
                Console.WriteLine($"Время параллельного вычисления: {watch.Elapsed}");
            }, tokenSource.Token);
            task2.Start();

            //Thread.Sleep(10);
            tokenSource.Cancel();
            Console.WriteLine("Запрос на отмену отправлен!");
            task1.Wait();

            Console.WriteLine("Для продолжения нажмите Enter...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\nЗадание 3");

            Task<int>[] taskI = new Task<int>[3] { new Task<int>(() => (int)Math.PI), new Task<int>(() => (int)Math.E * 2), new Task<int>(() => (int)Math.PI * 3) };
            foreach (Task t in taskI)
                t.Start();

            Task<int> taskI2 = new Task<int>(() => (taskI[0].Result + taskI[0].Result + taskI[0].Result) / 2);
            taskI2.Start();
            Console.WriteLine($"Результат выражения: {taskI2.Result}");

            Console.WriteLine("Для продолжения нажмите Enter...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\nЗадание 4");

            Task task4 = new Task(() => Console.WriteLine("Задача)"));
            Task task5 = task4.ContinueWith((parTask) => Console.WriteLine("Продолжение задачи)"));
            task4.Start();

            Task<int> what = Task.Run(() => Enumerable.Range(1, 100000).Count(n => (n % 2 == 0)));
            // получаем объект продолжения
            var awaiter = what.GetAwaiter();
            // что делать после окончания предшественника
            awaiter.OnCompleted(() =>
            {
                int res = awaiter.GetResult();
                Console.WriteLine("Нечетных чисел: " + res);
            });

            Console.WriteLine("Для продолжения нажмите Enter...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\nЗадание 6");

            Parallel.Invoke(new Action[] { new Action(() => Console.WriteLine("1")), new Action(() => Console.WriteLine("2")), new Action(() => Console.WriteLine("3")), new Action(() => Console.WriteLine("4")), new Action(() => Console.WriteLine("5")) });

            Console.WriteLine("Для продолжения нажмите Enter...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\nЗадание 7");

            OnChange = () =>
            {
                foreach (var i in blockingCollection)
                {
                    Console.WriteLine("Количество продукции: " + i);
                }
            };

            blockingCollection = new BlockingCollection<int>(5);
            CancellationTokenSource Cancel = new CancellationTokenSource();
            Task[] pr = new Task[5];
            Task[] Cons = new Task[10];
            for (int i = 0; i < 5; i++)
            {
                pr[i] = new Task(Producer, Cancel.Token);
                pr[i].Start();
            }
            for (int i = 0; i < 10; i++)
            {
                Cons[i] = new Task(Consumer, Cancel.Token);
                Cons[i].Start();
            }

            Thread.Sleep(5000);

            // вырубаем шарманку
            Cancel.Cancel();
            Working = false;
            Thread.Sleep(3000);

            ColorWriteLine("!!! ЗАПРОС НА ОТМЕНУ !!!", ConsoleColor.Red);

            Console.WriteLine("Для продолжения нажмите Enter...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Задание 8\nПодождите завершения асинхронного вычисления факториала...");
            FactorialAsync();   // вызов асинхронного метода

            /* Console.Beep(350, 1050);
            Thread.Sleep(500);
            Console.Beep(350, 1050);
            Thread.Sleep(500);
            Console.Beep(350, 1050); */

            Console.WriteLine("DONE.");
            Console.ReadLine();
        }

        /// <summary>
        /// Флаг работы дял методов задач 7-го задания
        /// </summary>
        static bool Working = true;

        public static void Producer()
        {
            if (!Working) return;
            mod++;
            for (int i = 3 * (mod); i < 4 * mod; i++)
            {
                Thread.Sleep(100 * mod);
                blockingCollection.Add(i);
                Console.WriteLine("Добавлен продукт: " + i);
                OnChange();
            }
        }

        public static void Consumer()
        {
            mod++;
            int i;
            while (!blockingCollection.IsCompleted)
            {
                Thread.Sleep(75 * mod / 2);
                if (blockingCollection.TryTake(out i))
                {
                    Console.WriteLine("Продан продукт: " + i);
                    OnChange();
                }
                else
                {
                    Console.WriteLine("Пусто!");
                }
                if (!Working) break;
            }
        }

        static BlockingCollection<int> blockingCollection = new BlockingCollection<int>(5);

        delegate void ChangeCollection();

        static event ChangeCollection OnChange;

        static int mod = 1;

        static int x = 0;

        static void Factorial()
        {
            int result = 1;
            for (int i = 1; i <= 6; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Факториал равен {result}");
        }

        // определение асинхронного метода
        static async void FactorialAsync()
        {
            Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
            await Task.Run(() => Factorial());                // выполняется асинхронно
            Console.WriteLine("Конец метода FactorialAsync");
        }
    }
}
