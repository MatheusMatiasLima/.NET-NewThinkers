using dotNETBD.Bordas.Adapter;
using dotNETBD.Bordas.Pessoa.UseCase;
using dotNETBD.Bordas.Repositorio;
using dotNETBD.DTO.Pessoa.AtualizarPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.UseCase.Pessoa {
    public class AtualizarPessoaUseCase : IAtualizarPessoaUseCase {
        //Preciso do adapter para converter o request em pessoa
        private readonly IAtualizarPessoaAdapter adapter;
        //O repositorio executa a tarefa
        private readonly IRepositorioAtualizarPessoa repositorio;

        public AtualizarPessoaUseCase(IAtualizarPessoaAdapter adapter , IRepositorioAtualizarPessoa repositorio) {

            this.adapter = adapter;
            this.repositorio = repositorio;
        }



        public AtualizarPessoaResponse Executar(AtualizarPessoaRequest request) {
            //o retorno do metodo com a mensagem se deu certo ou não
            AtualizarPessoaResponse response = new();

            try { 
                var pessoaAtualizar = adapter.ConverterRequestParaPessoa(request);
                repositorio.Atualizar(pessoaAtualizar);
                response.mensagem = "Pessoa Atualizada!";
                return response;
            }
            catch {
                response.mensagem = "Erro ao atualizar pessoa!";
                return response;
            }
        }
    }
}
