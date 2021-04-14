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

            response = repositorio.RetornarTodasPessoas();
            
            if (response.lista[0].id == -1) {
                response.mensagem = "Não foi possivel achar a lista";
                return response;
            }
            else {
                response.mensagem = "Lista retornada!";
                return response;
            }

           
        }
    }
}
