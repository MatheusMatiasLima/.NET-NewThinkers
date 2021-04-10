using dotNETBD.DTO.Pessoa.RetornarPessoaPorID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.Bordas.Pessoa.UseCase {
    public interface IRetornarPessoaPorIDUseCase {

        RetornarPessoaPorIDResponse Executar(RetornarPessoaPorIDRequest request);
    }
}
