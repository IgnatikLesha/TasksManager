using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces;
using DAL.Interfaces;


namespace BLL.Services
{
    class RoleService : IRoleService
    {

        private readonly IUnitOfWork unit;
        private readonly IRoleRepository roleRepository;
        public void Create(RoleEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(RoleEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(RoleEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleEntity> GetAllByPredicate(Expression<Func<RoleEntity, bool>> predicates)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleEntity> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public RoleEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public RoleEntity GetByPredicate(Expression<Func<RoleEntity, bool>> predicates)
        {
            throw new NotImplementedException();
        }
    }
}
