using Grace_Project.Application.Absreaction;
using Grace_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Infastructure.Persitance
{
    public class GraceProjectDbContext : DbContext , IGraceProjectDbContext
    {
        public GraceProjectDbContext(DbContextOptions<GraceProjectDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Courses)
                .WithMany(e => e.Users)
                .UsingEntity(
                    "PostTag",
                    l => l.HasOne(typeof(User)).WithMany().HasForeignKey("UserId").HasPrincipalKey(nameof(User.Id)),
                    r => r.HasOne(typeof(Course)).WithMany().HasForeignKey("CouseId").HasPrincipalKey(nameof(Course.Id)),
                    j => j.HasKey("UserId", "CourseId"));
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
