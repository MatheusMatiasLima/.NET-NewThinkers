using dotNETBD.Bordas.Adapter;
using dotNETBD.DTO.Pessoa.RetornarPessoaPorID;
using dotNETBD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.Adapter {
    public class RetornarPessoaPorIDAdapter : IRetornarPessoaPorIDAdapter {
        public RetornarPessoaPorIDResponse ConverterPessoaParaResponse(Pessoa pessoaDoID) {
            RetornarPessoaPorIDResponse response = new();

            response.id = pessoaDoID.id;
            response.nome = pessoaDoID.nome;
            response.cpf = pessoaDoID.cpf;

            return response;
        }
    }
}
