using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Entities;
using DAL.DTO;
using ORM;
using Task = System.Threading.Tasks.Task;

namespace BLL.Mappers
{
    public static class TaskMapper
    {
        public static ORM.Task GetORMEntity(this DalTask dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new ORM.Task()
            {
                Id = dalEntity.Id,
                Checked = dalEntity.Checked,
                SenderId = dalEntity.SenderId,
                RecipientId = dalEntity.RecipientId,
                DateCreation = dalEntity.CreationDate,
                Name = dalEntity.Name,
                Description = dalEntity.Description,
                User = dalEntity.User.GetORMEntity(),
                User1 = dalEntity.User1.GetORMEntity()
            };
        }

        public static DalTask GetDalEntity(this ORM.Task ormEntity)
        {
            return new DalTask()
            {
                Id = ormEntity.Id,
                Checked = ormEntity.Checked,
                SenderId = ormEntity.SenderId,
                RecipientId = ormEntity.RecipientId,
                CreationDate = ormEntity.DateCreation,
                Name = ormEntity.Name,
                Description = ormEntity.Description,
                User = ormEntity.User.GetDalEntity(),
                User1 = ormEntity.User1.GetDalEntity()
            };
        }
    }
}
