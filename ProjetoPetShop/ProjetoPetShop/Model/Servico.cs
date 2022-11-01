using System.ComponentModel.DataAnnotations;

namespace ProjetoPetShop.Model
{
    public class Servico
    {
        [Key]
        public int IdServico { get; set; }
        [Required]
        public string TipoServico { get; set; }
        public double Valor { get; set; }

        public Servico (int idServico, string tipoServico, double valor)
        {
            this.IdServico = idServico;
            this.TipoServico = tipoServico;
            this.Valor = valor;
        }
        public Servico()
        {

        }
    }
}
