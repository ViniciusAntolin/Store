namespace Store.Store.Domain.Entities
{
    public class Desconto : Entidade
    {
        public Desconto(decimal quantidade, DateTime dataExpiracao)
        {
            Quantidade = quantidade;
            DataExpiracao = dataExpiracao;
        }

        public decimal Quantidade { get; private set; }
        public DateTime DataExpiracao { get; set; }
        public bool EhValido() => DateTime.Compare(DateTime.Now, DataExpiracao) < 0;
        public decimal Valor()
        {
            if (EhValido())
                return Quantidade;

            return 0;
        }

    }
}
