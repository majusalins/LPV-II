using AppInventario.Contexto;
using AppInventario.Models;
using Microsoft.EntityFrameworkCore;

namespace AppInventario.Services
{
    public class PessoaService
    {
        private readonly ContextoBD _context;

        public PessoaService(ContextoBD con)
        {
            _context = con;
        }

        public async Task<List<Pessoa>>? Pessoas()
        {
            var pessoas = await _context.Pessoas.Include(p => p.Propriedades).ToListAsync();
            return pessoas;
        }

        public async Task<Pessoa>? GetPessoa(int id)
        {
            var pessoa = await _context.Pessoas.Include(p => p.Propriedades).Where(p => p.Id == id).FirstOrDefaultAsync();
            return pessoa;
        }
        
        public async Task<Pessoa> GetPessoa(string cpf)
        {
            var pessoa = await _context.Pessoas.Include(p => p.Propriedades).Where(p => p.Cpf == cpf).FirstOrDefaultAsync();
            return pessoa;
        }

        public async Task Add(Pessoa pessoa)
        {
            if(pessoa != null)
            {
                await _context.Pessoas.AddAsync(pessoa);
            }
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}
