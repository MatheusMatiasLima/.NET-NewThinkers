using dotNETBD.Adapter;
using dotNETBD.Bordas.Adapter;
using dotNETBD.Bordas.Pessoa.Repositorio;
using dotNETBD.Bordas.Pessoa.UseCase;
using dotNETBD.DTO.Pessoa.AdicionarPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.UseCase.Pessoa {
    public class AdicionarPessoaUseCase : IAdicionarPessoaUseCase {

        private readonly IRepositorioPessoaAdd repositorioPessoa;
        private readonly IAdicionarPessoaAdapter adapter;

        public AdicionarPessoaUseCase(IRepositorioPessoaAdd repositorioPessoa , IAdicionarPessoaAdapter adapter) {
            this.repositorioPessoa = repositorioPessoa;
            this.adapter = adapter;
        }

        public AdicionarPessoaResponse Executar(AdicionarPessoaRequest request) {
            AdicionarPessoaResponse response = new();

            try { 
                //tipo Pessoa
                var pessoaAdicionar = adapter.ConverterRequestParaPessoa(request);
                repositorioPessoa.Add(pessoaAdicionar);

                response.mensagem = "Pessoa adicionada!";
                return response;
            }
            catch {
                response.mensagem = "Erro ao adicionar pessoa!";
                return response;
            }
        }
    }
}
