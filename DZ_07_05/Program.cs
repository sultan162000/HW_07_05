using DZ_07_05.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DZ_07_05
{
    class Program
    {
        public static async Task Method()
        {
            Console.WriteLine("Вы Админ");
            bool checkUser = true;
            while (checkUser)
            {
                Console.Clear();
                UserContext db = new UserContext();
                Console.WriteLine("1.Посмотреть всех пользователей\n2.Добавить пользователя\n3.Удалить пользователя\n4.Выход");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        if (db.Users.ToList().Count == 0)
                        {
                            Console.WriteLine("Список пользователей пусть!");
                            break;
                        }
                        var u = await db.Users.ToListAsync();
                        Console.WriteLine("Список пользователей: ");
                        foreach (var item in u)
                        {
                            Console.WriteLine($"ID: {item.Id} Login: {item.Login} Password: {item.Password}");
                        }

                        break;
                    case 2:
                        Console.Write("Введите логин: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите пароль: ");
                        string pass = Console.ReadLine();
                        User newUser = new User() { Login = name, Password = pass };
                        db.Users.Add(newUser);
                        await db.SaveChangesAsync();
                        break;
                    case 3:
                        Console.Write("Введите логин для удаление: ");
                        string lod = Console.ReadLine();
                        if (db.Users.FirstOrDefault(p => p.Login == lod) != null)
                        {
                            var us = db.Users.FirstOrDefault(p => p.Login == lod);
                            db.Users.Remove(us);
                            await db.SaveChangesAsync();
                            Console.WriteLine("Ползовател удален!");

                        }

                        break;
                    case 4:
                        checkUser = false;
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Подождите...");
            Task t = Method();
            t.Wait();
        }
    }
}
