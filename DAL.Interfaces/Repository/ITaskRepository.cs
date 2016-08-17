using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;

namespace DAL.Interfaces
{
    public interface ITaskRepository
    {
        void Create(DalTask entity);

        void Delete(DalTask entity);

        void Update(DalTask entity);

        int CreateTask(DalTask entity);

        IEnumerable<DalTask> GetAll();

        DalTask GetById(int key);

        DalTask GetByPredicate(Expression<Func<DalTask, bool>> predicate);

        IEnumerable<DalTask> GetAllByPredicate(Expression<Func<DalTask, bool>> predicate);


    }
}
