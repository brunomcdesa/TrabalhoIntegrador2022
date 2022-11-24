using System;
﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPetShop.Model{
    public class Funcionario

    {
        [Key]
        [Required]
        public int IdFuncionario { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
      
        [JsonIgnore]
        public virtual List<Funcionario> Funcionarios { get; set; }
    }
}