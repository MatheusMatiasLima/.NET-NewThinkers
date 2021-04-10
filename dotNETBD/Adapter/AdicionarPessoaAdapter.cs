using dotNETBD.Bordas.Adapter;
using dotNETBD.DTO.Pessoa.AdicionarPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNETBD.Entities;


namespace dotNETBD.Adapter {
    public class AdicionarPessoaAdapter : IAdicionarPessoaAdapter  {
        public Pessoa converterRequestParaPessoa(AdicionarPessoaRequest request) { 
            Pessoa novaPessoa = new Pessoa();
            novaPessoa.nome = request.nome;
            novaPessoa.cpf = request.cpf;
            return novaPessoa;
        }
    }
}