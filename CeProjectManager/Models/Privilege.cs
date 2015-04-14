using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CeProjectManager.Models
{
    public class Privilege
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrivilegeId { get; set; }

        [MaxLength(45), StringLength(45, ErrorMessage = "{0} can have max length of {1} characters")]
        public string Name { get; set; }

        [MaxLength(255), StringLength(255, ErrorMessage = "{0} can have max length of {1} characters")]
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}