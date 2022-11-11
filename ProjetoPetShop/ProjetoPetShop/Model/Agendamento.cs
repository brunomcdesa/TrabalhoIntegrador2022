using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjetoPetShop.Model
{
    public class Agendamento
    {
        [Key]
        public int IdAgendamento { get; set; }
        
        [Required]
        public DateTime Data { get; set; }
        
        [Required]
        public int IdPet { get; set; }

        [JsonIgnore]
        public virtual Pet Pet { get; set; }

        public int IdServico { get; set; }

        [JsonIgnore]
        public virtual Servico Servico { get; set; }
        
        
    }
}
