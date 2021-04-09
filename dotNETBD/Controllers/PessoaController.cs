using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNETBD.Services;
using dotNETBD.Entities;

namespace dotNETBD.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PessoaController : Controller {

        private readonly ILogger<PessoaController> logger;
        private readonly IPessoaServices pessoa;

        public PessoaController(ILogger<PessoaController> logger , IPessoaServices pessoa) {
            this.logger = logger;
            this.pessoa = pessoa;
        }

        [HttpGet]
        public IActionResult TodasAsPessoas() {
            return Ok(pessoa.RetornarListaDePessoas());
        }

        [HttpGet("{id}")]
        public IActionResult RetornarPessoa(int id) {
            return Ok(pessoa.RetornarPessoaPorID(id));
        }

        [HttpPost]
        public IActionResult AdicionarPessoa([FromBody] Pessoa novaPessoa) {
            return Ok(pessoa.AdicionarPessoa(novaPessoa));
        }

        [HttpPut]
        public IActionResult AtualizarPessoa([FromBody] Pessoa novaPessoa) {
            return Ok(pessoa.AtualizarPessoa(novaPessoa));
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPessoa(int id) {
            return Ok(pessoa.DeletarPessoa(id));
        }


    }
}
