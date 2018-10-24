namespace MyConcert.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<MyConcert.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyConcert.Models.ApplicationDbContext context)
        {
            context.Roles.AddOrUpdate(
                    new Microsoft.AspNet.Identity.EntityFramework.IdentityRole("Admin"),
                    new Microsoft.AspNet.Identity.EntityFramework.IdentityRole("Member")
                );

            // Check if user exists first, if not then add user
            if (!context.Users.Any(u => u.UserName == "admin@ticketshows.com"))
            {
            //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //    var manager = new UserManager<Models.ApplicationUser>(new UserStore<Models.ApplicationUser>(context));

            //    var user = new Models.ApplicationUser
            //    {
            //        UserName = "admin@ticketshows.com",
            //        Email = "admin@ticketshows.com",
            //        FirstName = "Admin",
            //        LastName = "Admin",
            //        Created = DateTime.Now,
            //        LastLogin = DateTime.Now
            //    };

            //    manager.Create(user, "Password_1");
            //    manager.AddToRole(user.Id, "Admin");
            }


        }
    }
}
