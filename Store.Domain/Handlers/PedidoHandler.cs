using Flunt.Notifications;
using Store.Domain.Commands;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Handlers.Interfaces;
using Store.Domain.Repositories;
using Store.Domain.Utils;
using System.Transactions;

namespace Store.Domain.Handlers
{
    public class PedidoHandler : Notifiable<Notification>, IHandler<CriarPedidoCommand>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ITaxaEntregaRepository _taxaEntregaRepository;
        private readonly IDescontoRepository _descontoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoHandler(IClienteRepository clienteRepository,
                             ITaxaEntregaRepository taxaEntregaRepository,
                             IDescontoRepository descontoRepository,
                             IProdutoRepository produtoRepository,
                             IPedidoRepository pedidoRepository)
        {
            _clienteRepository = clienteRepository;
            _taxaEntregaRepository = taxaEntregaRepository;
            _descontoRepository = descontoRepository;
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;
        }

        public ICommandResult Handle(CriarPedidoCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new CommandGenericoResult(false, "Pedido Invaldio", command.Notifications);
            
            //1. Recupera o cliente
            var cliente = _clienteRepository.ObterCliente(command.Cliente);

            //2. Calcula a taxa de entrega  
            var taxaEntrega = _taxaEntregaRepository.ObterTaxaEntrega(command.CEP);

            //3. Obtém o cupom de desconto
            var desconto = _descontoRepository.ObterDesconto(command.PromoCode);

            //4. Gera o pedido
            var produtos = _produtoRepository.ObterProdutos(ExtrariGuids.Extrair(command.Items)).ToList();
            var pedido = new Pedido(cliente, taxaEntrega, desconto);
            foreach(var item in command.Items)
            {
                var produto = produtos.Where(x => x.Id == item.Produto).FirstOrDefault();
                pedido.AddItem(produto, item.Quantidade);
            }

            //5. Agrupar as notificações
            AddNotifications(pedido.Notifications);

            //6. Verifica se deu tudo certo
            if(!IsValid)
                return new CommandGenericoResult(false, "Falha ao gerar o pedido", Notifications);

            //7. Retorna o resultado
            _pedidoRepository.SalvarPedido(pedido);

            return new CommandGenericoResult(true, $"Pedido {pedido.Numero} gerado com sucesso", pedido);
        }
    }
}
