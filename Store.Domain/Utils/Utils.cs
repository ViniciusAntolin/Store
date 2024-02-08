using Store.Domain.Commands;

namespace Store.Domain.Utils
{
    public static class ExtrariGuids
    {
        public static IEnumerable<Guid> Extrair(IList<CriarItemPedidoCommand> items)
        {
            var guid = new List<Guid>();
            foreach (var item in items)
                guid.Add(item.Produto);

            return guid;
        }
    }
}
