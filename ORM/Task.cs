using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class Task
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public int RecipientId { get; set; }

        public DateTime DateCreation { get; set; }

        public bool Checked { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
