using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPetShop.Model
{
    public class Cliente
    {
        [Key]
        public int Id_Cliente { get; set; }
    }
}
