using Store.Domain.Queries;
using Store.Store.Domain.Entities;
using Store.Tests.Repositories;

namespace Store.Tests.Queries
{
    [TestClass]
    public class ProdutoQueriesTests
    {
        private readonly IList<Guid> _ids;

        public ProdutoQueriesTests()
        {
            _ids = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            };
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_ativos_deve_retornar_4()
        {
            //Arrange
            var repository = new FakeProdutoRepository();

            var produtos = repository.ObterProdutos(_ids);

            // Act
            var result = produtos.AsQueryable().Where(ProdutoQueries.ObterProdutosAtivos());

            //Assert
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_inativos_deve_retornar_2()
        {
            //Arrange
            var repository = new FakeProdutoRepository();

            var produtos = repository.ObterProdutos(_ids);

            // Act
            var result = produtos.AsQueryable().Where(ProdutoQueries.ObterProdutosInativos());

            //Assert
            Assert.AreEqual(2, result.Count());
        }
    }
}