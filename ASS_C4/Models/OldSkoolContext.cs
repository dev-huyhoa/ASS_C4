using Microsoft.EntityFrameworkCore;

namespace ASS_C4.Models
{
    public class OldSkoolContext : DbContext
    {
        public OldSkoolContext(DbContextOptions<OldSkoolContext> options)
          : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ListProduct> ListProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);
                entity.Property(e => e.NameRole).HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(50);
                entity.Property(e => e.NameRole).IsRequired(true);
            });

            modelBuilder.Entity<ListProduct>(entity =>
            {
                entity.HasKey(e => e.IdListProduct);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);
                entity.Property(e => e.NameEmployee).HasMaxLength(50);
                entity.Property(e => e.Address).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(11);
                entity.Property(e => e.Password).HasMaxLength(30);
                entity.HasOne(e => e.Roles)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.RoleId);
                entity.Property(e => e.Email).IsRequired(true);
                entity.Property(e => e.NameEmployee).IsRequired(true);
                entity.Property(e => e.Password).IsRequired(true);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory);
                entity.Property(e => e.NameCategory).HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(50);
                entity.Property(e => e.NameCategory).IsRequired(true);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct);
                entity.Property(e => e.NameProduct).HasMaxLength(50);
                entity.Property(e => e.Decription).HasMaxLength(100);
                entity.Property(e => e.Image).HasMaxLength(1000);
                entity.Property(e => e.NameProduct).IsRequired(true);
                entity.HasOne(e => e.Categories)
               .WithMany(d => d.Products)
               .HasForeignKey(e => e.CategoryId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);
                entity.Property(e => e.CustomerAddress).HasMaxLength(100);
                entity.Property(e => e.CustomerPhone).HasMaxLength(11);
                entity.Property(e => e.CustomerName).HasMaxLength(50);
                entity.Property(e => e.CustomerPhone).IsRequired(true);
                entity.Property(e => e.CustomerAddress).IsRequired(true);
                entity.HasOne(e => e.Payments)
               .WithMany(d => d.Orders)
               .HasForeignKey(e => e.PaymentId);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.IdOrderDetail);
                entity.HasOne(e => e.Orders)
               .WithMany(d => d.OrderDetails)
               .HasForeignKey(e => e.OrderId);
            });


            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.IdPayment);
                entity.Property(e => e.NamePayment).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);
                entity.Property(e => e.NameCustomer).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(11);
                entity.Property(e => e.Address).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(25);

                entity.Property(e => e.NameCustomer).IsRequired(true);
                entity.Property(e => e.Email).IsRequired(true);
                entity.Property(e => e.Phone).IsRequired(true);
            });
        }
    }
}
