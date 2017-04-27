namespace StudentQueue.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using StudentQueue.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentQueue.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentQueue.Models.ApplicationDbContext context)
        {
            var studentRole = "student";
            var instructor = "instructor";
            var opsTeams = "ops";

            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            if (!context.Roles.Any(a => a.Name == studentRole))
            {
                var role = new IdentityRole { Name = studentRole };
                manager.Create(role);
            }
            if (!context.Roles.Any(a => a.Name == instructor))
            {
                var role = new IdentityRole { Name = instructor };
                manager.Create(role);
            }
            if (!context.Roles.Any(a => a.Name == opsTeams))
            {
                var role = new IdentityRole { Name = opsTeams };
                manager.Create(role);
            }

            var defaultInstructor = "instruct@tiy.com";
            var password = "Password1!";

            if (!context.Users.Any(a => a.UserName == defaultInstructor))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = defaultInstructor };

                userManager.Create(user, password);
                userManager.AddToRole(user.Id, instructor);
            }



        }
    }
}
