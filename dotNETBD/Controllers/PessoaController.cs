using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNETBD.Services;
using dotNETBD.Entities;
using dotNETBD.Bordas.Pessoa.UseCase;
using dotNETBD.DTO.Pessoa.AdicionarPessoa;
using dotNETBD.UseCase.Pessoa;
using dotNETBD.DTO.Pessoa.AtualizarPessoa;
using dotNETBD.DTO.Pessoa.DeletarPessoa;
using dotNETBD.DTO.Pessoa.RetornarPessoaPorID;

namespace dotNETBD.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PessoaController : Controller {

        private readonly ILogger<PessoaController> logger;
        private readonly IPessoaServices pessoa;
        private readonly IAdicionarPessoaUseCase adicionarPessoaUseCase;
        private readonly IAtualizarPessoaUseCase atualizarPessoaUseCase;
        private readonly IDeletarPessoaUseCase deletarPessoaUseCase;
        private readonly IRetornarPessoaPorIDUseCase retornarPessoaIDUseCase;
        private readonly IRetornarTodasPessoasUseCase retornarTodasPessoasUseCase;

        public PessoaController(ILogger<PessoaController> logger , IPessoaServices pessoa ,
                                IAdicionarPessoaUseCase adicionarPessoa,
                                IAtualizarPessoaUseCase atualizarPessoa,
                                IDeletarPessoaUseCase deletarPessoa,
                                IRetornarPessoaPorIDUseCase retornarPessoaID,
                                IRetornarTodasPessoasUseCase retornarTodasPessoas) {
                   
            this.logger = logger;
            this.pessoa = pessoa;
            this.adicionarPessoaUseCase = adicionarPessoa;
            this.atualizarPessoaUseCase = atualizarPessoa;
            this.deletarPessoaUseCase = deletarPessoa;
            this.retornarPessoaIDUseCase = retornarPessoaID;
            this.retornarTodasPessoasUseCase = retornarTodasPessoas;


        }

        [HttpGet]
        public IActionResult TodasAsPessoas() {
            var response = retornarTodasPessoasUseCase.Executar();
            return Ok(response.lista);
            //return Ok(pessoa.RetornarListaDePessoas());
        }

        [HttpGet("{id}")]
        public IActionResult RetornarPessoa(int id) {
            return Ok(retornarPessoaIDUseCase.Executar(id));
            //return Ok(pessoa.RetornarPessoaPorID(id));
        }

        [HttpPost]
        public IActionResult AdicionarPessoa([FromBody] AdicionarPessoaRequest novaPessoa) {
            try  {
                return Ok(adicionarPessoaUseCase.Executar(novaPessoa));
            }
            catch (Exception e) {
                return Ok("Erro: " + e);
            }
        }

        [HttpPut]
        public IActionResult AtualizarPessoa([FromBody] AtualizarPessoaRequest novaPessoa) {
            return Ok(atualizarPessoaUseCase.Executar(novaPessoa));
            //return Ok(pessoa.AtualizarPessoa(novaPessoa));
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPessoa(int deletarPessoa) {
            return Ok(deletarPessoaUseCase.Executar(deletarPessoa));
            //return Ok(pessoa.DeletarPessoa(id));
        }
    }
}
