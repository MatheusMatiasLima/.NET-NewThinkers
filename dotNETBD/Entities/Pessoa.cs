using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.Entities
{
    public class Pessoa
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
    }
}
