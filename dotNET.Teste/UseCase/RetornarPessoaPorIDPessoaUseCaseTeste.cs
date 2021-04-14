using dotNET.Teste.Buider;
using dotNETBD.Adapter;
using dotNETBD.Bordas.Adapter;
using dotNETBD.Bordas.Pessoa.Repositorio;
using dotNETBD.Bordas.Repositorio;
using dotNETBD.DTO.Pessoa.DeletarPessoa;
using dotNETBD.DTO.Pessoa.RetornarPessoaPorID;
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
    public class RetornarPessoaPorIDPessoaUseCaseTeste {

        private readonly Mock <IRepositorioRetornarPessoaPorID> repositorio;
        private readonly Mock<IRetornarPessoaPorIDAdapter> adapter;
        private readonly RetornarPessoaPorIDUseCase useCase;

        public RetornarPessoaPorIDPessoaUseCaseTeste() {
            repositorio = new Mock<IRepositorioRetornarPessoaPorID>();
            adapter = new Mock<IRetornarPessoaPorIDAdapter>();
            useCase = new RetornarPessoaPorIDUseCase(repositorio.Object , adapter.Object); 
        }
        

       [Fact] 
        public void RetornarPessoaSucesso () {
            //Arrange
            int request = 1; //esse id exite
            var response = new RetornarPessoaPorIDResponse();
            response.mensagem = "Pessoa retornada!";
            

            Pessoa pessoa = new Pessoa();
            pessoa.nome = "tanto faz";
            pessoa.cpf = "tanto faz aqui tambem";
            pessoa.id = request; 

            adapter.Setup(adapter => adapter.ConverterPessoaParaResponse(pessoa)).Returns(response);
            repositorio.Setup(repositorio => repositorio.RetornarPessoa(request)).Returns(pessoa);
            

            //Act
            var result = useCase.Executar(request);

            //Assert
            response.Should().BeEquivalentTo(result);

        }

        [Fact]
        public void RetornarPessoaErro() {
            //Arrange
            int request = -9; //esse id nao existe
            var response = new RetornarPessoaPorIDResponse();
            response.mensagem = "Erro ao encontrar pessoa!";


            Pessoa pessoa = new Pessoa();
            pessoa.nome = "tanto faz";
            pessoa.cpf = "tanto faz aqui tambem";
            pessoa.id = request;

            adapter.Setup(adapter => adapter.ConverterPessoaParaResponse(pessoa)).Returns(response);
            repositorio.Setup(repositorio => repositorio.RetornarPessoa(request)).Returns(pessoa);


            //Act
            var result = useCase.Executar(request);

            //Assert
            response.Should().BeEquivalentTo(result);

        }
    }
}
