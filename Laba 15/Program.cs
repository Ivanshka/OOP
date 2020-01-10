using System;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace Laba_15
{
    class Program
    {
        /// <summary>
        /// Проверяет, простое число или нет
        /// </summary>
        /// <param name="N">Число для проверки</param>
        /// <returns></returns>
        private static bool isSimple(int N)
        {
            //чтоб убедится простое число или нет достаточно проверить не делитсья ли 
            //число на числа до его половины
            for (int i = 2; i <= (int)(N / 2); i++)
            {
                if (N % i == 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Вывод простых чисел
        /// </summary>
        static void PrintUsualInt()
        {
            for (int i = 0; i < 1000; i++)
                if (isSimple(i))
                {
                    File.AppendAllLines("out.txt", new string[] { i.ToString() });
                    Console.WriteLine($"Простое число: {i}");
                    Thread.Sleep(1000);
                }
        }

        static void Main()
        {
            Console.WriteLine("Инициализация...");
            if (File.Exists("out.txt"))
            {
                File.Delete("out.txt");
                File.WriteAllText("out.txt", "");
            }

            Console.WriteLine("Запусти с правами администратора и нажми Enter.");
            Console.ReadLine();
            Console.WriteLine("Задание 1\n");
            Console.WriteLine("Список процессов:");
            int i = 0, a = 0;
            foreach (Process p in Process.GetProcesses())
            {
                i++;
                try
                {
                    Console.WriteLine($"{i}. ID: {p.Id}, Name: {p.ProcessName}, Priority: {p.BasePriority}, Time: {p.StartTime}, ProcTime: {p.TotalProcessorTime} IsResp: {p.Responding}");
                }
                catch { a++; Console.WriteLine("Отказано в доступе!"); }
            }
            Console.WriteLine($"Не удалось отобразить {a} процессов! :(\n");

            Console.WriteLine("Для продолжения нажмите Enter...");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Задание 2\n");
            AppDomain CurDomain = AppDomain.CurrentDomain;
            Console.WriteLine($"Домен: {CurDomain.FriendlyName}. ID: {CurDomain.Id}. Сборки:");
            foreach (System.Reflection.Assembly ass in CurDomain.GetAssemblies())
                Console.WriteLine(ass.FullName);

            Console.Write("Создание сборки...");
            CurDomain = AppDomain.CreateDomain("Domain 2");
            try
            {
                CurDomain.Load(new System.Reflection.AssemblyName("GraphCS"));
                Console.WriteLine("ok!");
            }
            catch { Console.WriteLine("не вышло! :("); }

            Console.WriteLine("Выгружаем домен...");
            AppDomain.Unload(CurDomain);

            Console.WriteLine("Для продолжения нажмите Enter...");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("\nЗадание 3\n");
            Thread another = new Thread(PrintUsualInt);
            Console.WriteLine("Запускаю поток. Вы можете управлять его состоянием, нажимая клавиши R (run), P (pause) и S (stop).");
            another.Start();
            Console.WriteLine($"Информация о потоке:\nИмя: {another.Name}\nСтатус: {another.ThreadState}\nПриоритет: {another.Priority}\nID: {another.ManagedThreadId}");
            while (another.ThreadState != System.Threading.ThreadState.Aborted)
            {
                var keyinfo = Console.ReadKey(true);
                switch (keyinfo.Key)
                {
                    case ConsoleKey.R:
                        if (another.ThreadState == System.Threading.ThreadState.WaitSleepJoin || another.ThreadState == System.Threading.ThreadState.Running)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Нельзя возобновить не прерванный поток!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Поток работает!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            another.Resume();
                        }
                        Console.WriteLine($"Статус: {another.ThreadState}");
                        break;
                    case ConsoleKey.P:
                        if (another.ThreadState == System.Threading.ThreadState.Suspended)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Поток и так приостановлен!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Поток приостановлен!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            another.Suspend();
                        }
                        Console.WriteLine($"Статус: {another.ThreadState}");
                        break;
                    case ConsoleKey.S:
                        if (another.ThreadState == System.Threading.ThreadState.Suspended)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Нельзя прерывать приостановленный поток!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Запрос на прерывание потока!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            another.Abort();
                        }
                        Console.WriteLine($"Статус: {another.ThreadState}");
                        break;
                }
            }
            Console.WriteLine("Поток прерван!");

            Console.WriteLine("Для продолжения нажмите Enter...");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("\nЗадание 4а\n"); // без синхронизации

            Thread other = new Thread(WriteEven);
            another = new Thread(WriteOdd);
            other.Priority = ThreadPriority.Highest; // потоку четных чисел

            other.Start();
            another.Start();

            Thread.Sleep(5000);
            other.Abort();
            another.Abort();

            Console.WriteLine("\nДля продолжения нажмите Enter...");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("\nЗадание 4б-1\n"); // сначала все четные, потом все нечетные
            other = new Thread(WriteEven2);
            another = new Thread(WriteOdd2);

            other.Start();
            another.Start();


            Thread.Sleep(3000);
            other.Abort();
            another.Abort();

            Console.WriteLine("\nДля продолжения нажмите Enter...");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("\nЗадание 4б-2\n"); // сначала все четные, потом все нечетные
            other = new Thread(WriteEven3);
            another = new Thread(WriteOdd3);

            other.Start();
            another.Start();

            Thread.Sleep(5000);

            other.Abort();
            another.Abort();

            Console.WriteLine("\nДля продолжения нажмите Enter...");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("\nЗадание 5\n"); // сначала все четные, потом все нечетные

            Console.WriteLine("\nДля продолжения нажмите Enter...");
            Console.ReadLine();

            Console.CursorVisible = false;

            snake[0] = new SnakePart(2, 0);
            snake[1] = new SnakePart(1, 0);
            snake[2] = new SnakePart(0, 0);

            TimerCallback tc = new TimerCallback(Snake);
            Timer timer = new Timer(tc, null, 500, 500);
            ConsoleKeyInfo info = default;
            while (info.Key != ConsoleKey.Escape)
            {
                info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.RightArrow) Dir = 1;
                if (info.Key == ConsoleKey.DownArrow) Dir = 2;
                if (info.Key == ConsoleKey.LeftArrow) Dir = 3;
                if (info.Key == ConsoleKey.UpArrow) Dir = 4;
            }
            
            timer.Dispose();    


            Console.Clear();
            Console.WriteLine("DONE.");
            sw.Close();
            Console.ReadLine();
        }

        struct SnakePart
        {
            public int x;
            public int y;
            public SnakePart(int X, int Y)
            {
                x = X; y = Y;
            }
        }

        static byte Dir = 1;
        static SnakePart[] snake = new SnakePart[3];

        static void Snake(object o)
        {
            Console.Clear();
            
            for (int i = snake.Length - 1; i > 0; i--)
            {
                snake[i].x = snake[i - 1].x;
                snake[i].y = snake[i - 1].y;
            }

            switch (Dir)
            {
                case 1: snake[0].x++; break;
                case 2: snake[0].y++; break;
                case 3: snake[0].x--; break;
                case 4: snake[0].y--; break;
            }

            for (int i = 0; i < snake.Length; i++)
            {
                Console.SetCursorPosition(snake[i].x, snake[i].y);
                Console.Write("o");
            }
        }

        /// <summary>
        /// Пишет четные числа
        /// </summary>
        static void WriteEven()
        {
            int i = 0;
            while (true)
            {
                sw.WriteLine(i);
                Console.WriteLine(i);
                i += 2;
            }
        }

        /// <summary>
        /// Пишет нечетные числа
        /// </summary>
        static void WriteOdd()
        {
            int i = 1;
            while (true)
            {
                sw.WriteLine(i);
                Console.WriteLine(i);
                i += 2;
            }
        }

        /// <summary>
        /// Пишет четные числа. Синхронизирована.
        /// </summary>
        static void WriteEven2()
        {
            lock (locker)
            {
                int i = 0;
                while (i < 1000)
                {
                    sw.WriteLine(i);
                    Console.WriteLine(i);
                    i += 2;
                }
            }
        }

        /// <summary>
        /// Пишет нечетные числа. Синхронизирована.
        /// </summary>
        static void WriteOdd2()
        {
            lock (locker)
            {
                int i = 1;
                while (i < 1000)
                {
                    sw.WriteLine(i);
                    Console.WriteLine(i);
                    i += 2;
                }
            }
        }

        /// <summary>
        /// Пишет четные числа. Синхронизирована иначе.
        /// </summary>
        static void WriteEven3()
        {
            int i = 0;
            while (i < 1000)
            {
                lock (locker)
                {
                    sw.WriteLine(i);
                    Console.WriteLine(i);
                    i += 2;
                    Thread.Sleep(300);
                }
            }
        }

        /// <summary>
        /// Пишет нечетные числа. Синхронизирована иначе.
        /// </summary>
        static void WriteOdd3()
        {
            int i = 1;
            while (i < 1000)
            {
                lock (locker)
                {
                    sw.WriteLine(i);
                    Console.WriteLine(i);
                    i += 2;
                    Thread.Sleep(300);
                }
            }
        }

        /// <summary>
        /// Объект-писатель для задания 4.
        /// </summary>
        static StreamWriter sw = new StreamWriter("ThreadOutput.txt");

        /// <summary>
        /// Заглушка для синхронизации
        /// </summary>
        static object locker = new object();

        /// <summary>
        /// Мьютекс для синхронизации
        /// </summary>
        static Mutex m = new Mutex();
    }
}