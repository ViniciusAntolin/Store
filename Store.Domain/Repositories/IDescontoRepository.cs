using Store.Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface IDescontoRepository
    {
        Desconto ObterDesconto(string codigo);
    }
}
