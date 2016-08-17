using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface ITaskService
    {
        void Create(TaskEntity entity);

        void Delete(TaskEntity entity);

        void Edit(TaskEntity entity);

        int CreateTask(TaskEntity taskEntity);  //! ! ! 

        void MarkAsChecked(TaskEntity taskEntity);

        IEnumerable<TaskEntity> GetAllEntities();

        TaskEntity GetById(int id);

        TaskEntity GetByPredicate(Expression<Func<TaskEntity, bool>> predicate);

        IEnumerable<TaskEntity> GetAllByPredicate(Expression<Func<TaskEntity, bool>> predicate);




    }
}
