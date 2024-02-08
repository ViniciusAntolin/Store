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
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_cep_invalido_o_pedido_deve_ser_gerado_normalmente()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_promocode_inexistente_o_pedido_deve_ser_gerado_normalmente()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_pedido_sem_items_o_mesmo_nao_deve_ser_gerado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_comando_invalido_o_pedido_nao_deve_ser_gerado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dadod_um_comando_valido_o_pedido_deve_ser_gerado()
        {
            Assert.Fail();
        }
    }
}
