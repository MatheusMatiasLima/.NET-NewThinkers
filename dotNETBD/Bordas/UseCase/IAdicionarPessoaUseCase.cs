using dotNETBD.DTO.Pessoa.AdicionarPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.Bordas.Pessoa.UseCase {
    public interface IAdicionarPessoaUseCase {

        AdicionarPessoaResponse Executar(AdicionarPessoaRequest request);

    }
}
