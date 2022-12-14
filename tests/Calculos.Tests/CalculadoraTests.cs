using Xunit;

namespace Calculos.Tests
{
    public class CalculadoraTests
    {
        // AAA => Arrange, Act, Assert

        [Fact(DisplayName = "Calculo de Soma")]
        [Trait("Prioridade", "Baixa")]
        public void Calculadora_Somar_DeveRetornarResultadoCorreto()
        {
            //Assert.True(Calculadora.Adicao(2,2) == 5);
            Assert.Equal(4, Calculadora.Adicao(2, 2));
        }

        [Fact(DisplayName = "Calculo de Subtração")]
        [Trait("Prioridade", "Media")]
        public void Calculadora_Subtrair_DeveRetornarResultadoCorreto()
        {
            Assert.Equal(2, Calculadora.Subtracao(4, 2));
        }

        [Theory(DisplayName = "Validação de CPF")]
        [Trait("Prioridade", "Media")]
        [InlineData("30390600821")]
        [InlineData("30390600811")]
        [InlineData("33390600811")]
        [InlineData("11111111111")]
        [InlineData("22222222222")]
        [InlineData("3039060082112")]
        [InlineData("30390600")]
        [InlineData("303.906.008-22")]
        [InlineData("00446142337")]
        public void Cpf_ValidarCpf_RecusarCpfsInvalidos(string cpf)
        {
            Assert.False(CPF.Validar(cpf));
        }
    }
}
