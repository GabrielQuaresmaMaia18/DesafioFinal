using DesafioFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
