namespace CeProjectManager.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CeSystemContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        //public virtual DbSet<UserPrivilege> UserPrivileges { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Privilege> Privileges { get; set; }
        //public virtual DbSet<UserGroups> UserGroups { get; set; }

        public CeSystemContext() : base("name=CeSystemContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
