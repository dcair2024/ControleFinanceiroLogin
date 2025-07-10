using Microsoft.EntityFrameworkCore;
using ControleFinanceiroLogin.Models;

namespace ControleFinanceiroLogin.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Despesa> Despesas { get; set; }



    }
}
