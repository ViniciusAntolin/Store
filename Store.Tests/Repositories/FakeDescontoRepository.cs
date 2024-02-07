using Store.Domain.Repositories;
using Store.Store.Domain.Entities;

namespace Store.Tests.Repositories
{
    internal class FakeDescontoRepository : IDescontoRepository
    {
        public Desconto ObterDesconto(string codigo)
        {
            if (codigo == "12345678")
                return new Desconto(10, DateTime.Now.AddDays(5));
            
            if (codigo == "11111111")
                return new Desconto(10, DateTime.Now.AddDays(-5));

            return null;
        }
    }
}
