using dotNETBD.DTO.Pessoa.DeletarPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNETBD.Entities;

namespace dotNETBD.Bordas.Adapter {
    public interface IDeletarPessoaAdapter {
        public Entities.Pessoa ConverterRequestParaPessoa(DeletarPessoaRequest request);
    }
}
