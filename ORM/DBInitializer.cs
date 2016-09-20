using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
//using System.Web.Helpers;

namespace ORM
{
    public class DBInitializer : CreateDatabaseIfNotExists<TasksManagerModel>
    {
        protected override void Seed(TasksManagerModel context)
        {
            Role user = new Role {Name = "User"};
            Role admin = new Role {Name = "Admin"};
            context.Roles.Add(user);
            context.Roles.Add(admin);

            User administrator = new User {Name = "Admin", Email = "ignatiklesha@gmail.com",
                Roles = {user, admin}, Password = "qwerty"}; //Crypto.HashPassword("qwerty") };
            context.Users.Add(administrator);
            Task first = new Task()
            {
                Name = "Hard",
                Checked = false,
                RecipientId = 2,
                SenderId = 3,
                CreationDate = DateTime.Now,
                Id = 1,
                Description = "Very hard task"
            };
            context.Tasks.Add(first);
            context.SaveChanges();
        }
    }
}
