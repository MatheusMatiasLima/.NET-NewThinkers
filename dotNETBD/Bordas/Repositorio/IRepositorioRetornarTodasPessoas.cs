﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETBD.Bordas.Repositorio {
    public interface IRepositorioRetornarTodasPessoas {
        public List<Entities.Pessoa> RetornarTodasPessoas();
    }
}