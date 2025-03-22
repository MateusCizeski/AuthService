using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                   .ToTable("authuser")
                   .HasIndex(u => u.Id)
                   .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .HasColumnName("id");

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasColumnName("name");

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasColumnName("email");

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasColumnName("password");

            modelBuilder.Entity<User>()
                .Property(u => u.EmailConfirmed)
                .HasColumnName("emailconfirmed");
        }
    }
}
