using Core6.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace Core6.Models.Contexts {
    public class DBContext : DbContext {
        private IConfiguration _configuration;
        public DBContext (IConfiguration configuration) {
            _configuration = configuration;
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring (optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Resturants> Resturants { get; set; }

        public DbSet<Foods> Foods { get; set; }

    }
}