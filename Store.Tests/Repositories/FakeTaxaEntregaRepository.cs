using Store.Domain.Repositories;

namespace Store.Tests.Repositories
{
    internal class FakeTaxaEntregaRepository : ITaxaEntregaRepository
    {
        public decimal ObterTaxaEntrega(string CEP)
        {
            if(CEP == "12345678")
                return 10;
            return 5;
        }
    }
}
