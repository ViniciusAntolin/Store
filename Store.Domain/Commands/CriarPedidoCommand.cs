using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Commands
{
    public class CriarPedidoCommand : Notifiable<Notification>, ICommand
    {
        public CriarPedidoCommand() => Items = new List<CriarItemPedidoCommand>();

        public CriarPedidoCommand(string cliente, string cEP, string promoCode, List<CriarItemPedidoCommand> items)
        {
            Cliente = cliente;
            CEP = cEP;
            PromoCode = promoCode;
            Items = items;
        }

        public string Cliente { get; set; }
        public string CEP { get; set; }
        public string PromoCode { get; set; }
        public List<CriarItemPedidoCommand> Items { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<CriarPedidoCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(Cliente.Length, 11, "Cliente", "Cliente inválido")
                .IsGreaterOrEqualsThan(CEP.Length, 8, "CEP", "CEP inválido"));
        }
    }
}
