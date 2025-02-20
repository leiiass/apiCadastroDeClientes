using Dominio.Modelos;

namespace Dominio.Interfaces
{
    public interface IClienteRepositorio
    {
        List<Cliente> ObterTodos();
        Cliente ObterPorId(int id);
        Cliente Criar(Cliente cliente);
        void Atualizar(int id, Cliente cliente);
        void Remover(int id);
    }
}
