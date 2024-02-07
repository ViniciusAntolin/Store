using Store.Domain.Repositories;
using Store.Store.Domain.Entities;

namespace Store.Tests.Repositories
{
    public class FakeClienteRepository : IClienteRepository
    {
        public Cliente ObterCliente(string documento)
        {
            if (documento == "12345678911")
                return new Cliente("Bruce Wayne", "batman@balta.io");

            return null;
        }
    }
}
