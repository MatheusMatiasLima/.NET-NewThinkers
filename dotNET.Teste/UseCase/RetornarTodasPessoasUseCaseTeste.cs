using dotNETBD.Bordas.Repositorio;
using dotNETBD.DTO.Pessoa.RetornarTodasPessoas;
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
    public class RetornarTodasPessoasUseCaseTeste {
        private readonly RetornarTodasPessoasUseCase useCase;
        private readonly Mock<IRepositorioRetornarTodasPessoas> repositorio;


        public RetornarTodasPessoasUseCaseTeste() {
            repositorio = new Mock<IRepositorioRetornarTodasPessoas>();
            useCase = new RetornarTodasPessoasUseCase(repositorio.Object);
        }

        [Fact]
        public void RetornarSucesso() {
            var response = new RetornarTodasPessoasResponse();
            response.mensagem = "Lista retornada!";

            List<Pessoa> lista = new();
            Pessoa pessoa = new();
            pessoa.id = 1;
            lista.Add(pessoa);

            response.lista = lista;

            repositorio.Setup(repositorio => repositorio.RetornarTodasPessoas()).Returns(response);

            var result = useCase.Executar();
            response.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void RetornarErro() {
            var response = new RetornarTodasPessoasResponse();
            response.mensagem = "Não foi possivel achar a lista";

            List<Pessoa> lista = new();
            Pessoa pessoa = new();
            pessoa.id = -1;
            lista.Add(pessoa);

            response.lista = lista;

            repositorio.Setup(repositorio => repositorio.RetornarTodasPessoas()).Returns(response);

            var result = useCase.Executar();
            response.Should().BeEquivalentTo(result);
        }

    }
}
