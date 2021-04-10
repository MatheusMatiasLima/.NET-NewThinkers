using dotNETBD.DTO.Pessoa.DeletarPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.Bordas.Pessoa.UseCase {
    public interface IDeletarPessoaUseCase {

        DeletarPessoaResponse Executar(DeletarPessoaRequest request);
    }
}
