using AppInventario.Models;
using Microsoft.EntityFrameworkCore;

namespace AppInventario.Contexto
{
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options) { }

        public DbSet<Pessoa>? Pessoas { get; set; }
        public DbSet<Propriedade>? Propriedades { get; set; }

    }
}
