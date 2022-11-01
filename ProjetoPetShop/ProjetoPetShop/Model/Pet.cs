using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoPetShop.Model
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }
    }
}