using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.BancoDeDados
{
    public class ClienteContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public ClienteContext(DbContextOptions<ClienteContext>options): base(options) { }
        
    }
}