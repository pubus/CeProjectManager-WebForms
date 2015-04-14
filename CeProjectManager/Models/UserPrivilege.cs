using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CeProjectManager.Models
{
    public class UserPrivilege
    {
        public virtual Privilege Privilege { get; set; }

        public virtual User User { get; set; }
    }
}
