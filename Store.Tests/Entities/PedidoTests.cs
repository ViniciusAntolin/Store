using Store.Domain.Entities;
using Store.Store.Domain.Entities;
using Store.Store.Domain.Enums;

namespace Store.Tests.Entities
{
    [TestClass]
    public class PedidoTests
    {
        private readonly Cliente _cliente = new("Vinicius", "viniciusteste@gmail.com");
        private readonly Desconto _desconto = new(2, DateTime.Now.AddMonths(2));
        private readonly Produto _produto = new("Produto Teste", 10, true);

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
        {
            var pedido = new Pedido(_cliente, 2, desconto: _desconto);

            Assert.AreEqual(8, pedido.Numero.Length);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
        {
            var pedido = new Pedido(_cliente, 2, desconto: _desconto);

            Assert.AreEqual(EStatusPedido.AguardandoPagamento, pedido.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pagamento_do_pedido_seu_status_deve_ser_aguardando_entrega()
        {
            var pedido = new Pedido(_cliente, 2, desconto: _desconto);
            pedido.AddItem(_produto, 1);
            pedido.Pago(10m);
            Assert.AreEqual(EStatusPedido.AguardandoEntrega, pedido.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_cancelado_seu_status_deve_ser_cancelado()
        {
            var pedido = new Pedido(_cliente, 2, desconto: _desconto);
            pedido.Cancelar();
            Assert.AreEqual(EStatusPedido.Cancelado, pedido.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_sem_produto_o_mesmo_nao_deve_ser_adicionado()
        {
            var pedido = new Pedido(_cliente, 2, desconto: _desconto);
            pedido.AddItem(produto: null, 10);
            Assert.AreEqual(0, pedido.Items.Count);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_com_quantidade_zero_ou_menor_o_mesmo_nao_deve_ser_adicionado()
        {
            var pedido = new Pedido(_cliente, 2, desconto: _desconto);
            pedido.AddItem(_produto, 0);
            Assert.AreEqual(0, pedido.Items.Count);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_seu_total_deve_ser_50()
        {
            var pedido = new Pedido(_cliente, 2, desconto: _desconto);
            pedido.AddItem(_produto, 5);
            Assert.AreEqual(50, pedido.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_expirado_valor_do_pedido_deve_ser_60()
        {
            var descontoExpirado = new Desconto(2, DateTime.Now.AddMonths(-1));
            var pedido = new Pedido(_cliente, 10, desconto: descontoExpirado);
            pedido.AddItem(_produto, 5);
            Assert.AreEqual(60, pedido.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_invalido_ovalor_do_pedido_deve_ser_60()
        {
            var pedido = new Pedido(_cliente, 10, desconto: null);
            pedido.AddItem(_produto, 5);
            Assert.AreEqual(60, pedido.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_de_10_o_valor_do_pedido_deve_ser_60()
        {
            var desconto = new Desconto(10, DateTime.Now.AddDays(1));
            var pedido = new Pedido(_cliente, 10, desconto: desconto);
            pedido.AddItem(_produto, 6);
            Assert.AreEqual(60, pedido.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_uma_taxa_de_entrega_de_10_o_valor_do_pedido_deve_ser_60()
        {
            var pedido = new Pedido(_cliente, 10, desconto: null);
            pedido.AddItem(_produto, 5);
            Assert.AreEqual(60, pedido.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_ume_pedido_sem_cliente_o_mesmo_deve_ser_invalido()
        {
            var pedido = new Pedido(null, 10, desconto: _desconto);
            Assert.IsFalse(pedido.IsValid);
        }
    }
}
