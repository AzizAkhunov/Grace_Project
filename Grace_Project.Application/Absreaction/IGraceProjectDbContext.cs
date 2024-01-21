using Grace_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Grace_Project.Application.Absreaction
{
    public interface IGraceProjectDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Onlayn_kurs> OnlaynKurs { get; set; }
        public DbSet<Ochniy_kurs> OchniyKurs { get; set; }
        public DbSet<Bepul_kurs> BepulKurs { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
