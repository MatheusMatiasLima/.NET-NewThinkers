using dotNETBD.Bordas.Adapter;
using dotNETBD.Bordas.Pessoa.UseCase;
using dotNETBD.Bordas.Repositorio;
using dotNETBD.DTO.Pessoa.DeletarPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.UseCase.Pessoa {
    public class DeletarPessoaUseCase : IDeletarPessoaUseCase {

        private readonly IDeletarPessoaAdapter adapter;
        private readonly IRepositorioDeletarPessoa repositorio;

        public DeletarPessoaUseCase(IDeletarPessoaAdapter adapter , IRepositorioDeletarPessoa repositorio) {
            this.adapter = adapter;
            this.repositorio = repositorio;
        }


        public DeletarPessoaResponse Executar(int request) {
            DeletarPessoaResponse response = new ();

            var pessoaDeletar = adapter.ConverterRequestParaPessoa(request);

            bool falhou = repositorio.Deletar(pessoaDeletar);

            if (falhou) { 
                response.mensagem = "Erro ao deletar a pessoa!";
                return response;
            }
            else {
                response.mensagem = "Pessoa deletada com sucesso!"; 
                return response;
            }
        }
    }
}