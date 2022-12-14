using Banco.Domain.Conta_Corrente.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Domain.Conta_Corrente.Services
{
    public class ContaCorrenteService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public RetornoTransacao EfetuarDeposito(ContaCorrente conta, decimal valor)
        {
            var contaCorrente = _contaCorrenteRepository.ObterContaPorNumero(conta.Numero);
            var transacao = conta.Depositar(valor);

            if(transacao.TipoRetorno == TipoRetorno.Sucesso)
                _contaCorrenteRepository.Atualizar(conta);

            return transacao;
        }
    }
}
