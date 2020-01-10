using System;
using System.IO;

namespace Laba_13
{
    static class PISDriveInfo
    {
        public static void GetFreeSpace(string diskName)
        {
            PISLog.Log($"Попытка узнать свободное место на диске: {diskName}");
            Console.WriteLine($"Попытка узнать свободное место на диске: {diskName}");
            DriveInfo di = new DriveInfo(diskName);
            try
            {
                PISLog.Log($"Свободно: {di.TotalFreeSpace / (1024 * 1024)} МБ");
                Console.WriteLine($"Свободно: {di.TotalFreeSpace / (1024 * 1024)} МБ");
            }
            catch
            {
                PISLog.Log($"Диск {diskName} не найден!");
                Console.WriteLine($"Диск {diskName} не найден!");
            }
        }

        public static void GetFileSystem(string diskName)
        {
            PISLog.Log($"Попытка узнать файловую систему диска: {diskName}");
            Console.WriteLine($"Попытка узнать файловую систему диска: {diskName}");
            DriveInfo di = new DriveInfo(diskName);
            try
            {
                PISLog.Log($"ФС установлена: {di.DriveFormat}");
                Console.WriteLine($"ФС установлена: {di.DriveFormat}");
            }
            catch
            {
                PISLog.Log("Не удалось распознать ФС!");
                Console.WriteLine("Не удалось распознать ФС!");
            }
        }

        public static void GetInfoAboutDisks()
        {
            PISLog.Log($"Получаем информацию о дисках...");
            Console.WriteLine($"Получаем информацию о дисках...");
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                PISLog.Log($"Имя: {di.Name}, объем: {di.TotalSize}, доступно: {di.TotalFreeSpace}, метка: {di.VolumeLabel}");
                Console.WriteLine($"Имя: {di.Name}, объем: {di.TotalSize}, доступно: {di.TotalFreeSpace}, метка: {di.VolumeLabel}");
            }
        }
    }
}
