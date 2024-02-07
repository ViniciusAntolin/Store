using Store.Store.Domain.Entities;
using System.Linq.Expressions;

namespace Store.Domain.Queries
{
    public static class ProdutoQueries
    {
        public static Expression<Func<Produto, bool>> ObterProdutosAtivos() => x => x.Ativo == true;
        public static Expression<Func<Produto, bool>> ObterProdutosInativos() => x => x.Ativo == false;
    }
}
