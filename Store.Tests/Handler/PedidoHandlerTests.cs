using Store.Domain.Commands;
using Store.Domain.Handlers;
using Store.Domain.Repositories;
using Store.Tests.Repositories;

namespace Store.Tests.Handler
{
    [TestClass]
    public class PedidoHandlerTests
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ITaxaEntregaRepository _taxaEntregaRepository;
        private readonly IDescontoRepository _descontoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoHandlerTests()
        {
            _clienteRepository = new FakeClienteRepository();
            _taxaEntregaRepository = new FakeTaxaEntregaRepository();
            _descontoRepository = new FakeDescontoRepository();
            _produtoRepository = new FakeProdutoRepository();
            _pedidoRepository = new FakePedidoRepository();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_cliente_inexistente_o_pedido_nao_deve_ser_gerado()
        {
            var command = new CriarPedidoCommand
            {
                Cliente = "",
                CEP = "13411080",
                PromoCode = ""
            };
            command.Items.Add(new CriarItemPedidoCommand(Guid.NewGuid(), 10));
            command.Items.Add(new CriarItemPedidoCommand(Guid.NewGuid(), 20));

            var handler = new PedidoHandler(_clienteRepository, _taxaEntregaRepository, _descontoRepository, _produtoRepository, _pedidoRepository);
            CommandGenericoResult result = (CommandGenericoResult)handler.Handle(command);

            Assert.IsFalse(result.Sucesso);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_cep_invalido_o_pedido_deve_ser_gerado_normalmente()
        {
            var command = new CriarPedidoCommand
            {
                Cliente = "12345678911",
                CEP = "",
                PromoCode = ""
            };
            command.Items.Add(new CriarItemPedidoCommand(Guid.NewGuid(), 10));
            command.Items.Add(new CriarItemPedidoCommand(Guid.NewGuid(), 20));

            var handler = new PedidoHandler(_clienteRepository, _taxaEntregaRepository, _descontoRepository, _produtoRepository, _pedidoRepository);
            handler.Handle(command);

            Assert.IsTrue(handler.IsValid);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_promocode_inexistente_o_pedido_deve_ser_gerado_normalmente()
        {
            var command = new CriarPedidoCommand
            {
                Cliente = "12345678911",
                CEP = "13411080",
                PromoCode = ""
            };
            command.Items.Add(new CriarItemPedidoCommand(Guid.NewGuid(), 10));
            command.Items.Add(new CriarItemPedidoCommand(Guid.NewGuid(), 20));

            var handler = new PedidoHandler(_clienteRepository, _taxaEntregaRepository, _descontoRepository, _produtoRepository, _pedidoRepository);
            handler.Handle(command);

            Assert.IsTrue(handler.IsValid);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_pedido_sem_items_o_mesmo_nao_deve_ser_gerado()
        {
            var command = new CriarPedidoCommand
            {
                Cliente = "12345678911",
                CEP = "13411080",
                PromoCode = "12345678"
            };

            var handler = new PedidoHandler(_clienteRepository, _taxaEntregaRepository, _descontoRepository, _produtoRepository, _pedidoRepository);
            CommandGenericoResult result = (CommandGenericoResult)handler.Handle(command);

            Assert.IsFalse(result.Sucesso);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_comando_invalido_o_pedido_nao_deve_ser_gerado()
        {
            var command = new CriarPedidoCommand
            {
                Cliente = "",
                CEP = "13411080",
                PromoCode = "12345678"
            };
            command.Items.Add(new CriarItemPedidoCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CriarItemPedidoCommand(Guid.NewGuid(), 1));
            
            var handler = new PedidoHandler(_clienteRepository, _taxaEntregaRepository, _descontoRepository, _produtoRepository, _pedidoRepository);
            handler.Handle(command);
            
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dadod_um_comando_valido_o_pedido_deve_ser_gerado()
        {
            var command = new CriarPedidoCommand
            {
                Cliente = "12345678911",
                CEP = "13411080",
                PromoCode = "12345678"
            };
            command.Items.Add(new CriarItemPedidoCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CriarItemPedidoCommand(Guid.NewGuid(), 1));

            var handler = new PedidoHandler(_clienteRepository, _taxaEntregaRepository, _descontoRepository, _produtoRepository, _pedidoRepository);
            handler.Handle(command);

            Assert.IsTrue(handler.IsValid);
        }
    }
}
