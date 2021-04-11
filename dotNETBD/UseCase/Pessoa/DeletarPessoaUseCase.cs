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


        public DeletarPessoaResponse Executar(DeletarPessoaRequest request) {
            DeletarPessoaResponse response = new ();

            try {
                var pessoaDeletar = adapter.ConverterRequestParaPessoa(request);

                repositorio.Deletar(pessoaDeletar);
                response.mensagem = "Pessoa deletada com sucesso!";
                return response;
            }
            catch {
                response.mensagem = "Erro ao deletar a pessoa!";
                return response;
            }

        }
    }
}
