using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.DTO.Pessoa.AtualizarPessoa {
    public class AtualizarPessoaRequest {
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
    }
}
