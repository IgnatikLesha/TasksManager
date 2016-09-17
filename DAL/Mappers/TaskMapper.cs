using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.DTO;
using ORM;
using Task = System.Threading.Tasks.Task;

namespace DAL.Mappers
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
                CreationDate = dalEntity.CreationDate,
                Name = dalEntity.Name,
                Description = dalEntity.Description
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
                CreationDate = ormEntity.CreationDate,
                Name = ormEntity.Name,
                Description = ormEntity.Description
            };
        }
    }
}
