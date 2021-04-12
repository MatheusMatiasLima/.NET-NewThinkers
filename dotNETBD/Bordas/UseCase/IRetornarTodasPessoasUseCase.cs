using dotNETBD.DTO.Pessoa.RetornarTodasPessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.Bordas.Pessoa.UseCase {
    public interface IRetornarTodasPessoasUseCase {
        RetornarTodasPessoasResponse Executar();

    }
}
