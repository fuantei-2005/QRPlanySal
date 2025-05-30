using APIDB.Model;
using Microsoft.EntityFrameworkCore;

namespace APIDB
{
    public class AppDataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public virtual DbSet<Nauczyciel>? Nauczyciel { get; set; }
        public virtual DbSet<Lekcja>? Lekcja { get; set; }
        public virtual DbSet<Przedmiot>? Przedmiot { get; set; }
        public virtual DbSet<Sala>? Sala { get; set; }
        public virtual DbSet<Klasa>? Klasa { get; set; }
        public AppDataContext(DbContextOptions<AppDataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var serverVersion = new MySqlServerVersion(new Version(10, 4, 27));

            optionsBuilder.UseMySql(_configuration.GetConnectionString("MySqlConnection"), serverVersion).UseLazyLoadingProxies();
        }

    }
}