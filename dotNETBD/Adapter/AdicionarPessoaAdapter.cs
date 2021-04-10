using dotNETBD.Bordas.Adapter;
using dotNETBD.DTO.Pessoa.AdicionarPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNETBD.Entities;


namespace dotNETBD.Adapter {
    public class AdicionarPessoaAdapter : IAdicionarPessoaAdapter  {
        public Pessoa ConverterRequestParaPessoa(AdicionarPessoaRequest request) {
            Pessoa novaPessoa = new() {
                nome = request.nome ,
                cpf = request.cpf
            };
            return novaPessoa;
        }
    }
}