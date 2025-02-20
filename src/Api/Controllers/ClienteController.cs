using Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;
using Servicos.Servicos;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteServico _clienteServico;
        public ClienteController(ClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
        }

        [HttpGet]
        public OkObjectResult ObterTodos()
        {
            var clientes = _clienteServico.ObterTodos();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public OkObjectResult ObterPorId(int id)
        {
            var cliente = _clienteServico.ObterPorId(id);
            return Ok(cliente);
        }

        [HttpPost]
        public CreatedResult Criar([FromBody] Cliente cliente)
        {
            var novoCliente = _clienteServico.Criar(cliente);
            return Created("Criado com sucesso.", novoCliente.Id);
        }

        [HttpPatch("{id}")]
        public NoContentResult Atualizar(int id, [FromBody] Cliente cliente)
        {
            _clienteServico.Atualizar(id, cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public NoContentResult Remover(int id)
        {
            _clienteServico.Remover(id);
            return NoContent();
        }

    }
}
