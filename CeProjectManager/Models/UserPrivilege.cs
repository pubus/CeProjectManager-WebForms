using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CeProjectManager.Models
{
    public class UserPrivilege
    {
        [Key]
        public int PrivilegeId { get; set; }

        [MaxLength(45), StringLength(45, ErrorMessage = "{0} can have max length of {1} characters")]
        public string Name { get; set; }

        [MaxLength(255), StringLength(255, ErrorMessage = "{0} can have max length of {1} characters")]
        public string Description { get; set; }

        public User User { get; set; }
    }
}
