using Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface IPedidoRepository
    {
        void SalvarPedido(Pedido pedido);
    }
}
