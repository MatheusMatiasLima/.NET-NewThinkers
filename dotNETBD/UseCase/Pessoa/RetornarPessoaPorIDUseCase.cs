using dotNETBD.Bordas.Adapter;
using dotNETBD.Bordas.Pessoa.UseCase;
using dotNETBD.Bordas.Repositorio;
using dotNETBD.DTO.Pessoa.RetornarPessoaPorID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.UseCase.Pessoa {
    public class RetornarPessoaPorIDUseCase : IRetornarPessoaPorIDUseCase {

        private readonly IRepositorioRetornarPessoaPorID repositorio;
        private readonly IRetornarPessoaPorIDAdapter adapter;

        public RetornarPessoaPorIDUseCase(IRepositorioRetornarPessoaPorID repositorio , IRetornarPessoaPorIDAdapter adapter) {
            this.repositorio = repositorio;
            this.adapter = adapter;
        }



        //Meu request ja tem um int
        public RetornarPessoaPorIDResponse Executar(RetornarPessoaPorIDRequest request) {
            RetornarPessoaPorIDResponse response = new();

            try {
                response = adapter.ConverterPessoaParaResponse(repositorio.RetornarPessoa(request.id));
                //response.mensagem = "Pessoa retornada!";
                return response;
            }
            catch {
                //response.mensagem = "Erro ao encontrar pessoa!";
                return response;
            }
        }
    }
}
