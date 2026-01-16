using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;

namespace UrlShortener.Data {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions options) : base(options) {
        }

        public DbSet<Url> UrlShort { get; set; }
    }
}
