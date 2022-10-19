using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace ProjetoPetShop.Model
{
    public class Pet
    {
        [Key]
        public int Id_Pet { get; set; }
        [Required]
        public string Nome_Pet { get; set; }
        [Required]
        public DateTime Nascimento { get; set; }
        [Required]
        public Boolean Deficiencia { get; set; }
        [Required]
        public string Especie { get; set; }
        [ForeignKey("Cliente")]
        public int Id_Cliente { get; set; }

    }
}
