using System;
using TechTalk.SpecFlow;

namespace Banco.TestesDeAceitacao.Conta_Corrente
{
    [Binding]
    public class DepositoEmContaCorrenteSteps
    {
        [Given(@"Uma conta corrente ativa")]
        public void DadoUmaContaCorrenteAtiva()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Um valor for depositado")]
        public void QuandoUmValorForDepositado()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"o valor é superior a zero")]
        public void QuandoOValorESuperiorAZero()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"O valor é negativo ou igual a zero")]
        public void QuandoOValorENegativoOuIgualAZero()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"O valor é acima do limite do banco")]
        public void QuandoOValorEAcimaDoLimiteDoBanco(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Receberei uma mensagem de deposito realizado com sucesso")]
        public void EntaoRecebereiUmaMensagemDeDepositoRealizadoComSucesso()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Receberei uma mensagem de falha na transacao")]
        public void EntaoRecebereiUmaMensagemDeFalhaNaTransacao()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Receberei uma mensagem de valor acima do limite")]
        public void EntaoRecebereiUmaMensagemDeValorAcimaDoLimite()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
