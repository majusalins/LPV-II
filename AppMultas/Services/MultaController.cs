using AppMultas.Contexto;
using AppMultas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMultas.Services
{
    public class MultaController : Controller
    {

        private readonly ContextoBD _context;

        public MultaController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Multa>> ListaDeMultas()
        {
            var multas = await _context.Multas.Include(v => v.Veiculo).ToListAsync();
            return multas;
        }

        public async Task Add(Multa multa)
        {
            await _context.Multas.AddAsync(multa);
        }

        public async Task AddRanger(List<Multa> multas)
        {
            await _context.Multas.AddRangeAsync(multas);
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }

    }
}
