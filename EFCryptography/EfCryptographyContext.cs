using Microsoft.EntityFrameworkCore;

namespace EFCryptography
{
    public class EfCryptographyContext : DbContext
    {
        public DbSet<User> Users { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=EFCrypto;User Id=<Your user name>;Password=<Your Password>;Persist Security Info=False;Trusted_Connection=False;Encrypt=False;TrustServerCertificate=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .ToTable("User")
                        .Property(e => e.UserId).ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                        .Property(e => e.Password)
                        .HasConversion<Cryptography>();

            base.OnModelCreating(modelBuilder);
        }
    }
}

