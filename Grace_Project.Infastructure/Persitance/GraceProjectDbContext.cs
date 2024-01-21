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
        public DbSet<User> Users { get; set; }
        public DbSet<Onlayn_kurs> OnlaynKurs { get; set; }
        public DbSet<Ochniy_kurs> OchniyKurs { get; set; }
        public DbSet<Bepul_kurs> BepulKurs { get; set; }
    }
}
