using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.Interfaces;

namespace DAL.Concrete
{
    public class TaskRepository : ITaskRepository
    {
        public void Create(DalTask entity)
        {
            throw new NotImplementedException();
        }

        public int CreateTask(DalTask entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalTask entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalTask> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalTask> GetAllByPredicate(Expression<Func<DalTask, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public DalTask GetById(int key)
        {
            throw new NotImplementedException();
        }

        public DalTask GetByPredicate(Expression<Func<DalTask, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(DalTask entity)
        {
            throw new NotImplementedException();
        }
    }
}
