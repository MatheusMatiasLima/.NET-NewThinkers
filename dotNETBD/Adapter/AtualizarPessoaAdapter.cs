using dotNETBD.Bordas.Adapter;
using dotNETBD.DTO.Pessoa.AdicionarPessoa;
using dotNETBD.DTO.Pessoa.AtualizarPessoa;
using dotNETBD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.Adapter {
    public class AtualizarPessoaAdapter : IAtualizarPessoaAdapter {
        public Pessoa ConverterRequestParaPessoa(AtualizarPessoaRequest request) {
            Pessoa novaPessoa = new() {
                id = request.id,
                nome = request.nome ,
                cpf = request.cpf
            };
            return novaPessoa;
        }
    }
}
