using Dominio.Interfaces;
using Dominio.Modelos;
using Dominio.Validadores;

namespace Servicos.Servicos
{
    public class ClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly ClienteValidador _clienteValidador;
        public ClienteServico(IClienteRepositorio clienteRepositorio, ClienteValidador clienteValidador)
        {
            _clienteRepositorio = clienteRepositorio;
            _clienteValidador = clienteValidador;
        }

        public List<Cliente> ObterTodos()
        {
            return _clienteRepositorio.ObterTodos();
        }

        public Cliente ObterPorId(int id)
        {
            return _clienteRepositorio.ObterPorId(id);
        }

        public Cliente Criar(Cliente cliente)
        {
            _clienteValidador.Validate(cliente);
            return _clienteRepositorio.Criar(cliente);
        }

        public void Atualizar(int id, Cliente cliente)
        {
            _clienteValidador.Validate(cliente);
            _clienteRepositorio.Atualizar(id, cliente);
        }

        public void Remover(int id)
        {
            _clienteRepositorio.Remover(id);
        }
    }
}
