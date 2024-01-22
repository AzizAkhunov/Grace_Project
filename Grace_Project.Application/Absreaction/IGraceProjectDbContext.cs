using Grace_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Application.Absreaction
{
    public interface IGraceProjectDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
