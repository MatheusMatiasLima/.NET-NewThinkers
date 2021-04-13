using dotNETBD.Bordas.Adapter;
using dotNETBD.DTO.Pessoa.DeletarPessoa;
using dotNETBD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.Adapter {
    public class DeletarPessoaAdapter : IDeletarPessoaAdapter {
        public Pessoa ConverterRequestParaPessoa(int request) {
            Pessoa novaPessoa = new() {
                id = request
            };
            return novaPessoa;
        }
    }
}
