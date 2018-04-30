namespace Assignment2.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class VisitorLogContext : DbContext
    {
        // The context has been configured to use a 'VisitorLog' connection string. 
        //  By default, this connection string targets the 
        // 'Assignment2.Models.VisitorLog' database on your LocalDb instance. 

        public VisitorLogContext(): base("name=VisitorLog")
        {
        }

        // Base DB models. Add a DbSet for any other entity type that you want to include in your model. 
        public virtual DbSet<User> Users { get; set; } 
        public virtual DbSet<Activity> Activities { get; set; }


    }

}