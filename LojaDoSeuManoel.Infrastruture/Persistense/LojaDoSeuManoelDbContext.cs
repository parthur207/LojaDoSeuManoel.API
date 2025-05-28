using Microsoft.EntityFrameworkCore;

namespace LojaDoSeuManoel.Infrastruture.Persistense
{
    public class LojaDoSeuManoelDbContext : DbContext
    {
        public LojaDoSeuManoelDbContext(DbContextOptions<LojaDoSeuManoelDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
