using Dominio.Interfaces;
using Dominio.Modelos;
using Infraestrutura.BancoDeDados;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ClienteContext _clienteContext;
        public ClienteRepositorio(ClienteContext clienteContext)
        {
            _clienteContext = clienteContext;
        }

        public List<Cliente> ObterTodos()
        {
            return _clienteContext.Clientes.ToList();
        }

        public Cliente ObterPorId(int id)
        {
            return _clienteContext.Clientes.Find(id);
        }

        public Cliente Criar(Cliente cliente)
        {
            var novoCliente = _clienteContext.Add(cliente);
            _clienteContext.SaveChanges();

            return novoCliente.Entity;
        }

        public void Atualizar(int id, Cliente cliente)
        {
            var clienteAhSerAtualizado = _clienteContext.Clientes
                .Where(x => x.Id == id)
                .FirstOrDefault() ?? throw new Exception($"Cliente não encontrado com Id {id}. ");

            clienteAhSerAtualizado.Nome = cliente.Nome;
            clienteAhSerAtualizado.Sobrenome = cliente.Sobrenome;
            clienteAhSerAtualizado.CPF = cliente.CPF;
            clienteAhSerAtualizado.Telefone = cliente.Telefone;
            clienteAhSerAtualizado.Endereco = cliente.Endereco; 
            clienteAhSerAtualizado.Nacionalidade = cliente.Nacionalidade;
            clienteAhSerAtualizado.Genero = cliente.Genero;
            clienteAhSerAtualizado.Idade = cliente.Idade;

            _clienteContext
                .Entry(clienteAhSerAtualizado).State = EntityState.Modified;

            _clienteContext
                .SaveChanges();
        }

        public void Remover(int id)
        {
            var clienteAhSerRemovido = _clienteContext.Clientes
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (clienteAhSerRemovido is null)
            {
                throw new Exception($"Cliente não encontrado com Id {id}.");
            }

            _clienteContext
                .Remove(clienteAhSerRemovido);

            _clienteContext.SaveChanges();
        }
    }
}
