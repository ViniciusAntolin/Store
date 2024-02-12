using Store.Store.Domain.Entities;

namespace Store.Tests.Entities
{
    [TestClass]
    public class DescontoTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_uma_data_de_expiracao_maior_que_a_data_atual_o_desconto_deve_ser_valido()
        {
            //Arrange
            var desconto = new Desconto(10m, DateTime.Now.AddDays(1));

            //Act -- Arrange
            Assert.IsTrue(desconto.EhValido());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_uma_data_de_expiracao_menor_que_a_data_atual_o_desconto_deve_ser_invalido()
        {
            //Arrange
            var desconto = new Desconto(10m, DateTime.Now.AddDays(-1));

            //Act -- Arrange
            Assert.IsFalse(desconto.EhValido());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_valido_o_mesmo_deve_retornar_o_valor_correto()
        {
            //Arrange
            var desconto = new Desconto(10m, DateTime.Now.AddDays(1));
            
            //Act 
            var valor = desconto.Valor();

            //Arrange
            Assert.AreEqual(valor, 10m);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_invalido_o_mesmo_deve_retornar_valor_0()
        {
            //Arrange
            var desconto = new Desconto(10m, DateTime.Now.AddDays(-1));
            
            //Act 
            var valor = desconto.Valor();

            //Arrange
            Assert.AreEqual(valor, 0);
        }
    }
}
