using Flunt.Validations;

namespace Store.Store.Domain.Entities
{
    public class Produto : Entidade
    {
        public Produto(string titulo, decimal preco, bool ativo)
        {
            AddNotifications(new Contract<Produto>()
                .Requires()
                .IsGreaterThan(titulo, 3, "Produto.Titulo", "O titulo do produto não pode conter menos de 3 caracteres")
                .IsGreaterThan(preco, 0, "Produto.Preco", "O preço deve ser maior que 0"));

            Titulo = titulo;
            Preco = preco;
            Ativo = ativo;
        }

        public string Titulo { get; private set; }
        public decimal Preco { get; private set; }
        public bool Ativo { get; private set; }
    }
}
