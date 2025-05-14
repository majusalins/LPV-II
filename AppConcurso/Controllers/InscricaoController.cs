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

        public async Task<List<Inscricao>> ListaInscricoes()
        {
            var inscricoes = await _context.Inscricoes.Include(x => x.Cargo).Include(x => x.Candidato).ToListAsync();
            return inscricoes;
        }

        public async Task Add(Inscricao inscricao)
        {
            await _context.Inscricoes.AddAsync(inscricao);
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}
