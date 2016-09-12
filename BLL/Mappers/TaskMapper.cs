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
        public static TaskEntity GetBllEntity(this DalTask dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new TaskEntity()
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

        public static DalTask GetDalEntity(this TaskEntity bllEntity)
        {
            return new DalTask()
            {
                Id = bllEntity.Id,
                Checked = bllEntity.Checked,
                SenderId = bllEntity.SenderId,
                RecipientId = bllEntity.RecipientId,
                CreationDate = bllEntity.CreationDate,
                Name = bllEntity.Name,
                Description = bllEntity.Description
            };
        }
    }
}
