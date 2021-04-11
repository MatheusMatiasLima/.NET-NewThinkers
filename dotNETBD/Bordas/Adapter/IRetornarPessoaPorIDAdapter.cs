using dotNETBD.DTO.Pessoa.RetornarPessoaPorID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.Bordas.Adapter {
    public interface IRetornarPessoaPorIDAdapter {
        public RetornarPessoaPorIDResponse ConverterPessoaParaResponse(Entities.Pessoa pessoaDoID);
    }
}
