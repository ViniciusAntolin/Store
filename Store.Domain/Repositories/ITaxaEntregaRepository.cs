namespace Store.Domain.Repositories
{
    public interface ITaxaEntregaRepository
    {
        decimal ObterTaxaEntrega(string CEP);
    }
}
