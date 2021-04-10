using dotNETBD.DTO.Pessoa.AdicionarPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNETBD.Entities;

namespace dotNETBD.Bordas.Pessoa.Repositorio {
    public interface IRepositorioPessoaAdd {
        public void Add(Entities.Pessoa request);
    }
}
