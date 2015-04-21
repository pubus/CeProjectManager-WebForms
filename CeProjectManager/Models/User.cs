using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Services.Description;

namespace CeProjectManager.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        [NotMapped]
        public string PrivilegesString { get; set; }
        
        public string Password { get; set; } //SHA1

        public bool Logged { get; set; }

        public virtual ICollection<Privilege> Privileges { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        
        public void CreatePrivilegesString()
        {
            if(Privileges != null)
                foreach (Privilege p in Privileges)
                    PrivilegesString += p.Name + " ";
        }
        
        /*
        public bool LoginUser()
        {
            
            try
            {
                CeSystemContext db = new CeSystemContext();

                this.Logged = true;
                db.Users
            }
            catch (Exception)
            {
                    
                throw;
            }
        }

        public bool LogoutUser()
        {
            
        }
         */
    }
}