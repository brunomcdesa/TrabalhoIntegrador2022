using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;

namespace ProjetoPetShop.Model
{
    public class Pet
    {
        [Key]
        public int IdPet { get; set; }
        [Required]
        public string NomePet { get; set; }
        [Required]
        public DateTime Nascimento { get; set; }
        [Required]
        public Boolean Deficiencia { get; set; }
        [Required]
        public string Especie { get; set; }

        // [ForeignKey("Cliente")]
        // public int IdCliente { get; set; }
        [Required]
        public int IdCliente { get; set; }


        [JsonIgnore]
        public virtual List<Agendamento> Agendamentos { get; set; }

        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }


    }
}