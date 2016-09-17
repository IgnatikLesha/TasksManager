using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.Repository;

namespace DAL.DTO
{
    public class DalTask : IEntity
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
