using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            User administrator = new User {Name = "Admin", Email = "ignatiklesha@gmail.com", Roles = {user, admin}};
            context.Users.Add(administrator);
            context.SaveChanges();
        }
    }
}
