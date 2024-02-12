using Store.Store.Domain.Entities;

namespace Store.Tests.Entities
{
    [TestClass]
    public class ProdutoTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_titulo_com_menos_de_4_caracteres_produto_deve_ser_invalido()
        {
            //Arrange
            var produto = new Produto("Tes", 12, true);

            //Act - Assert
            Assert.IsFalse(produto.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_preco_0_o_produto_deve_ser_invalido()
        {
            //Arrange
            var produto = new Produto("Teste", 0, true);

            //Act - Assert
            Assert.IsFalse(produto.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_produto_com_todas_suas_informacoes_validas_ele_deve_ser_valido()
        {
            //Arrange
            var produto = new Produto("Teste", 12, true);

            //Act - Assert
            Assert.IsTrue(produto.IsValid);
        }
    }
}
