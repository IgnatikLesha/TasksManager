using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace ConsoleDBTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TasksManagerModel())
            {
                var user = new Role
                {
                    Name = "User"
                };
                var admin = new Role
                {
                    Name = "Admin"
                };
                db.Roles.Add(user);
                db.Roles.Add(admin);
                db.SaveChanges();
                User user1 = new User()
                {
                    Name = "John", Password = "qwerty",
                    Email = "qwerty@gmail.com",
                    Roles = { user, admin }
                };
                db.SaveChanges();

                foreach (var item in db.Users)
                {
                    if (item.Id == 2)
                    {
                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Email);
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
