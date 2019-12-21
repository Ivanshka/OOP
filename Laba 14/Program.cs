using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Laba_14
{
    class Program
    {
        /// <summary>
        /// Метод бинарной серилизации
        /// </summary>
        /// <param name="exam">Объект класса Examination для серилизации</param>
        static void BinSer(ref Examination exam)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("exam.bin", FileMode.Create))
                formatter.Serialize(fs, exam);
        }
        /// <summary>
        /// Метод SOAP-серилизации
        /// </summary>
        /// <param name="exam">Объект класса Examination для серилизации</param>
        static void SoapSer(ref Examination exam)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs = new FileStream("examSoap.xml", FileMode.Create))
                formatter.Serialize(fs, exam);
        }

        /// <summary>
        /// Метод Json-серилизации
        /// </summary>
        /// <param name="exam">Объект класса Examination для серилизации</param>
        static void JsonSer(ref Examination exam)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Examination));
            using (FileStream fs = new FileStream("exam.json", FileMode.Create))
                js.WriteObject(fs, exam);
        }

        /// <summary>
        /// Метод XML-серилизации
        /// </summary>
        /// <param name="exam">Объект класса Examination для серилизации</param>
        static void XmlSer(ref Examination exam)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Examination));
            using (FileStream fs = new FileStream("examXml.xml", FileMode.Create))
                xs.Serialize(fs, exam);
        }

        // * * * * * * * * * * * * * * * *

        /// <summary>
        /// Метод бинарной десерилизации
        /// </summary>
        /// <param name="exam">Объект класса Examination для серилизации</param>
        static Examination BinDeser()
        {
            object result;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("exam.bin", FileMode.Open))
                result = formatter.Deserialize(fs);
            return result as Examination;
        }
        /// <summary>
        /// Метод SOAP-серилизации
        /// </summary>
        /// <param name="exam">Объект класса Examination для серилизации</param>
        static Examination SoapDeser()
        {
            object result;
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs = new FileStream("examSoap.xml", FileMode.Open))
                result = formatter.Deserialize(fs);
            return result as Examination;
        }

        /// <summary>
        /// Метод Json-серилизации
        /// </summary>
        /// <param name="exam">Объект класса Examination для серилизации</param>
        static Examination JsonDeser()
        {
            object result;
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Examination));
            using (FileStream fs = new FileStream("exam.json", FileMode.Open))
                result = js.ReadObject(fs);
            return result as Examination;
        }

        /// <summary>
        /// Метод XML-серилизации
        /// </summary>
        /// <param name="exam">Объект класса Examination для серилизации</param>
        static Examination XmlDeser()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Examination));
            object result;
            using (FileStream fs = new FileStream("examXml.xml", FileMode.Open))
                result = xs.Deserialize(fs);
            return result as Examination;
        }

        static void Main()
        {
            Console.WriteLine("Задание 1");
            Console.Write("Сериализация...");
            
            Examination exam = new Examination("Вышмат", "8:00", "Как зовут препода?", "Асмыкович Иван Кузьмич", "На сдачу какого предмета ты пришел?", "Высшая математика");
            BinSer(ref exam);
            SoapSer(ref exam);
            JsonSer(ref exam);
            XmlSer(ref exam);

            Console.WriteLine("ок.");
            Console.WriteLine("Десериализация...");

            exam = BinDeser();
            Console.WriteLine($"Объект после бинарной десерилизации: {exam}");
            exam = SoapDeser();
            Console.WriteLine($"Объект после SOAP-десерилизации: {exam}");
            exam = JsonDeser();
            Console.WriteLine($"Объект после JSON-десерилизации: {exam}");
            exam = XmlDeser();
            Console.WriteLine($"Объект после XML-десерилизации: {exam}");

            Console.WriteLine("Задание 2");

            Examination[] arr = new Examination[3];
            arr[0] = new Examination("Вышмат", "8:00", "Как зовут препода?", "Асмыкович Иван Кузьмич", "На сдачу какого предмета ты пришел?", "Высшая математика");
            arr[1] = new Examination("ООП", "8:00", "Как зовут препода?", "Задорожный Никита Павлович", "Что такое микрофон?", "Да/Нет");
            arr[2] = new Examination("КСиС", "8:00", "Как зовут препода?", "Романенко", "Зачем ты пришел?", "Шобы отчислицца");


            XmlSerializer xs = new XmlSerializer(typeof(Examination[]));
            using (FileStream fs = new FileStream("xpath.xml", FileMode.Create))
                xs.Serialize(fs, arr);

            using (FileStream fs = new FileStream("xpath.xml", FileMode.Open))
                arr = (Examination[])xs.Deserialize(fs);

            foreach (Examination a in arr)
                Console.WriteLine(a);

            Console.WriteLine("Задание 3: XPath to XML");
            Console.WriteLine("\nЗапрос 1");
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("xpath.xml");
            
            XmlNodeList answers = xDoc.SelectNodes("//Examination");
            foreach (XmlNode a in answers)
            {
                Console.WriteLine(a.InnerText);
            }
            Console.WriteLine("\nЗапрос 2");
            answers = xDoc.SelectNodes("//Examination//Name");
            foreach (XmlNode a in answers)
            {
                Console.WriteLine(a.InnerText);
            }

            Console.WriteLine("\n\nЗадание 4: LINQ to XML");

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Examination));

            // очистка для "чистой" записи
            if (File.Exists("out.json"))
            {
                File.Delete("out.json");
                File.WriteAllText("out.json", "");
            }

            XDocument xdoc = XDocument.Load("xpath.xml");
            foreach (XElement ex in xdoc.Element("ArrayOfExamination").Elements("Examination"))
            {
                XElement one = ex.Element("one");
                XElement two = ex.Element("two");
                string name = ex.Element("Name").Value;
                string time = ex.Element("Time").Value;
                Console.WriteLine($"Экзамен: {name}");
                Console.WriteLine($"Время: {time}");
                Console.WriteLine($"Вопрос 1: {one.Element("Text").Value}, ответ: {one.Element("Answer").Value}");
                Console.WriteLine($"Вопрос 2: {two.Element("Text").Value}, ответ: {two.Element("Answer").Value}");
                Console.WriteLine();

                Examination obj = new Examination(name, time, one.Element("Text").Value, one.Element("Answer").Value, two.Element("Text").Value, two.Element("Answer").Value);
                FileStream fs = new FileStream("out.json", FileMode.Append);
                js.WriteObject(fs, obj);
                fs.Close();
            }

            Console.WriteLine("DONE.");
            Console.ReadLine();
        }
    }
}
