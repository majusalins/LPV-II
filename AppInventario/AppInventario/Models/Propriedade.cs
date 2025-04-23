using System.ComponentModel.DataAnnotations.Schema;

namespace AppInventario.Models
{
    [Table("propriedade")]
    public class Propriedade
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("descricao")]
        public string? Descricao { get; set; }
        
        [Column("valor")]
        public double? Valor { get; set; }

        [Column("id_pessoa")]
        public int? IdPessoa { get; set; }

        [ForeignKey("IdPessoa")]
        public Pessoa? Pessoa { get; set; }
    }
}
