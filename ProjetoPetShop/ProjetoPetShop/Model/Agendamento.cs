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

       // [ForeignKey("Pet")]
        public int IdPet { get; set; }
        // um cara só para leituras colocar o virtual
        [JsonIgnore]
        public virtual Pet Pet { get; set; }
        

        //[ForeignKey("Servico")]
        //public List<Servico> Servicos { get; set; }


        // public List<Funcionario> Funcionarios { get; set; }
    }
}
