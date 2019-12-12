using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_13
{
    public static class PISDirInfo
    {
        public static void GetCountOfFiles(string path)
        {
            PISLog.Log($"Получение количества файлов...", path);
            Console.WriteLine($"Получение количества файлов... | {path}");
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                PISLog.Log($"Файлов в каталоге: {di.GetFiles().Length}");
                Console.WriteLine($"Файлов в каталоге: {di.GetFiles().Length}");
            }
            {
                PISLog.Log("Каталог не найден!");
                Console.WriteLine("Каталог не найден!");
            }
        }

        public static void GetCreateTime(string path)
        {
            PISLog.Log("Получение даты создания каталога...", path);
            Console.WriteLine($"Получение даты создания каталога... | {path}");
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                PISLog.Log($"Дата создания: {di.CreationTime}");
                Console.WriteLine($"Дата создания: {di.CreationTime}");
            }
            else
            {
                PISLog.Log($"Каталог не найден!");
                Console.WriteLine($"Каталог не найден!");
            }
        }

        public static void GetCountOfSubfolders(string path)
        {
            PISLog.Log($"Получение количества подкаталогов...", path);
            Console.WriteLine($"Получение количества подкаталогов... | {path}");
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                PISLog.Log($"Подкаталогов: {di.GetDirectories().Length}");
                Console.WriteLine($"Подкаталогов: {di.GetDirectories().Length}");
            }
            else
            {
                PISLog.Log("Каталог не найден!");
                Console.WriteLine("Каталог не найден!");
            }
        }

        public static void GetFullPath(string path)
        {
            PISLog.Log($"Получение пути...", path);
            Console.WriteLine($"Получение пути... | {path}");
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                PISLog.Log($"Родительский каталог: {di.Parent.FullName}");
                Console.WriteLine($"Родительский каталог: {di.Parent.FullName}");
            }
            else
            {
                PISLog.Log("Каталог не найден!");
                Console.WriteLine("Каталог не найден!");
            }
        }
    }
}
