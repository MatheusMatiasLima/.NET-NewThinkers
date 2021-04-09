using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNETBD.Entities;

namespace dotNETBD.Services
{
    public interface IPessoaServices {
        bool AdicionarPessoa(Pessoa pessoa);
        List<Pessoa> RetornarListaDePessoas();
        Pessoa RetornarPessoaPorID(int id);
        bool AtualizarPessoa(Pessoa novaPessoa);
        bool DeletarPessoa(int id);

    }
}
