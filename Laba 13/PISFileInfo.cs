using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_13
{
    public static class PISFileInfo
    {
        public static void GetFullPath(string fileName)
        {
            PISLog.Log("Получение полного пути к файлу...", fileName);
            Console.WriteLine($"Получение полного пути к файлу... | {fileName}");
            if (File.Exists(fileName))
            {
                FileInfo fi = new FileInfo(fileName);
                PISLog.Log($"Путь: {fi.FullName}");
                Console.WriteLine($"Путь: {fi.FullName}");
            }
            else
            {
                PISLog.Log($"Файл не найден!");
                Console.WriteLine($"Файл не найден!");
            }
        }

        public static void GetFileInfo(string fileName)
        {
            PISLog.Log("Получение информации о файле.", fileName);
            Console.WriteLine($"Получение информации о файле... | {fileName}");
            if (File.Exists(fileName))
            {
                FileInfo fi = new FileInfo(fileName);
                PISLog.Log($"Имя: {fi.Name}, расширение: {fi.Extension}, размер: {fi.Length} байт");
                Console.WriteLine($"Имя: {fi.Name}, расширение: {fi.Extension}, размер: {fi.Length} байт");
            }
            else
            {
                PISLog.Log($"Файл не найден!");
                Console.WriteLine($"Файл не найден!");
            }
        }

        public static void GetCreatingTime(string fileName)
        {
            PISLog.Log("Получение даты создания файла...", fileName);
            Console.WriteLine($"Получение даты создания файла... | {fileName}");
            if (File.Exists(fileName))
            {
                FileInfo fi = new FileInfo(fileName);
                PISLog.Log($"Дата создания: {fi.CreationTime}");
                Console.WriteLine($"Дата создания: {fi.CreationTime}");
            }
            else
            {
                PISLog.Log($"Файл не найден!");
                Console.WriteLine($"Файл не найден!");
            }
        }
    }
}
