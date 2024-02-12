namespace Store.Store.Domain.Entities
{
    public class Desconto : Entidade
    {
        public Desconto(decimal preco, DateTime dataExpiracao)
        {
            Preco = preco;
            DataExpiracao = dataExpiracao;
        }

        public decimal Preco { get; private set; }
        public DateTime DataExpiracao { get; set; }
        public bool EhValido() => DateTime.Compare(DateTime.Now, DataExpiracao) < 0;
        public decimal Valor()
        {
            if (EhValido())
                return Preco;

            return 0;
        }

    }
}
