using dotNETBD.DTO.Pessoa.AdicionarPessoa;
using dotNETBD.DTO.Pessoa.AtualizarPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.Bordas.Adapter {
    public interface IAtualizarPessoaAdapter {
        public Entities.Pessoa ConverterRequestParaPessoa(AtualizarPessoaRequest request);
    }
}
