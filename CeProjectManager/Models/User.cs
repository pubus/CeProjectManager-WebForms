using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Services.Description;

namespace CeProjectManager.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        
        public string Password { get; set; } //SHA1

        public bool Logged { get; set; }

        public virtual List<UserPrivilege> Privilegeses { get; set; }

        public virtual List<Message> Messages { get; set; }

        public virtual List<News> News { get; set; }

        public User()
        {
            Privilegeses = new List<UserPrivilege>();
            Messages = new List<Message>();
            News = new List<News>();
        }
    }
}