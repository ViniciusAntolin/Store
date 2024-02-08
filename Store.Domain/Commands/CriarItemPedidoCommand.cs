using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Commands
{
    public class CriarItemPedidoCommand : Notifiable<Notification>, ICommand
    {
        public CriarItemPedidoCommand() { }

        public CriarItemPedidoCommand(Guid produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
        }

        public Guid Produto { get; set; }
        public int Quantidade { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract<CriarItemPedidoCommand>()
                .Requires()
                .IsLowerThan(Produto.ToString().Length, 32, "Produto", "Produto inválido")
                .IsGreaterThan(Quantidade, 0, "Quantiade", "Quantidade inválida"));
        }
    }
}
