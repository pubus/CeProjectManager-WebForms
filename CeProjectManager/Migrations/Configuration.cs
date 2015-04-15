using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using CeProjectManager.Models;
using MySql.Data.Entity;

namespace CeProjectManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    internal sealed class Configuration : DbMigrationsConfiguration<CeProjectManager.Models.CeSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(CeProjectManager.Models.CeSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            Privilege[] Privileges = 
            {
                new Privilege()
                {
                    Name = "Admin",
                    Description = "Full administrative rights."
                },

                new Privilege()
                {
                    Name = "CanCreateGroups",
                    Description = "Can create new group and add user to it."
                },

                new Privilege()
                {
                    Name = "CanAddNewsForGroup",
                    Description = "Can create News entry for own group, except Global."
                },

                new Privilege()
                {
                    Name = "CanAddNews",
                    Description = "Can create News entry for any group."
                },

                new Privilege()
                {
                    Name = "CanViewFile",
                    Description = "Can view file from repository."
                },

                new Privilege()
                {
                    Name = "CanModifyFile",
                    Description = "Can Add/Update/Delete file from repository."
                }
            };
            context.Privileges.AddOrUpdate(up => up.Name, Privileges);
            context.SaveChanges();

            Group group = new Group()
            {
                Name = "Global",
                Description = "Group of all app users.",
                //News = new List<News>() { news }
            };
            context.Groups.AddOrUpdate(g => g.Name, group);
            context.SaveChanges();

            News[] news = 
            {
                new News()
                {
                    DestinationGroup = group,
                    Subject = "Welcome",
                    Text = "Welcome to CE Project Manager.",
                    DateTime = DateTime.UtcNow
                },
               
                new News()
                {
                    DestinationGroup = group,
                    Subject = "Test1",
                    Text = "This is test news number 1.",
                    DateTime = DateTime.UtcNow
                },

                new News()
                {
                    DestinationGroup = group,
                    Subject = "Test2",
                    Text = "This is test news number 2.",
                    DateTime = DateTime.UtcNow
                }
            };
            context.News.AddOrUpdate(n => n.NewsId, news);
            context.SaveChanges();

            HashAlgorithm algorithm = SHA1.Create();  // SHA1.Create()
           
            context.Users.AddOrUpdate(u => new { u.UserId },
                new User()
                {
                    Logged = false, 
                    Name = "Admin", 
                    Surname = "Adminowicz", 
                    Login = "admin",
                    Password = Tools.Tools.GetHashString("admin"),
                    Privileges = new List<Privilege>() { Privileges[0] },
                    Groups = new List<Group>() { group }
                },

                new User()
                {
                    Logged = false,
                    Name = "Jan",
                    Surname = "Kowalski",
                    Login = "jkowalski",
                    Password = Tools.Tools.GetHashString("jkowalski"),
                    Privileges = new List<Privilege>() { Privileges[1] },
                    Groups = new List<Group>() { group }
                },

                new User()
                {
                    Logged = false,
                    Name = "Jan",
                    Surname = "Nowak",
                    Login = "jnowak",
                    Password = Tools.Tools.GetHashString("jnowak"),
                    Privileges = new List<Privilege>() { Privileges[1] },
                    Groups = new List<Group>() { group }
                });
            context.SaveChanges();
        }
    }
}
