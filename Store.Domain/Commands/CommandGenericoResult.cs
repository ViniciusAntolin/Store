using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Commands
{
    public class CommandGenericoResult : ICommandResult
    {
        public CommandGenericoResult(bool sucesso, string mensagem, object dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Dados { get; set; }
    }
}
