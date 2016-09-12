using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork uow;

        private readonly ITaskRepository taskRepository;

        public TaskService(IUnitOfWork uow, ITaskRepository taskRepository)
        {
            this.uow = uow;
            this.taskRepository = taskRepository;
        }

        public void Create(TaskEntity entity)
        {                    
            entity.Checked = false;
            entity.CreationDate = DateTime.Now;
            taskRepository.Create(entity.GetDalEntity());
            uow.Commit();
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
