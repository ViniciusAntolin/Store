using Store.Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface IClienteRepository
    {
        Cliente ObterCliente(string documento);
    }
}
