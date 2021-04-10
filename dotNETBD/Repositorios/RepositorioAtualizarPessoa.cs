using dotNETBD.Bordas.Adapter;
using dotNETBD.Bordas.Repositorio;
using dotNETBD.Context;
using dotNETBD.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.Repositorios {
    public class RepositorioAtualizarPessoa : IRepositorioAtualizarPessoa {

        private readonly LocalDbContext local;

        public RepositorioAtualizarPessoa(LocalDbContext local) {
            this.local = local;
        }

        public bool Atualizar(Pessoa request) {
            try { 
                local.pessoas.Attach(request);
                local.Entry(request).State = EntityState.Modified;
                local.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }

    }
}
