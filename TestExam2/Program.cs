using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

/*
№ 2-6
1. Создать класс User с закрытыми полями email и password, status (может содержать значения signin или signout).
2. Переопределить в классе все стандартного public методы Object. Перегрузить метод CompareTo стандартного
унаследованного интерфейса IComparable, который сравнивает пользователей по email. Создать пять пользователей и
сравнить их.
3. Создать класс WebNet, который содержит LinkedList<> всех пользователей с методами добавления и удаления.
Создайте объект github и добавьте в список всех пользователей.
4. Используя LINQ посчитайте сколько пользователей зашли на ресурс.
5. Сериализуйте этих пользователей в любом формате.
*/

namespace TestExam2
{
    enum State { signin, signout }

    [DataContract]
    class User: IComparable
    {
        [DataMember]
        string email;
        [DataMember]
        string password;
        public State status;

        public int CompareTo(object obj)
        {
            if (!(obj is User))
                return -1;
            User temp = (User)obj;
            return email.CompareTo(temp.email);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is User))
                return false;
            User temp = (User)obj;
            if (email == temp.email)
                if (password == temp.password)
                    return true;
            return false;
        }
        public override int GetHashCode()
        {
            return email.Length*password.Length;
        }
        public override string ToString()
        {
            return $"Email: {email}, status: {status}";
        }

        public User(string email, string password, State state)
        {
            this.email = email; this.password = password; status = state;
        }
    }

    [DataContract]
    class WebNet
    {
        [DataMember]
        public LinkedList<User> users;
        
        public WebNet()
        {
            users = new LinkedList<User>();
        }

        public void Add (User user) => users.AddFirst(user);
        public void Remove (User user) => users.Remove(user);
    }

    class Program
    {
        static void Main()
        {
            User user1 = new User("a", "a", State.signin);
            User user2 = new User("a", "a", State.signout);
            User user3 = new User("a", "c", State.signin);
            User user4 = new User("c", "c", State.signout);
            User user5 = new User("e", "e", State.signin);

            Console.Write($"Сравниваем пользователей 1 и 2 через Equals: {user1.Equals(user2)}\n");
            Console.Write($"Сравниваем пользователей 1 и 2 через ==: {user1 == user2}\n");
            Console.Write($"Сравниваем пользователей 3 и 4 через Equals: {user3.Equals(user4)}\n");
            Console.Write($"Сравниваем пользователей 3 и 4 через ==: {user3 == user4}\n");
            Console.Write($"Сравниваем пользователей 1 и 2 через Equals: {user5.Equals(user5)}\n");
            Console.Write($"Сравниваем пользователей 5 и 1 через ==: {user5 == user1}\n");

            WebNet github = new WebNet();
            github.Add(user1);
            github.Add(user2);
            github.Add(user3);
            github.Add(user4);
            github.Add(user5);

            int count = (from u in github.users
                         where u.status == State.signin
                         select u).Count();
            Console.WriteLine($"Пользователей на сайте: {count}.\nСериализация...");
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(WebNet));
            using (FileStream fs = new FileStream("data.json", FileMode.OpenOrCreate))
            {
                serializer.WriteObject(fs, github);
            }

            System.Diagnostics.Process.Start("data.json");
            Console.ReadKey();
        }
    }
}
