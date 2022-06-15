using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ResurantApiCore6.Models.Contexts
{
    public class AuthDBContext : IdentityDbContext<IdentityUser>
    {
        private IConfiguration _configuration;
        public AuthDBContext(DbContextOptions<AuthDBContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring (optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}