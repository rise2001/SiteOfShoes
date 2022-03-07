using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteOfShoes.Entities.Accounting
{
    public class Role
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual List<Role> Shoes { get; set; } = new List<Role>();
    }
}
