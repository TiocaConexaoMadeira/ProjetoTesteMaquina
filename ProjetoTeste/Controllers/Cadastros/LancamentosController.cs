using Microsoft.AspNetCore.Mvc;
using ProjetoTeste.Infra.Database;
using ProjetoTeste.Model.Cadastro;
using ProjetoTeste.Repositories.Cadastros;
using System;

namespace ProjetoTeste.Controllers.Cadastros
{
    [ApiController]
    [Route("api/[controller]")]
    public class LancamentosController : ControllerBase
    {
        private readonly LancamentosRepository _repository;

        public LancamentosController(LancamentosRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Cadastro de Lançamentos
        /// </summary>
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] Lancamento lancamento)
        {
            try
            {
                var novoLancamento = await _repository.Cadastrar(lancamento);
                return CreatedAtAction(nameof(Cadastrar), new { id = novoLancamento.Codigo }, novoLancamento);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { erro = ex.Message });
            }
        }

        /// <summary>
        /// Consulta dos Lançamentos
        /// </summary>
        [HttpGet("todos")]
        public async Task<IActionResult> ConsultarTodos()
        {
            var lancamentos = await _repository.ConsultarTodos();
            return Ok(lancamentos);
        }

        /// <summary>
        /// Consulta de Lançamento por código
        /// </summary>
        [HttpGet("{codigo}")]
        public async Task<IActionResult> ConsultarPorCodigo(int codigo)
        {
            var lancamento = await _repository.ConsultarPorCodigo(codigo);
            if (lancamento == null)
                return NotFound("Lançamento não encontrado.");

            return Ok(lancamento);
        }
    }
}
