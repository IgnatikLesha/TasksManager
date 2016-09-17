using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.Interfaces;
using DAL.Mappers;
using Helpers;
using Task = ORM.Task;

namespace DAL.Concrete
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DbContext context;

        public TaskRepository(DbContext uow)
        {
            if (uow == null)
            {
                throw new ArgumentNullException("entitiesContext");
            }
            this.context = uow;
        }

        public void Create(DalTask dalTask)
        {
            context.Set<ORM.Task>().Add(dalTask.GetORMEntity());
        }


        public int CreateTask(DalTask dalTask)
        {
            context.Set<ORM.Task>().Add(dalTask.GetORMEntity());
            return context.Set<ORM.Task>().Max(t => t.Id) + 1;
        }

        public void Delete(DalTask dalTask)
        {
            context.Set<ORM.Task>().Attach(dalTask.GetORMEntity());
            context.Set<ORM.Task>().Remove(dalTask.GetORMEntity());
        }

        public void Update(DalTask dalTask)
        {
            context.Set<ORM.Task>().AddOrUpdate(dalTask.GetORMEntity());
            context.SaveChanges();
        }

        public IEnumerable<DalTask> GetAll()
        {
            var tasks = context.Set<Task>().ToList();
            return tasks.Select(task => task.GetDalEntity());
        }

        public DalTask GetById(int key)
        {
            var task = context.Set<ORM.Task>().FirstOrDefault(f => f.Id == key);
            return task == null ? null : task.GetDalEntity();
        }

        public DalTask GetByPredicate(Expression<Func<DalTask, bool>> f)
        {
            return GetAllByPredicate(f).FirstOrDefault();
        }

        public IEnumerable<DalTask> GetAllByPredicate(Expression<Func<DalTask, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<DalTask, ORM.Task>(Expression.Parameter(typeof(ORM.Task), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<ORM.Task, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            var tasks = context.Set<ORM.Task>().Where(exp2).ToList();
            return tasks.Select(task => task.GetDalEntity());
        }


    }
}
