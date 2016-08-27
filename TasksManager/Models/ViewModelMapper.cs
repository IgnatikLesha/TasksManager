using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Entities;

namespace TasksManager.Models
{
    public static class ViewModelMapper
    {
        public static TaskViewModel GetTaskViewModel(this TaskEntity bllEntity)
        {
            if (bllEntity == null)
                return null;
            return new TaskViewModel()
            {
                Id = bllEntity.Id,
                Name = bllEntity.Name,
                CreationDate = bllEntity.CreationDate,
                Description = bllEntity.Description,
                SenderId = bllEntity.SenderId,
                RecipientId = bllEntity.RecipientId,
                Checked = bllEntity.Checked
            };
        }

        public static TasksViewModel GetTasksViewModel(this List<TaskEntity> listBllEntity)
        {
            TasksViewModel model = new TasksViewModel()
            {
                Tasks = listBllEntity.Where(t => t.Checked != true).Select(t => t.GetTaskViewModel()).ToList(),
                CheckedTasks = listBllEntity.Where(t => t.Checked == true).Select(t => t.GetTaskViewModel()).ToList(),

            };
            model.CountTasks = model.Tasks.Count;
            model.CountCheckedTasks = model.CheckedTasks.Count;
            return model;
        }
    }
}