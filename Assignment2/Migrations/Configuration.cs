namespace Assignment2.Migrations
{
    using Assignment2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment2.Models.VisitorLogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Assignment2.Models.VisitorLogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
                context.Programs.AddOrUpdate(m => m.ProgramID,
                  new Program() { ProgramName = "Web Developer Degree" },
                  new Program() { ProgramName = "ETSP Degree" },
                  new Program() { ProgramName = "Network Technology Degree" }
                );

            context.Users.AddOrUpdate(m => m.UserID,

            new User()
            {
                UserID = 1,
                Email = "usalex93@gmail.com",
                FirstName = "Alex",
                LastName = "Usoski",
                EmailUpdates = true,
                ProgramID = 1,
                LoggedIn = false

            });

                context.SaveChanges();


            //
        }
    }
}
