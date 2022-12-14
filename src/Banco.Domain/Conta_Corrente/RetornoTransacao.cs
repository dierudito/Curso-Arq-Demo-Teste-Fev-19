namespace Banco.Domain.Conta_Corrente
{
    public class RetornoTransacao
    {
        public string Mensagem { get; private set; }
        public TipoRetorno TipoRetorno { get; private set; }

        public RetornoTransacao(string mensagem, TipoRetorno tipoRetorno)
        {
            Mensagem = mensagem;
            TipoRetorno = tipoRetorno;
        }
    }
}
