using System;
using System.Reflection;
using System.IO;

namespace Laba_12
{
    public static class Reflector
    {
        static bool firstWrite = true;

        private static void Write(string text)
        {
            if (firstWrite) { File.Delete("info.txt"); firstWrite = !firstWrite; }
            string temp = "";
            try
            {
                temp = File.ReadAllText("info.txt");
                File.WriteAllText("info.txt", text);
            }
            catch { }
            File.WriteAllText("info.txt", temp + '\n' + text);
        }

        public static void WriteClassInfo(string typeName)
        {
            Type temp = Type.GetType(typeName);
            if (temp == null)
            {
                Console.WriteLine($"Тип {typeName} не найден!\n");
                return;
            }
            Write("Название типа и сборки: " + temp.AssemblyQualifiedName);
            Write("Модуль: " + temp.Module.FullyQualifiedName);
            Write("\tБазовый тип: " + temp.BaseType.FullName);
            Write("\tЗначимый: " + temp.IsValueType);

            Write("\nПолей: " + temp.GetFields().Length);
            foreach (FieldInfo f in temp.GetFields())
                Write(f.Name + "\n\tтип: " + f.FieldType.FullName + "\n\tpublic: " + f.IsPublic + "\n\tstatic: " + f.IsStatic);

            Write("\nКонструкторов: " + temp.GetConstructors().Length);
            foreach (ConstructorInfo c in temp.GetConstructors())
                Write(c.Name + "\tpublic: " + c.IsPublic + "\tstatic: " + c.IsStatic + "\tпараметров: " + c.GetParameters().Length);

            Write("\nСвойств: " + temp.GetProperties().Length);
            foreach (PropertyInfo p in temp.GetProperties())
                Write(p.Name + "\n\tчтение: " + p.CanRead + "\tзапись: " + p.CanWrite);

            Write("\nМетодов: " + temp.GetMethods().Length);
            foreach (MethodInfo m in temp.GetMethods())
                Write(m.Name + ", параметров: " + m.GetParameters().Length.ToString());
        }

        public static void GetMethods(string typeName)
        {
            Type temp = Type.GetType(typeName);
            if (temp == null)
            {
                Console.WriteLine($"Невозможно получить методы: тип {typeName} не найден!\n");
                return;
            }
            Console.WriteLine("\nМетодов: " + temp.GetMethods().Length);
            foreach (MethodInfo m in temp.GetMethods())
                Console.WriteLine(m.Name + ", параметров: " + m.GetParameters().Length.ToString());
        }

        public static void GetPropertiesAndFields(string typeName)
        {
            Type temp = Type.GetType(typeName);
            if (temp == null)
            {
                Console.WriteLine($"Невозможно получить свойства и поля: тип {typeName} не найден!\n");
                return;
            }
            Console.WriteLine("\nПолей: " + temp.GetFields().Length);
            foreach (FieldInfo f in temp.GetFields())
                Console.WriteLine(f.Name + ", тип: " + f.FieldType.FullName + ", public: " + f.IsPublic + ", static: " + f.IsStatic);

            Console.WriteLine("\nСвойства: " + temp.GetProperties().Length);
            foreach (PropertyInfo p in temp.GetProperties())
                Console.WriteLine(p.Name + ", чтение: " + p.CanRead + ", запись: " + p.CanWrite);
        }

        public static void GetInterfaces(string typeName)
        {
            Type temp = Type.GetType(typeName);
            if (temp == null)
            {
                Console.WriteLine($"Невозможно получить интерфейсы: тип {typeName} не найден!\n");
                return;
            }
            Console.WriteLine("\nИнтерфейсов: " + temp.GetInterfaces().Length);
            foreach (Type f in temp.GetInterfaces())
                Console.WriteLine(f.Name);
        }

        public static void GetMethodsByParam(string typeName)
        {
            int i = 0;
            Type temp = Type.GetType(typeName);
            if (temp == null)
            {
                Console.WriteLine($"Невозможно получить методы: тип {typeName} не найден!\n");
                return;
            }
            foreach (MethodInfo m in temp.GetMethods())
                if (CheckOnInt(m.GetParameters()))
                { Console.WriteLine(m.Name + ", параметров: " + m.GetParameters().Length.ToString()); i++; }
            Console.WriteLine("Всего таких методов: " + i);
        }

        private static bool CheckOnInt(ParameterInfo[] pi)
        {
            foreach (ParameterInfo p in pi)
                if (p.ParameterType == typeof(int))
                    return true;
            return false;
        }

        public static void CallFunction(string typeName, string method)
        {
            Type temp = Type.GetType(typeName);
            if (temp == null)
            {
                Console.WriteLine($"Невозможно вызвать метод: тип {typeName} не найден!\n");
                return;
            }
            MethodInfo mi = temp.GetMethod(method, new Type[] { typeof(string) });//method.GetMethod()
            if (mi == null)
            {
                Console.WriteLine($"Невозможно вызвать метод, т.к. указанный метод ({method}) не найден не найден!\n");
                return;
            }
            mi.Invoke(null, new object[] { File.ReadAllLines("info.txt")[2] });
        }

    }
}
