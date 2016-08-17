using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class DalRole
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<DalUser> Users { get; set; }
    }
}
