using AppPessoa.Models;
using AppPessoa.Services;

namespace AppPessoa.Contexto
{
    public class ContextBD
    {
        public ContextBD()
        {
            Pessoas = new List<Pessoa>();
        }    
        public List<Pessoa>? Pessoas { get; set; }

    }

}
