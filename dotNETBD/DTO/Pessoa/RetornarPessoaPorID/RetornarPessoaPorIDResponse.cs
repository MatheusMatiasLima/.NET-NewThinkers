using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.DTO.Pessoa.RetornarPessoaPorID {
    public class RetornarPessoaPorIDResponse {

        //public string mensagem;
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }

        public string mensagem;

    }
}
