using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Entities;

namespace TasksManager.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public int RecipientId { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Checked { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual UserEntity User { get; set; }

        public virtual UserEntity User1 { get; set; }

    }

    public class TasksViewModel
    {
        public List<TaskViewModel> Tasks;
        public List<TaskViewModel> CheckedTasks;
        public int CountTasks;
        public int CountCheckedTasks;
    }

}