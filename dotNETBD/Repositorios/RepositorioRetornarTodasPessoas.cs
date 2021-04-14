using dotNETBD.Bordas.Repositorio;
using dotNETBD.Context;
using dotNETBD.DTO.Pessoa.RetornarTodasPessoas;
using dotNETBD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.Repositorios {
    public class RepositorioRetornarTodasPessoas : IRepositorioRetornarTodasPessoas {

        private readonly LocalDbContext local;

        public RepositorioRetornarTodasPessoas(LocalDbContext local) {
            this.local = local;
        }

        public RetornarTodasPessoasResponse RetornarTodasPessoas() {
            RetornarTodasPessoasResponse response = new();
            try {
                response.lista = local.pessoas.ToList();
                return response;
            }
            catch {
                List<Pessoa> lista = new();
                Pessoa pessoa = new();
                pessoa.id = -1;
                lista.Add(pessoa);
                response.lista = lista;
                
                return response;
            }
        }
    }
}
