using System.ComponentModel.DataAnnotations;

namespace ProjetoPetShop.Model
{
    public class Servico
    {
        [Key]
        public int idServico { get; set; }
        [Required]
        public string tipoServico { get; set; }
        public double valor { get; set; }

        public Servico (int idServico, string tipoServico, double valor)
        {
            this.idServico = idServico;
            this.tipoServico = tipoServico;
            this.valor = valor;
        }
        public Servico()
        {

        }
    }
}
