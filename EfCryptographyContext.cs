using Microsoft.EntityFrameworkCore;

namespace EFCryptography
{
    public class EfCryptographyContext : DbContext
    {
        public DbSet<User> Users { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=mssql.mas.ao,4433;Initial Catalog=EFCrypto;User Id=sa;Password=M@rtina2019;Persist Security Info=False;Trusted_Connection=False;Encrypt=False;TrustServerCertificate=True;");

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

