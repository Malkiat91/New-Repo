namespace MvcApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcApplication1.Models.UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        //protected override void Seed(MvcApplication1.Models.UsersContext context)
        //{
        //    //  This method will be called after migrating to the latest version.

        //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //    //  to avoid creating duplicate seed data. E.g.
        //    //
        //    //    context.People.AddOrUpdate(
        //    //      p => p.FullName,
        //    //      new Person { FullName = "Andrew Peters" },
        //    //      new Person { FullName = "Brice Lambson" },
        //    //      new Person { FullName = "Rowan Miller" }
        //    //    );
        //    //
        //}

        protected override void Seed(MvcApplication1.Models.UsersContext context)
        {
            WebSecurity.InitializeDatabaseConnection(
                "DefaultConnection",
                "UserProfile",
                "UserId",
                "UserName", autoCreateTables: true);

            if (!Roles.RoleExists("Administrator"))
                Roles.CreateRole("Administrator");

            if (!WebSecurity.UserExists("admin"))
                WebSecurity.CreateUserAndAccount(
                    "admin",
                    "password",
                    new { Mobile = "+19725000000" });

            if (!Roles.GetRolesForUser("admin").Contains("Administrator"))
                Roles.AddUsersToRoles(new[] { "admin" }, new[] { "Administrator" });
        }
    }
}
