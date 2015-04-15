using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CeProjectManager.Models
{
    public class UserGroups
    {
        public virtual Group Group { get; set; }

        public virtual User User { get; set; }
    }
}