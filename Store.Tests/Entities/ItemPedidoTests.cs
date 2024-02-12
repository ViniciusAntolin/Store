using Store.Store.Domain.Entities;

namespace Store.Tests.Entities
{
    [TestClass]
    public class ItemPedidoTests
    {
        private Produto _produto = new("Teste", 10, true);
        
        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_produto_invalido_o_item_do_pedido_deve_ser_invalido()
        {
            //Arrange
            var item = new ItemPedido(null, 1);

            //Assert -- Act
            Assert.IsFalse(item.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dada_uma_quantidade_igual_a_zero_o_item_deve_ser_invalido()
        {
            //Arrange
            var item = new ItemPedido(_produto, 0);

            //Assert -- Act
            Assert.IsFalse(item.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_produto_invalido_o_item_deve_ter_preco_0()
        {
            //Arrange
            var item = new ItemPedido(null, 1);

            //Assert -- Act
            Assert.AreEqual(item.Preco, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_preco_de_10_reais_e_a_quantidade_de_10_o_retorno_deve_ser_100()
        {
            //Arrange
            var item = new ItemPedido(_produto, 10);

            //Act
            var preco = item.Total();

            //Assert 
            Assert.AreEqual(preco, 100m);
        }
    }
}