using Flunt.Validations;
using Store.Store.Domain.Entities;
using Store.Store.Domain.Enums;

namespace Store.Domain.Entities
{
    public class Pedido : Entidade
    {
        public Pedido(Cliente cliente, decimal taxaEntrega, Desconto desconto)
        {
            AddNotifications(
                new Contract<Pedido>()
                .Requires()
                .IsNotNull(cliente, "Cliente", "O Cliente está invalido."));

            Cliente = cliente;
            Data = DateTime.Now;
            Numero = Guid.NewGuid().ToString().Substring(0, 8);
            Status = EStatusPedido.AguardandoPagamento;
            TaxaEntrega = taxaEntrega;
            Desconto = desconto;
            Items = new List<ItemPedido>();
        }

        public Cliente Cliente { get; private set; }
        public DateTime Data { get; private set; }
        public string Numero { get; private set; }
        public IList<ItemPedido> Items { get; private set; }
        public decimal TaxaEntrega { get; private set; }
        public Desconto Desconto { get; private set; }
        public EStatusPedido Status { get; private set; }

        public void AddItem(Produto produto, int quantidade)
        {
            var item = new ItemPedido(produto, quantidade);
            if (item.IsValid)
                Items.Add(item);
            AddNotifications(item);
        }

        public decimal Total()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Total();
            }

            total += TaxaEntrega;
            total -= Desconto != null ? Desconto.Valor() : 0;

            return total;
        }

        public void Pago(decimal amount)
        {
            if (amount == Total())
                Status = EStatusPedido.AguardandoEntrega;
        }

        public void Cancelar()
        {
            Status = EStatusPedido.Cancelado;
        }
    }
}