using dotNET.Teste.Buider;
using dotNETBD.Adapter;
using dotNETBD.Bordas.Adapter;
using dotNETBD.Bordas.Pessoa.Repositorio;
using dotNETBD.Bordas.Repositorio;
using dotNETBD.DTO.Pessoa.AdicionarPessoa;
using dotNETBD.DTO.Pessoa.DeletarPessoa;
using dotNETBD.Entities;
using dotNETBD.UseCase.Pessoa;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace dotNET.Teste.UseCase {
    public class DeletarPessoaUseCaseTeste {

        private readonly Mock <IRepositorioDeletarPessoa> repositorio;
        private readonly Mock<IDeletarPessoaAdapter> adapter;
        private readonly DeletarPessoaUseCase useCase;

        public DeletarPessoaUseCaseTeste() {
            repositorio = new Mock<IRepositorioDeletarPessoa>();
            adapter = new Mock<IDeletarPessoaAdapter>();
            useCase = new DeletarPessoaUseCase(adapter.Object , repositorio.Object); 
        }

        [Fact] 
        public void DeletarPessoaSucesso () {
            //Arrange
            int request = 1; //esse id exite
            var response = new DeletarPessoaResponse();
            response.mensagem = "Pessoa deletada com sucesso!";
            

            Pessoa pessoa = new Pessoa();
            pessoa.nome = "tanto faz";
            pessoa.cpf = "tanto faz aqui tambem";
            pessoa.id = request; 

            adapter.Setup(adapter => adapter.ConverterRequestParaPessoa(request)).Returns(pessoa);
            repositorio.Setup(repositorio => repositorio.Deletar(pessoa)).Returns(false);
            

            //Act
            var result = useCase.Executar(request);

            //Assert
            response.Should().BeEquivalentTo(result);

        }


        [Fact]
        public void DeletarPessoaErro() {
            //Arrange
            int request = -1; //um id que nao existe
            var response = new DeletarPessoaResponse();
            response.mensagem = "Erro ao deletar a pessoa!";


            Pessoa pessoa = new Pessoa();
            pessoa.nome = "tanto faz";
            pessoa.cpf = "tanto faz aqui tambem";
            pessoa.id = request;

            adapter.Setup(adapter => adapter.ConverterRequestParaPessoa(request)).Returns(pessoa);
            repositorio.Setup(repositorio => repositorio.Deletar(pessoa)).Returns(true);


            //Act
            var result = useCase.Executar(request);

            //Assert
            response.Should().BeEquivalentTo(result);

        }
    }
}
