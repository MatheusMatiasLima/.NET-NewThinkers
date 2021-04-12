using dotNETBD.Bordas.Repositorio;
using dotNETBD.Context;
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

        public List<Pessoa> RetornarTodasPessoas() {
            return local.pessoas.ToList();
        }
    }
}
