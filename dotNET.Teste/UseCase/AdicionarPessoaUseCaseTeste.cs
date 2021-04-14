using dotNET.Teste.Buider;
using dotNETBD.Bordas.Adapter;
using dotNETBD.Bordas.Pessoa.Repositorio;
using dotNETBD.DTO.Pessoa.AdicionarPessoa;
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
    public class AdicionarPessoaUseCaseTeste {

        private readonly Mock <IRepositorioPessoaAdd> repositorio;
        private readonly Mock<IAdicionarPessoaAdapter> adapter;
        private readonly AdicionarPessoaUseCase useCase;

        public AdicionarPessoaUseCaseTeste () {
            repositorio = new Mock<IRepositorioPessoaAdd>();
            adapter = new Mock<IAdicionarPessoaAdapter>();
            useCase = new AdicionarPessoaUseCase(repositorio.Object , adapter.Object);
        }

        [Fact] 
        public void AddPessoaSucesso () {
            //Arrange
            var response = new AdicionarPessoaResponse();
            response.mensagem = "Pessoa adicionada!";

            var request = new AdicionarPessoaRequest();
            request.nome = GerarPessoa.NomeQueExiste();
            request.cpf = GerarPessoa.GerarCpf();

            Pessoa pessoa = new Pessoa();
            pessoa.nome = request.nome;
            pessoa.cpf = request.cpf;
            pessoa.id = 100;

            repositorio.Setup(repositorio => repositorio.Add(pessoa));
            adapter.Setup(adapter => adapter.ConverterRequestParaPessoa(request)).Returns(pessoa);

            //Act
            var result = useCase.Executar(request);

            //Assert
            response.Should().BeEquivalentTo(result);

        }

        [Fact]
        public void AddPessoaCpfInvalido() {
            //Arrange
            var response = new AdicionarPessoaResponse();
            response.mensagem = "Erro ao adicionar pessoa";

            var request = new AdicionarPessoaRequest();
            request.nome = GerarPessoa.NomeQueExiste();
            request.cpf = "CPF invalido";

            Pessoa pessoa = new Pessoa();
            pessoa.nome = request.nome;
            pessoa.cpf = request.cpf;
            pessoa.id = 100;

            adapter.Setup(adapter => adapter.ConverterRequestParaPessoa(request)).Returns(pessoa);
            //repositorio.Setup(repositorio => repositorio.Add(pessoa));
            

            //Act
            var result = useCase.Executar(request);

            //Assert
            response.Should().BeEquivalentTo(result);

        }


        [Fact]
        public void AddPessoaNomeInvalido() {
            //Arrange
            var response = new AdicionarPessoaResponse();
            response.mensagem = "Erro ao adicionar pessoa";

            var request = new AdicionarPessoaRequest();

            request.nome = ""; //nome com tamanho 0 não pode ò-ó
            request.cpf = GerarPessoa.GerarCpf();

            Pessoa pessoa = new Pessoa();
            pessoa.nome = request.nome;
            pessoa.cpf = request.cpf;
            pessoa.id = 100;

            adapter.Setup(adapter => adapter.ConverterRequestParaPessoa(request)).Returns(pessoa);
            //repositorio.Setup(repositorio => repositorio.Add(pessoa));


            //Act
            var result = useCase.Executar(request);

            //Assert
            response.Should().BeEquivalentTo(result);

        }

    }
}
