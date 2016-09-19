using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class User
    {
        public User()
        {
            Tasks = new HashSet<Task>();
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        
        public virtual ICollection<Task> Tasks { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
