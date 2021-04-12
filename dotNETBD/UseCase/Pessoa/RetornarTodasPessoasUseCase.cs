using dotNETBD.Bordas.Pessoa.UseCase;
using dotNETBD.Bordas.Repositorio;
using dotNETBD.DTO.Pessoa.RetornarTodasPessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.UseCase.Pessoa {
    public class RetornarTodasPessoasUseCase : IRetornarTodasPessoasUseCase {

        private readonly IRepositorioRetornarTodasPessoas repositorio;

        public RetornarTodasPessoasUseCase(IRepositorioRetornarTodasPessoas repositorio) {
            this.repositorio = repositorio;
        }

        public RetornarTodasPessoasResponse Executar() {

            RetornarTodasPessoasResponse response = new();

            response.lista = repositorio.RetornarTodasPessoas();

            return response;
        }
    }
}
