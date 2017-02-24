namespace LearningTracker.Data.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LearningContext : DbContext
    {
        public LearningContext()
            : base("name=LearningConnection")
        {
        }

        public virtual DbSet<AssignedCourse> AssignedCourse { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(e => e.AssignedCourse)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.AssignedCourse)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);
        }
    }
}
