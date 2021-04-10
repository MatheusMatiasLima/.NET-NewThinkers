using dotNETBD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNETBD.Entities;

using dotNETBD.DTO.Pessoa.AdicionarPessoa;

namespace dotNETBD.Bordas.Adapter {
    public interface IAdicionarPessoaAdapter {
        public Entities.Pessoa converterRequestParaPessoa(AdicionarPessoaRequest request);
    }
}