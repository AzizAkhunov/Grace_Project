using Grace_Project.Application.Absreaction;
using Grace_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Infastructure.Persitance
{
    public class GraceProjectDbContext : DbContext , IGraceProjectDbContext
    {
        public GraceProjectDbContext(DbContextOptions<GraceProjectDbContext> options)
            : base(options)
            => Database.Migrate();

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Courses)
                .WithMany(e => e.Users)
                .UsingEntity(nameof(UserCourse));
        }
    }
}
