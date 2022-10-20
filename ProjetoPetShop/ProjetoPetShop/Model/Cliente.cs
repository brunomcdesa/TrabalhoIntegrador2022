using System.ComponentModel.DataAnnotations;

namespace ProjetoPetShop.Model
{
    public class Cliente
    {
        [Key]
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Telefone { get; set; }
    }
}
