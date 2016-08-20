using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using DAL.DTO;

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
                Description = dalEntity.Description,
            };
        }
    }
}
