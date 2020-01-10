using System;
using System.Linq;
using System.Text;

namespace Laba_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "2-я лаба";

            // ТИПЫ
            Console.WriteLine("1) ТИПЫ");

            // a.Определите переменные всех возможных примитивных типов
            // С#  и проинициализируйте их

            // bool: хранит значение true или false (логические литералы). Представлен системным типом System.Boolean
            bool alive = true;
            // byte: хранит целое число от 0 до 255 и занимает 1 байт. Представлен системным типом System.Byte
            byte bit = 102;
            // sbyte: хранит целое число от -128 до 127 и занимает 1 байт. Представлен системным типом System.SByte
            sbyte bit1 = -101;
            // short: хранит целое число от -32768 до 32767 и занимает 2 байта. Представлен системным типом System.Int16
            short n2 = 102;
            // ushort: хранит целое число от 0 до 65535 и занимает 2 байта. Представлен системным типом System.UInt16
            ushort n1 = 1;
            // int: хранит целое число от -2147483648 до 2147483647 и занимает 4 байта. Представлен системным типом System.Int32.
            // Все целочисленные литералы по умолчанию представляют значения типа int:
            int a = 10;
            int b = 0b101;  // бинарная форма b = 5
            int c = 0xFF;   // шестнадцатеричная форма c = 255
            // uint: хранит целое число от 0 до 4294967295 и занимает 4 байта. Представлен системным типом System.UInt32
            uint d = 10;
            // long: хранит целое число от –9 223 372 036 854 775 808 до 9 223 372 036 854 775 807 и занимает 8 байт. Представлен системным типом System.Int64
            long e = -10;
            // ulong: хранит целое число от 0 до 18 446 744 073 709 551 615 и занимает 8 байт. Представлен системным типом System.UInt64
            ulong f = 10;
            // float: хранит число с плавающей точкой от -3.4 * 1038 до 3.4 * 1038 и занимает 4 байта. Представлен системным типом System.Single
            float g = 3.14f;
            // double: хранит число с плавающей точкой от ±5.0 * 10 - 324 до ±1.7 * 10308 и занимает 8 байта. Представлен системным типом System.Double
            double h = 6.28;
            // decimal: хранит десятичное дробное число. Если употребляется без десятичной запятой, имеет значение от ±1.0 * 10 - 28 до ±7.9228 * 1028, может хранить 28 знаков после запятой и занимает 16 байт. Представлен системным типом System.Decimal
            decimal i = 10.15m;
            // char: хранит одиночный символ в кодировке Unicode и занимает 2 байта.Представлен системным типом System.Char.Этому типу соответствуют символьные литералы:
            char j = 'J';
            char k = '\x5A';
            char l = '\u0420';
            // string: хранит набор символов Unicode. Представлен системным типом System.String. Этому типу соответствуют символьные литералы.
            string hello = "Hello, World!";
            // object: может хранить значение любого типа данных и занимает 4 байта на 32 - разрядной платформе и 8 байт на 64 - разрядной платформе.Представлен системным типом System.Object, который является базовым для всех других типов и классов.NET.
            object m = 22;
            object n = 3.14;
            object o = "hello code";

            // b.  Выполните 5 операций явного и 5 неявного приведения. 
            char ch = (char)a;
            decimal dec = (decimal)h;
            float fl = (float)h;
            bit = (byte)c;
            int chislo = (int)m;

            e = a; // long <= int
            m = j; // object <= char
            h = g; // double <= float
            f = d; // ulong <= uint
            n1 = bit; // ushort <= byte

            // с.  Упковка-распаковка значимых типов
            o = j; // boxing, упаковка
            j = (char)o; // unboxing, распаковка

            // d.  неявная типизация
            var unlight = new int[] { 1, 2, 3 };
            Console.WriteLine("Длина массива: " + unlight.Length);

            // e.  nullable-переменная
            byte? nullable = 0;
            if (nullable.HasValue)
                Console.WriteLine("nullable имеет значение: " + nullable);

            nullable = null;
            if (!nullable.HasValue)
                Console.WriteLine("nullable не имеет значения");

            // СТРОКИ
            Console.WriteLine("\n2) СТРОКИ");

            // a.  строковые литералы и их сравнение
            string lit1 = "literal 1";
            string lit2 = "literal 2";

            if (lit1 == lit2)
                Console.WriteLine("Литералы равны");
            else
                Console.WriteLine("Литералы не равны");

            // b. строки на основе String и действия над ними
            char[] cstr1 = { 'Э', 'т', 'о', ' ', 'п', 'е', 'р', 'в', 'а', 'я', ' ', 'с', 'т', 'р', 'о', 'к', 'а', '.' };
            char[] cstr2 = { 'Э', 'т', 'о', ' ', 'в', 'т', 'о', 'р', 'а', 'я', ' ', 'с', 'т', 'р', 'о', 'к', 'а', '.' };
            char[] cstr3 = { 'Э', 'т', 'о', ' ', 'т', 'р', 'е', 'т', 'ь', 'я', ' ', 'с', 'т', 'р', 'о', 'к', 'а', '.' };
            String str1 = new String(cstr1);
            String str2 = new String(cstr2);
            String str3 = new String(cstr3);
            
            // сцепление
            string str4 = str1 + str2 + str3;
            Console.WriteLine("Итоге сцепления: " + str4);
            
            // копирование
            str1.CopyTo(0, cstr1, 10, 8);
            Console.WriteLine("Итог копирования: " + cstr1);
            
            // выделение подстроки
            str1 = str1.Substring(2);
            Console.WriteLine("Выделил подстроку: " + str1);
            
            // разделение строки на слова
            string[] words = str4.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // чтобы удалить пустые подстроки
            Console.Write("Слова в str4: ");
            foreach (string w in words)
            {
                Console.Write("\t" + w);
            }
            Console.WriteLine('\n');
            //вставка подстроки в заданную позицию
            string sub = " Oh My GOOOOOD!";
            str4 = str4.Insert(10, sub);
            Console.WriteLine("После вставки подстроки:" + str4);

            //удаление заданной подстроки
            int ind = str4.IndexOf(sub);
            int ind2 = str4.LastIndexOf("!");
            str4 = str4.Remove(ind, ind2 - ind + 2); // (позиция, кол-во)
            Console.WriteLine("После удаления подстроки: " + str4);
            
            // c. пустая и null-строка

            if ("qwerty" == string.Empty)
                Console.WriteLine("\"qwerty\" - пустая строка");
            else
                Console.WriteLine("\"qwerty\" - не пустая строка");

            string b1 = null;
            Console.WriteLine("Вывод null-строки:" + b1);


            // d. строка на основе stringbuilder
            StringBuilder a1 = new StringBuilder("Большая и жирная строка");
            Console.WriteLine("Длина строки: " + a1.Length);
            Console.WriteLine("Текущая емкость: " + a1.Capacity);
            a1.Append("321");
            a1.Insert(0, "123");
            Console.WriteLine(a1);
            a1.Remove(0, 3);
            a1.Remove(a1.Length-3, 3);
            Console.WriteLine(a1);

            // МАССИВЫ
            Console.WriteLine("\n3) МАССИВЫ");
            // a. матрица
            int[,] m2 = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
            int rows = m2.GetUpperBound(0) + 1; // кол-во строк таблицы
            int columns = m2.Length / rows; //кол-во элементов в каждой строке
            Console.WriteLine("Строк: " + rows + ", столбцов: " + columns);
            
            for (int i2 = 0; i < rows; i++)
            {
                for (int j2 = 0; j < columns; j++)
                {
                    Console.Write($"{m2[i2, j2]} \t");
                }
                Console.WriteLine();
            }
            
            // b. одномерный массив строк
            string[] st2 = { "Ko ", "no", "su", "ba!" };
            Console.Write("Длина массива:" + st2.Length + ". Массив содержит: ");
            foreach (string w in st2)
            {
                Console.Write("\t" + w);
            }
            Console.WriteLine();
            Console.WriteLine("Изменение массива. Введите позицию от 1 до 4:");
            byte pos = (byte)(Convert.ToByte(Console.ReadLine()) - 1);
            string input = Console.ReadLine();
            st2[pos] = input;
            Console.WriteLine("Массив сейчас: ");
            foreach (string w in st2)
            {
                Console.Write("\t" + w);
            }
            Console.WriteLine();

            // c. ступенчатый массив
            Console.WriteLine("Введите элементы ступенчатого массива:");
            float[][] nums = new float[3][]; // первая - размер главного массива, вторая всегда пуста
            nums[0] = new float[2];
            nums[1] = new float[3];
            nums[2] = new float[4];

            for (int row = 0; row < nums.Length; row++)
                for (int col = 0; col < nums[row].Length; col++)
                    nums[row][col] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Матрица:");
            foreach (float[] row in nums)
            {
                foreach (float num in row)
                {
                    Console.Write($"{num} \t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            
            // d. неявно типизированный массив и строка

            var arr1 = new[] { 1, 2, 3 };
            Console.WriteLine("Тип переменной: " + arr1.GetType());

            var s = "One";
            Console.WriteLine("Тип переменной: " + s.GetType());
            
            // КОРТЕЖИ
            Console.WriteLine("\n4) КОРТЕЖИ");
            // a-b. именованный кортеж
            (int, string, char, string, ulong) kort = (num1: 1, str1: "123", str2: '1', str3: "321", num2: 1);
            
            // с. вывод кортежа
            Console.WriteLine("1-й элемент кортежа: " + kort.Item1);
            Console.WriteLine("Весь кортеж:" + kort);

            // d. распаковка кортежа
            var (num1, string1, string2, string3, num2) = kort;
            (int, string, char, ulong) c3 = (10, "можно", 'x', 100);
            
            (double su, var o2, var p) = (34, 'r', "qwerty and ytrewq");
            
            // e. сравнение кортежей
            var rrr = ("Oh", "yeah!");
            Console.WriteLine("Кортежи равны: " + (("Oh", "yeah!") == rrr));
            
            (int, int, int, char) localFunc(int[] mas, string str)
            {
                return (mas.Max(), mas.Min(), mas.Sum(), str[0]);
            }
            Console.WriteLine("Результат работы локальной функции\n" + localFunc(new int[]{ 1, 2, 3, 4 }, "string").ToString());

            string aaa = "asdasd";
            string bbb = "dsfdghet";
            Console.WriteLine(aaa.CompareTo(bbb));

            Console.ReadLine();
        }
    }
}
