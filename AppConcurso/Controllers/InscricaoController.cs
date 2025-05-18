using AppConcurso.Contexto;
using AppConcurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppConcurso.Controllers
{
    public class InscricaoController : Controller
    {
        private readonly ContextoBD _context;

        public InscricaoController(ContextoBD context)
        {
            _context = context;
        }

        public async Task Add(Inscricao inscricao)
        {
            await _context.Inscricoes.AddAsync(inscricao);
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Inscricao>> ListaInscricoes()
        {
            return await _context.Inscricoes
                .Include(i => i.Cargo)
                .Include(i => i.Candidato)
                .ToListAsync();
        }
    }
}
