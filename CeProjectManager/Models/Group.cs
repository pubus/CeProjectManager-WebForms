using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CeProjectManager.Models
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<User> Members { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}