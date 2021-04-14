using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNETBD.Entities;

namespace dotNETBD.DTO.Pessoa.RetornarTodasPessoas {
    public class RetornarTodasPessoasResponse {
        public List<Entities.Pessoa> lista;
        public string mensagem;
    }
}
