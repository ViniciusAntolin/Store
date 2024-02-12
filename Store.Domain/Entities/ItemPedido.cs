using Flunt.Validations;

namespace Store.Store.Domain.Entities
{
    public class ItemPedido : Entidade
    {
        public ItemPedido(Produto produto, int quantidade)
        {
            AddNotifications(
                new Contract<ItemPedido>()
                .Requires()
                .IsNotNull(produto, "ItemPedido.produto", "Produto invalido.")
                .IsGreaterThan(quantidade, 0, "ItemPedido.quantidade", "A quantidade deve ser maior que 0."));

            Produto = produto;
            Preco = produto != null ? produto.Preco : 0;
            Quantidade = quantidade;
        }

        public Produto Produto { get; private set; }
        public decimal Preco { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Total()
        {
            return Preco * Quantidade;
        }
    }
}
