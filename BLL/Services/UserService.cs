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
    public class UserService : IUserService
    {
        public void Create(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAllByPredicate(Expression<Func<UserEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public UserEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserEntity GetByPredicate(Expression<Func<UserEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
