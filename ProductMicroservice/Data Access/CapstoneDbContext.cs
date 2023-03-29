using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Models;


namespace ProductMicroservice.Data_Access
{
    public class CapstoneDbContext:DbContext
    {
        public CapstoneDbContext(DbContextOptions<CapstoneDbContext> options) : base(options)
        {

        }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductsCategory> ProductsCategory { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Carts> Carts { get; set; }
        public DbSet<CartItems> CartItems { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().ToTable("Products");
            modelBuilder.Entity<ProductsCategory>().ToTable("ProductsCategory");
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Carts>().ToTable("Carts");
            modelBuilder.Entity<CartItems>().ToTable("CartItems");

        }
    }
}
