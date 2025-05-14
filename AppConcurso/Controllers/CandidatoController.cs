using AppConcurso.Contexto;
using AppConcurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppConcurso.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly ContextoBD _context;

        public CandidatoController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Candidato>> ListaCandidatos()
        {
            var candidatos = await _context.Candidatos.Include(x => x.Inscricoes).ToListAsync();
            return candidatos;
        }
    }
}
