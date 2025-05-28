using LojaDoSeuManoel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LojaDoSeuManoel.Infrastruture.Persistense
{
    public class LojaDoSeuManoelDbContext : DbContext
    {
        public LojaDoSeuManoelDbContext(DbContextOptions<LojaDoSeuManoelDbContext> options)
            : base(options)
        {
        }

        public DbSet<BoxEntity> Box {get;set;}
        public DbSet<CustomerEntity> Customer { get; set; }
        public DbSet<ProductGameEntity> ProductGame { get; set; }
        public DbSet<OrderEntity> Order { get; set; }
        public DbSet<OrderProductGameEntity> OrderProductGame { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoxEntity>
                (
                x => x.HasKey(x => x.Id));

            modelBuilder.Entity<CustomerEntity>(x =>
            {
                x.HasKey(x => x.Id);

                x.HasMany(x => x.OrderList)
                    .WithOne(x => x.Costumer)
                    .HasForeignKey(x => x.CustomerId)//Chave estrangeira
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<ProductGameEntity>(x =>
            {
                x.HasKey(x => x.Id);//Chave primária
            });


        }

    }
}
