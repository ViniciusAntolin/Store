using Store.Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> ObterProdutos(IEnumerable<Guid> ids);
    }
}
