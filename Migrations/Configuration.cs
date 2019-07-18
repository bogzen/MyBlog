namespace MyBlog.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyBlog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyBlog.Models.ApplicationDbContext context)
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
            //var userStore = new UserStore<Models.ApplicationUser>(context);
            //var userManager = new UserManager<Models.ApplicationUser>(userStore);

            //var user = new Models.ApplicationUser
            //{
            //    Id = "1",
            //    Email = "lagutinam@gmail.com",
            //    EmailConfirmed = true,              
            //};

            //userManager.Create(user, "");
        }
    }
}
