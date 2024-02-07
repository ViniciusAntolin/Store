using Store.Domain.Repositories;
using Store.Store.Domain.Entities;

namespace Store.Tests.Repositories
{
    internal class FakeProdutoRepository : IProdutoRepository
    {
        public IEnumerable<Produto> ObterProdutos(IEnumerable<Guid> ids)
        {
            IList<Produto> produtos = new List<Produto>
            {
                new Produto("Produto 1", 10, true),
                new Produto("Produto 2", 20, true),
                new Produto("Produto 3", 30, true),
                new Produto("Produto 4", 40, true),
                new Produto("Produto 5", 50, false),
                new Produto("Produto 6", 60, false)
            };

            return produtos;
        }
    }
}
