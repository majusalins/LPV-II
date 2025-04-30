using AppMultas.Models;
using Microsoft.EntityFrameworkCore;

namespace AppMultas.Contexto
{
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options) { 
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Multa> Multas { get; set; }
    }
}
