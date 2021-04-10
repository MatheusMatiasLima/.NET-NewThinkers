using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNETBD.Entities;
using dotNETBD.Context;
using Microsoft.EntityFrameworkCore;

namespace dotNETBD.Services
{
    public class PessoaServices : IPessoaServices {

        private readonly LocalDbContext local;

        public PessoaServices(LocalDbContext local) {
            this.local = local;
        }

        public bool AdicionarPessoa(Pessoa pessoa) {
            local.pessoas.Add(pessoa);
            local.SaveChanges();
            return true;
        }

        public bool AtualizarPessoa(Pessoa novaPessoa) {
            try {
                local.pessoas.Attach(novaPessoa);
                local.Entry(novaPessoa).State = EntityState.Modified;
                local.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }

        public bool DeletarPessoa(int id) {
            Pessoa apagarEsse = local.pessoas.Where(d => d.id == id).FirstOrDefault();
            local.Remove(apagarEsse);
            local.SaveChanges();
            return true;
        }

        public List<Pessoa> RetornarListaDePessoas() {
            return local.pessoas.ToList();
        }

        public Pessoa RetornarPessoaPorID(int id) {
            return local.pessoas.Where(d => d.id == id).FirstOrDefault();
        }
    }
}
