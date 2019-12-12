using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_13
{
    static class PISFileManager
    {
        static StreamWriter sw;
        /// <summary>
        /// Выводит на экран список файлов и папок заданного диска
        /// </summary>
        public static void GetFolderBody(string diskName)
        {
            Directory.CreateDirectory("PISInspect");
            sw = new StreamWriter("PISInspect\\pisdirinfo.txt");
            PISLog.Log($"Попытка вывода файлов и папок диска {diskName}...");
            Console.WriteLine($"Попытка вывода файлов и папок диска {diskName}...");
            DriveInfo di = new DriveInfo(diskName);
            try
            {
                WriteFolder(di.RootDirectory.FullName, 0);
            }
            catch
            {
                PISLog.Log($"Диск {diskName} не найден!");
                Console.WriteLine($"Диск {diskName} не найден!");
                return;
            }
            sw.Close();
            Console.ForegroundColor = ConsoleColor.Gray;
            PISLog.Log("Обход окончен!");
            Console.WriteLine("Обход окончен!");
        }

        /// <summary>
        /// Вывод содержимого папки
        /// </summary>
        /// <param name="path">путь к папке</param>
        /// <param name="level">уровень вложенности относительно корня</param>
        static void WriteFolder(string path, int level)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            ConsoleColor color;

            StringBuilder spaceLevel = new StringBuilder();
            for (int i = 0; i < level; i++)
                spaceLevel.Append("  ");

            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (DirectoryInfo di2 in di.GetDirectories())
            {
                try
                {
                    Console.WriteLine($"{spaceLevel.ToString()}+| {di2.Name}");
                    sw.WriteLine($"{spaceLevel.ToString()}+| {di2.Name}");
                    WriteFolder(di2.FullName, level + 1);
                }
                catch
                {
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{spaceLevel.ToString()}   ERROR: Отказано в доступе!");
                    sw.WriteLine($"{spaceLevel.ToString()}   ERROR: Отказано в доступе!");
                    Console.ForegroundColor = color;
                }
            }

            color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (FileInfo fi in di.GetFiles())
            {
                Console.WriteLine($"{spaceLevel.ToString()}-| {fi.Name}");
                sw.WriteLine($"{spaceLevel.ToString()}-| {fi.Name}");
            }
            Console.ForegroundColor = color;
        }
    }
}