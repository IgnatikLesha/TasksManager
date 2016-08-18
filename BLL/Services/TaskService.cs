using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces;

namespace BLL.Services
{
    public class TaskService : ITaskService
    {
        public void Create(TaskEntity entity)
        {
            throw new NotImplementedException();
        }

        public int CreateTask(TaskEntity taskEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TaskEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(TaskEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskEntity> GetAllByPredicate(Expression<Func<TaskEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskEntity> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public TaskEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TaskEntity GetByPredicate(Expression<Func<TaskEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void MarkAsChecked(TaskEntity taskEntity)
        {
            throw new NotImplementedException();
        }
    }
}
