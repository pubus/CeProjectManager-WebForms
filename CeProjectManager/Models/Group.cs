using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CeProjectManager.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<User> Members { get; set; }
    }
}