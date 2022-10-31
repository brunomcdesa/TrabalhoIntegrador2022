﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPetShop.Model
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [Required]
        public string nomeCliente { get; set; }
    }
}