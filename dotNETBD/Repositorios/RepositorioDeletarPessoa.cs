using dotNETBD.Bordas.Repositorio;
using dotNETBD.Context;
using dotNETBD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.Repositorios {
    public class RepositorioDeletarPessoa : IRepositorioDeletarPessoa {

        private readonly LocalDbContext local;

        public RepositorioDeletarPessoa(LocalDbContext local) {
            this.local = local;
        }

        public bool Deletar(Pessoa request) {
            try {
                Pessoa apagarEsse = local.pessoas.Where(d => d.id == request.id).FirstOrDefault();
                local.Remove(apagarEsse);
                local.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }
    }
}
