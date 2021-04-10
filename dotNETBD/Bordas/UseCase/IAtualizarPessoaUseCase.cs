using dotNETBD.DTO.Pessoa.AtualizarPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.Bordas.Pessoa.UseCase {
    public interface IAtualizarPessoaUseCase {

        AtualizarPessoaResponse Executar(AtualizarPessoaRequest request);
    }
}
