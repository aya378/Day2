using Microsoft.EntityFrameworkCore;

namespace Day2.Models
{
    public class ITIContext:DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Ins_Course> Ins_Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Std_Crs> Std_Crs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BenhaContext;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ins_Course>().HasKey("ins_id", "crs_id");
            modelBuilder.Entity<Std_Crs>().HasKey("st_id", "crs_id");
            base.OnModelCreating(modelBuilder);
        }
    }
}
