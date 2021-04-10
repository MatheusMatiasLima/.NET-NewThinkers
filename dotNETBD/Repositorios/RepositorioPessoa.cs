﻿using dotNETBD.Bordas.Pessoa.Repositorio;
using dotNETBD.Context;
using dotNETBD.DTO.Pessoa.AdicionarPessoa;
using dotNETBD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.Repositorios {
    public class RepositorioPessoa : IRepositorioPessoa {

        private readonly LocalDbContext local;

        public RepositorioPessoa(LocalDbContext local) {
            this.local = local;
        }

        public void Add(Pessoa request) {
            //local.pessoas.Add(request);
            local.SaveChanges();
        }
    }
}
