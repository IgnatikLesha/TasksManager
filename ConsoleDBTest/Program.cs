using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using Task = ORM.Task;

namespace ConsoleDBTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TasksManagerModel())
            {
            //    Task first = new Task()
            //    {
            //        Name = "Hard",
            //        Checked = false,
            //        RecipientId = 2,
            //        SenderId = 3,
            //        CreationDate = DateTime.Now,
            //        Id = 1,
            //        Description = "Very hard task"
            //    };
            //    db.Tasks.Add(first);
            //    db.SaveChanges();



                foreach (var item in db.Roles)
                {

                    Console.WriteLine(item.Name);

                }

                foreach (var item in db.Users)
                {

                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Email);

                }

                foreach (var item in db.Tasks)
                {

                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Description);

                }
                Console.ReadLine();
            }
        }
    }
}
