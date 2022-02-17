using AdidasModels.Solution.Entitys;
using AdidasModels.Solution.Configurations;
using AdidasModels.Solution.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdidasModels.Solution.EF
{
    public class AdidasDbContext : DbContext
    {
        public AdidasDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new TrademarkConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());

            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new SizeConfiguration());

            //Data seeding
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<ProductInCategory> ProductInCategories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Trademark> Trademarks { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<Promotion> Promotions { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<User> AppUsers { get; set; }
    }
}