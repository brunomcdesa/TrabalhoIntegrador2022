using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoPetShop.Model
{
    public class Servico
    {
        [Key]
        public int IdServico { get; set; }
        [Required]
        public string TipoServico { get; set; }
        public double Valor { get; set; }

        [JsonIgnore]
        public virtual List<Agendamento> Agendamentos { get; set; }


    }
}
