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
        public DateTime Data { get; set; }

        public int IdPet { get; set; }
  
        [JsonIgnore]
        public virtual Pet Pet { get; set; }
        
    }
}
