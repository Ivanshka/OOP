using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Laba_13
{
    class Program
    {
        /// <summary>
        /// Подготовка к запуску: удаление временных файлов с прошлого запуска (кроме главного лога), если такие остались
        /// </summary>
        static void Initiaization()
        {
            if (Directory.Exists("archiveFiles")) Directory.Delete("archiveFiles", true);
            if (Directory.Exists("PISFiles")) Directory.Delete("PISFiles", true);
            if (Directory.Exists("PISInspect")) Directory.Delete("PISInspect", true);
            if (File.Exists("archive.zip")) File.Delete("archive.zip");
        }

        static void Main()
        {
            // ПОДГОТОВКА К РАБОТЕ: УДАЛЕНИЕ ФАЙЛОВ С ПРОШЛОГО ЗАПУСКА !!!
            Console.Write("Инициализация...");
            Initiaization();
            Console.WriteLine("ок.");

            PISDriveInfo.GetFileSystem("D");
            Console.WriteLine();
            PISDriveInfo.GetFreeSpace("H");
            Console.WriteLine();
            PISDriveInfo.GetInfoAboutDisks();
            Console.WriteLine();
            
            PISFileInfo.GetFullPath("pislogfile.txt");
            Console.WriteLine();
            PISFileInfo.GetFileInfo("pislogfile.txt");
            Console.WriteLine();
            PISFileInfo.GetCreatingTime("pislogfile.txt");
            Console.WriteLine();

            PISDirInfo.GetCountOfFiles("D:\\Файлы пользователя\\Рабочий стол\\ООП\\OOP\\Dick Figures");
            Console.WriteLine();
            PISDirInfo.GetCountOfSubfolders("D:\\Файлы пользователя\\Рабочий стол\\ООП\\OOP\\Dick Figures");
            Console.WriteLine();
            PISDirInfo.GetCreateTime("D:\\Файлы пользователя\\Рабочий стол\\ООП\\OOP\\Dick Figures");
            Console.WriteLine();
            PISDirInfo.GetFullPath("D:\\Файлы пользователя\\Рабочий стол\\ООП\\OOP\\Dick Figures");
            Console.WriteLine();

            // задание а
            PISFileManager.GetFolderBody("G");
            Console.WriteLine();

            if (File.Exists("PISInspect\\DriveInfo.txt"))
                File.Delete("PISInspect\\DriveInfo.txt");

            File.Copy("PISInspect\\pisdirinfo.txt", "PISInspect\\DriveInfo.txt");
            PISLog.Log("Скопирован файл", "из PISInspect\\pisdirinfo.txt в PISInspect\\DriveInfo.txt");
            Console.WriteLine("Скопирован файл из PISInspect\\pisdirinfo.txt в PISInspect\\DriveInfo.txt");
            Console.WriteLine();

            File.Delete("PISInspect\\pisdirinfo.txt");
            PISLog.Log("Удален файл PISInspect\\pisdirinfo.txt");
            Console.WriteLine("Удален файл PISInspect\\pisdirinfo.txt");
            Console.WriteLine();
            // б

            var di = Directory.CreateDirectory("PISFiles");
            Console.WriteLine("Создан каталог: " + di.FullName);
            PISLog.Log("Создан каталог ", di.FullName);
            Console.WriteLine();

            DirectoryInfo di2 = new DirectoryInfo("D:\\Файлы пользователя\\Рабочий стол\\КСиС");
            foreach (FileInfo a in di2.GetFiles())
                if (a.Extension == ".txt")
                {
                    if (File.Exists("PISFiles\\" + a.Name))
                        File.Delete("PISFiles\\" + a.Name);
                    File.Copy(a.FullName, "PISFiles\\" + a.Name);
                    PISLog.Log("Скопирован файл", $"из {a.FullName} в PISInspect\\{a.Name}");
                    Console.WriteLine($"Скопирован файл из {a.FullName} в PISInspect\\{a.Name}");
                }
            Console.WriteLine();
            
            Directory.Move("PISFiles", "PISInspect\\PISFiles");
            Console.WriteLine("Перемещен каталог PISFiles -> PISInspect\\PISFiles");
            PISLog.Log("Перемещен каталог", "PISFiles -> PISInspect\\PISFiles");
            Console.WriteLine();

            ZipFile.CreateFromDirectory("PISInspect\\PISFiles", "archive.zip");
            Console.WriteLine("Архивация файлов папки PISInspect\\PISFiles...");
            PISLog.Log("Архивация файлов папки", "PISInspect\\PISFiles");
            Console.WriteLine();

            Directory.CreateDirectory("archiveFiles");
            Console.WriteLine("Создан каталог archiveFiles");
            PISLog.Log("Создан каталог", "archiveFiles");
            Console.WriteLine();

            ZipFile.ExtractToDirectory("archive.zip", "archiveFiles");
            Console.WriteLine("Распаковка архива archive.zip в каталог archiveFiles...");
            PISLog.Log("Распаковка архива", "archive.zip -> archiveFiles");
            Console.WriteLine();

            //Console.Clear();
            Console.WriteLine("Обработка лог-файла.\nЧтение файла...");
            StringBuilder log = new StringBuilder(File.ReadAllText("pislogfile.txt"));

            Console.WriteLine("\nВывод отчета за 08.12.2019");

            log.Remove(0, log.ToString().IndexOf("НОВЫЙ ЗАПУСК: 08.12.2019"));
            int deleteEnd = log.ToString().IndexOf("НОВЫЙ ЗАПУСК");
            Console.WriteLine("Первая точка: " + deleteEnd);
            deleteEnd = log.ToString().IndexOf("НОВЫЙ ЗАПУСК", deleteEnd+1);
            Console.WriteLine("Вторая точка: " + deleteEnd);
            Console.WriteLine("Длина строки: " + log.Length);
            log.Remove(deleteEnd,log.Length - deleteEnd);

            Console.WriteLine(log);

            Console.WriteLine("Вывод лога за последний час...");
            log = new StringBuilder(File.ReadAllText("pislogfile.txt"));
            Console.WriteLine("Текущий час: " + DateTime.Now.TimeOfDay.Hours.ToString());

            // delete part
            string day, month, h;
            if (DateTime.Now.Day < 10)
                day = "0" + DateTime.Now.Day;
            else
                day = DateTime.Now.Day.ToString();
            if (DateTime.Now.Month < 10)
                month = "0" + DateTime.Now.Month;
            else
                month = DateTime.Now.Month.ToString();
            if (DateTime.Now.Hour < 10)
                h = "0" + DateTime.Now.Hour;
            else
                h = DateTime.Now.Hour.ToString();

            deleteEnd = log.ToString().IndexOf($"НОВЫЙ ЗАПУСК: {day}.{month}.{DateTime.Now.Date.Year} {h}");

            // НЕ ПЕРЕПИСЫВАЕМ САМ ФАЙЛ, ЧТОБЫ НЕ ТЕРЯТЬ ДАННЫЕ !
            Console.WriteLine("Символов для удаления: " + deleteEnd + ", полный размер: " + log.Length);
            log.Remove(0, deleteEnd-1);
            Console.WriteLine(log);


            Console.Write("\nDONE.");
            Console.ReadLine();
        }
    }
}
