using LojaDoSeuManoel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LojaDoSeuManoel.Infrastructure.Persistense
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

            modelBuilder.Entity<OrderEntity>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasOne(x => x.Costumer)
                .WithMany(x => x.OrderList)
                .HasForeignKey(x=>x.Id)
                .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<OrderProductGameEntity>(x =>
            {
                x.HasKey(x => x.Id);

                x.HasOne(x => x.Order)
                .WithMany(x => x.OrderList)
                .HasForeignKey(x=>x.OrderId)

                .HasForeignKey(x=>x.ProductGameId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
