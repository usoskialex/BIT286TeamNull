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
            //  to avoid creating duplicate seed data.
            context.Users.AddOrUpdate(m => m.UserID,

           new User()
           {
               UserID = 1,
               Email = "sa@sa.com",
               Password = "sa",
               FirstName = "Alex",
               LastName = "Usoski",
               EmailUpdates = true,
               LoggedIn = false
           });
           context.Students.AddOrUpdate(m => m.StudentID,

           new Student()
            {
                StudentID = 1,
                FirstName = "Buddy",
                LastName = "Friend",
                Password = "Spot"
            });
        }
    }
}
