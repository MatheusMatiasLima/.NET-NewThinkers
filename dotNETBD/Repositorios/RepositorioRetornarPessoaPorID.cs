using dotNETBD.Bordas.Repositorio;
using dotNETBD.Context;
using dotNETBD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.Repositorios {
    public class RepositorioRetornarPessoaPorID : IRepositorioRetornarPessoaPorID {

        private readonly LocalDbContext local;

        public RepositorioRetornarPessoaPorID(LocalDbContext local) {
            this.local = local;
        }
        //Retorna a pessoa do ID selecionado
        public Pessoa RetornarPessoa (int id) {
            try { 
                return local.pessoas.Where(d => d.id == id).FirstOrDefault();
            }
            catch {
                Pessoa naoAchou = new ();
                naoAchou.id = -1;
                return naoAchou;
            }

        }

    }
}
