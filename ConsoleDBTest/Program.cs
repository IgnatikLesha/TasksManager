using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ORM;
using System.Web.Helpers;
using Task = ORM.Task;

namespace ConsoleDBTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TasksManagerModel())
            {
                //Role user = new Role { Name = "User" };
                //Role admin = new Role { Name = "Admin" };
                //db.Roles.Add(user);
                //db.Roles.Add(admin);
                //db.SaveChanges();
                //User administrator = new User
                //{
                //    Name = "Admin",
                //    Email = "ignatiklesha@gmail.com",
                //    Roles = { user, admin },
                //    //Password = Crypto.HashPassword("qwerty")
                //    Password = "qwerty"
                //};
                //db.Users.Add(administrator);
                //db.SaveChanges();

                //Task first = new Task()
                //{
                //    Name = "Hard",
                //    Checked = false,
                //    RecipientId = 2,
                //    SenderId = 3,
                //    CreationDate = DateTime.Now,
                //    Id = 1,
                //    Description = "Very hard task"
                //};
                //db.Tasks.Add(first);
                //db.SaveChanges();

                //Task first = new Task()
                //{
                //    Name = "Hard",
                //    Checked = false,
                //    RecipientId = 2,
                //    SenderId = 3,
                //    CreationDate = DateTime.Now,
                //    Id = 1,
                //    Description = "Very hard task"
                //};
                //db.Tasks.Add(first);
                //db.SaveChanges();

                //User try1 = new User()
                //{
                //    Name = "qwertyzxc",
                //    Email = "qwertyzxc@gmail.com",
                //    Password = "qwerty",
                //    Tasks = new List<Task>()
                //};
                //db.Users.Add(try1);
                //db.SaveChanges();

                //User try2 = new User()
                //{
                //    Name = "bbbbbbb",
                //    Email = "bbbbbbb@gmail.com",
                //    Password = "qwerty",
                //    Tasks = new List<Task>(),
                //    Id = 0
                //};
                //db.Users.Add(try2);
                //db.SaveChanges();

                //User try4 = new User()
                //{
                //    Name = "aaaaaaa",
                //    Email = "aaaaaaa@gmail.com",
                //    Password = Crypto.HashPassword("qwerty"),
                //    Tasks = new List<Task>(),
                //    Id = 0
                //};
                //db.Users.Add(try4);
                //db.SaveChanges();

                foreach (var item in db.Roles)
                {

                    Console.WriteLine(item.Name);
                    Console.WriteLine("---------------------");

                }

                foreach (var item in db.Users)
                {       
                        Console.WriteLine(item.Id);
                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Email);
                        Console.WriteLine("------------");

                }

                foreach (var item in db.Tasks)
                {

                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Description);
                    Console.WriteLine("------------");
                }
                Console.ReadLine();
            }
        }
    }
}
