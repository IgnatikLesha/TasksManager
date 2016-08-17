using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public int RecipientId { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Checked { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
