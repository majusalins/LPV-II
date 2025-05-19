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

        public async Task<Inscricao> BuscarInscricao(string busca)
        {
            if (int.TryParse(busca, out int numero))
            {
                return await _context.Inscricoes
                .Include(i => i.Cargo)
                .Include(i => i.Candidato)
                .FirstOrDefaultAsync(i => i.NumInscricao == numero);
            }

            return await _context.Inscricoes
                .Include(i => i.Cargo)
                .Include(i => i.Candidato)
                .FirstOrDefaultAsync(i => i.Candidato.Cpf == busca);
        }

        public async Task AtualizarNotas(Inscricao inscricao)
        {
            var existente = await _context.Inscricoes.FindAsync(inscricao.Id);
            inscricao.NotaConhGerais = inscricao.NotaConhGerais;
            inscricao.NotaConhEspec = inscricao.NotaConhEspec;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Inscricao>> ObterInscricoesComNotas()
        {
            return await _context.Inscricoes
                .Include(i => i.Candidato)
                .Include(i => i.Cargo)
                .Where(i => i.NotaConhEspec != null && i.NotaConhGerais != null)
                .ToListAsync();
        }
    }
}
