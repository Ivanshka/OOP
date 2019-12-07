using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Laba_5; // подключаем 5-ю лабу

namespace Laba_8
{
    

    /// <summary>
    /// Интерфейс для работы с обобщеными типами
    /// </summary>
    /// <typeparam name="T">Тип для работы</typeparam>
    interface IOperations<T>
    {
        /// <summary>
        /// Операция добавления
        /// </summary>
        void Add(T item, bool exc);
        /// <summary>
        /// Операция удаления
        /// </summary>
        void Remove(T item, bool exc);
        /// <summary>
        /// Операция вывода
        /// </summary>
        void Show(bool exc);
    }

    /// <summary>
    /// Класс лабного исключения
    /// </summary>
    public class LabaException : Exception
    {
        public LabaException() { }
        public LabaException(string message) : base(message) { }
        public LabaException(string message, Exception inner) : base(message, inner) { }
        protected LabaException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Класс для лабы 1
    /// </summary>
    /// <typeparam name="T">Класс, экземпляры которого будут использоваться в коллекии</typeparam>
    class CollectionType<T> : IOperations<T> where T : class
    {
        List<T> collection;

        public CollectionType()
        {
            collection = new List<T>();
        }

        public void Add(T item, bool exc = false)
        {
            if (exc)
                collection.Add(item);
            else throw new LabaException("Hi, I'm LabaException!");
        }

        public void Remove(T item, bool exc = false)
        {
            if (exc)
                collection.Remove(item);
            else throw new LabaException("Hi, I'm LabaException!");
        }

        public void Show(bool exc = false)
        {
            if (exc)
                Console.WriteLine(collection);
            else throw new LabaException("Hi, I'm LabaException!");
        }
    }

    /// <summary>
    /// Класс для лабы 2
    /// </summary>
    /// <typeparam name="T">Класс, экземпляры которого будут использоваться в коллекии</typeparam>
    [Serializable]
    class CollectionType2<T> : IOperations<T>
    {
        List<T> collection;

        public CollectionType2()
        {
            collection = new List<T>();
        }

        /// <summary>
        /// Добавляет элемент в коллекцию
        /// </summary>
        /// <param name="item">Элемент для добавления</param>
        /// <param name="exc">Управляет выдачей исключения. При false вылетит с исключением.</param>
        public void Add(T item, bool exc = true)
        {
            if (exc)
                collection.Add(item);
            else throw new LabaException("Hi, I'm LabaException!");
        }

        /// <summary>
        /// Удаляем элемент из коллекции
        /// </summary>
        /// <param name="item">Элемент для удаления</param>
        /// <param name="exc">Управляет выдачей исключения. При false вылетит с исключением.</param>
        public void Remove(T item, bool exc = true)
        {
            if (exc)
                collection.Remove(item);
            else throw new LabaException("Hi, I'm LabaException!");
        }

        /// <summary>
        /// Выводит коллекцию на экран
        /// </summary>
        /// <param name="exc">Управляет выдачей исключения. При false вылетит с исключением.</param>
        public void Show(bool exc = true)
        {
            if (exc)
            {
                for (int i = 0; i < collection.Count; i++)
                    Console.WriteLine(collection[i].ToString());
            }
            else throw new LabaException("Hi, I'm LabaException!");
        }
        /*
        /// <summary>
        /// Сохранить коллекцию в файл
        /// </summary>
        public void Save()
        {
            byte[] array = Byte.ObjectToByteArray(this);
            FileStream fs = new FileStream("base.bin", FileMode.Create);
            for (int i = 0; i < collection.Count; i++)
                fs.Write(array, 0, array.Length);
        }

        /// <summary>
        /// Загрузить коллекцию из файла
        /// </summary>
        /// <param name="path">Пусть к файлу</param>
        public void Load(string path)
        {
            FileStream fs = new FileStream("base.bin", FileMode.Open);

            for (int i = 0; i < collection.Count; i++)
                fs.
        }*/
    }

    /*
    /// <summary>
    /// Класс для работы с массивом байт
    /// </summary>
    static class Byte
    {
        /// <summary>
        /// Конвертирует объект в массив байт
        /// </summary>
        /// <param name="obj">Объект для конвертации</param>
        /// <returns>Массив байт</returns>
        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        // Convert a byte array to an Object
        public static Object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
    }*/

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Обобщенный класс с ограничением:");
            CollectionType<Test> type = new CollectionType<Test>();
            try
            {
                string[] questions = { "Что такое парсек?", "Где находится Черная дыра?", "Газовые гиганты Солнечной системы?", "Созвездие в виде буквы W?", "Звезда, переливающаяся зеленым, желтым и синим цветами?" };
                string[] answers = { "Единица измерения расстояния, равная расстоянию до объекта. :D ", "В центре галактики", "Юпитер, Сатурн, Уран, Нептун", "Кассиопея", "Капелла" };
                Test test = new Test("Астрономия", "8:30", questions, answers);
                type.Add(test, false);
            }
            catch(LabaException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.WriteLine("Hello, I'm FINALLY!!!!!!!!!!!!");
            }

            Console.WriteLine("\n\nОбобщенный класс со стандартным типом данных:");

            CollectionType2<int> type2 = new CollectionType2<int>();
            try
            {
                type2.Add(1, false);
            }
            catch (LabaException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.WriteLine("Hello, I'm FINALLY!!!!!!!!!!!!");
            }

            Console.WriteLine("\nВывод коллекции:");
            type2.Add(123);
            type2.Show();

            Console.WriteLine("\nDone.");
            Console.ReadKey();
        }
    }
}
