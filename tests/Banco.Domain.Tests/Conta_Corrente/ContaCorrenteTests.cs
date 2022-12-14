using Banco.Domain.Conta_Corrente;
using Xunit;

// Efetuar Deposito
// Não pode efetuar deposito de valores menor ou == 0
// Consultar Saldo
// Efetuar Saque
// Não pode efetuar saque de valores menor ou == 0
// Não pode sacar alem do saldo disponivel

namespace Banco.Domain.Tests.Conta_Corrente
{
    public class ContaCorrenteTests
    {
        // AAA ==> Arrange, Act, Assert

        private decimal _saldoInicial = 50;
        private decimal _saldoBloqueado = 10;
        private decimal _saldoDisponivel;
        private ContaCorrente _contaCorrente;

        public ContaCorrenteTests()
        {
            _contaCorrente = new ContaCorrente("12345",_saldoInicial, _saldoBloqueado);
            _saldoDisponivel = _saldoInicial - _saldoBloqueado;
        }

        [Fact(DisplayName = "Consultar Saldo - Saldo Deve Estar Consistente")]
        [Trait("Categoria", "Testes Conta Corrente")]
        public void ContaCorrente_ConsultarSaldo_SaldoDeveEstarConsistente()
        {
            // Act
            var saldo = _contaCorrente.ConsultarSaldo();

            // Assert
            Assert.Equal(saldo, _saldoDisponivel);
        }


        [Fact(DisplayName = "Depositar Dinheiro - Deve Retornar Saldo Atualizado Com Deposito")]
        [Trait("Categoria", "Testes Conta Corrente")]
        public void ContaCorrente_Depositar_DeveRetornarSaldoAtualizado()
        {
            // Arrange
            var deposito = 50M;

            // Act
            var transacao = _contaCorrente.Depositar(deposito);

            // Assert            
            var saldo = _contaCorrente.ConsultarSaldo();
            Assert.Equal("Deposito Efetuado com Sucesso", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Sucesso, transacao.TipoRetorno);
            Assert.Equal(deposito + _saldoDisponivel, saldo);
        }

        [Theory(DisplayName = "Depositar Valor Menor Igual Zero - Validar Transacao Com Falha")]
        [InlineData(-10)]
        [InlineData(0)]
        [Trait("Categoria", "Testes Conta Corrente")]
        public void ContaCorrente_DepositarValorMenorIgualZero_ValidarTransacaoComFalha(decimal deposito)
        {
            // Act
            var transacao = _contaCorrente.Depositar(deposito);

            // Assert
            var saldo = _contaCorrente.ConsultarSaldo();
            Assert.Equal(_saldoDisponivel, saldo);
            Assert.Equal("Não foi possível efetuar o Deposito", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Erro, transacao.TipoRetorno);
        }

        [Fact(DisplayName = "Saque - Validar Transacao Com Sucesso")]
        [Trait("Categoria", "Testes Conta Corrente")]
        public void ContaCorrente_Saque_ValidarTransacaoComSucesso()
        {
            // Arrange
            var saque = 10;

            // Act
            var transacao = _contaCorrente.Sacar(saque);

            // Assert
            var saldo = _contaCorrente.ConsultarSaldo();
            Assert.Equal(_saldoDisponivel - saque, saldo);
            Assert.Equal("Saque Efetuado com Sucesso", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Sucesso, transacao.TipoRetorno);
        }

        [Theory(DisplayName = "Sacar Valor Negativo Ou Zero - Retornar Transacao Com Falha")]
        [InlineData(0)]
        [InlineData(-10)]
        [Trait("Categoria", "Testes Conta Corrente")]
        public void ContaCorrente_SacarValorNegativoOuZero_DeveRetornarTransacaoComFalha(decimal saque)
        {
            // Act
            var transacao = _contaCorrente.Sacar(saque);

            // Assert
            var saldo = _contaCorrente.ConsultarSaldo();
            Assert.Equal(_saldoDisponivel, saldo);
            Assert.Equal("Não foi possível efetuar o Saque", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Erro, transacao.TipoRetorno);
        }

        [Fact(DisplayName = "Sacar Valor Acima do Limite - Retornar Transacao Com Falha")]
        [Trait("Categoria", "Testes Conta Corrente")]
        public void ContaCorrente_SacarValorAcimaDoLimite_RetornarTransacaoComFalha()
        {
            // Arrange
            var saque = 100;

            // Act
            var transacao = _contaCorrente.Sacar(saque);

            // Assert
            var saldo = _contaCorrente.ConsultarSaldo();
            Assert.Equal(_saldoDisponivel, saldo);
            Assert.Equal("Não foi possível efetuar o Saque", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Erro, transacao.TipoRetorno);
        }
    }
}
