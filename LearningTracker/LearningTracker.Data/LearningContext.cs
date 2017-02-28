namespace LearningTracker.Data
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations.Schema;

    public class LearningContext : DbContext
    {

        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<AssignedCourse> AssignedCourses { get; set; }

        // El contexto se ha configurado para usar una cadena de conexión 'LearningContext' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'LearningTracker.Data.LearningContext' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'LearningContext'  en el archivo de configuración de la aplicación.
        public LearningContext() : base("name=LearningContext")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var individual = modelBuilder.Entity<Individual>();
            individual.HasKey(x => x.Id);
            individual.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            individual.Property(x => x.Name).HasMaxLength(200).IsRequired();
            individual.Property(x => x.Email).HasMaxLength(500).IsRequired();

            var course = modelBuilder.Entity<Course>();
            course.HasKey(x => x.Id);
            course.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            course.Property(x => x.Name).HasMaxLength(250).IsRequired();
            course.Property(x => x.DurationAvg).IsOptional();
            course.Property(x => x.Description).HasMaxLength(500).IsOptional();
            course.HasMany(x => x.Topics);

            var topic = modelBuilder.Entity<Topic>();
            topic.HasKey(x => x.Id);
            topic.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            topic.Property(x => x.Name).HasMaxLength(200);
            topic.Property(x => x.Description).HasMaxLength(500);
            topic.HasMany(x => x.Courses);

            var assignments = modelBuilder.Entity<AssignedCourse>();
            assignments.HasKey(x => x.Id);
            assignments.Property(x => x.IsCompleted).IsRequired();
            assignments.Property(x => x.StartDate).IsOptional();
            assignments.Property(x => x.FinishDate).IsOptional();
            assignments.Property(x => x.TotalHours).IsOptional();
            assignments.HasRequired(x => x.Individual).WithMany().HasForeignKey(x => x.IndividualId);
            assignments.HasRequired(x => x.Course).WithMany().HasForeignKey(x => x.CourseId);
            
            base.OnModelCreating(modelBuilder);
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}