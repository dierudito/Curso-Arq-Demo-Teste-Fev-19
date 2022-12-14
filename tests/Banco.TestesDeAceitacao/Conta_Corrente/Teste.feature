Funcionalidade: Deposito em Conta Corrente
				Operações de deposito em conta corrente de um cliente

Cenário: Deposito Realizado com Sucesso
	Dado Uma conta corrente ativa
	Quando Um valor for depositado
	E o valor é superior a zero
	Então Receberei uma mensagem de deposito realizado com sucesso

Cenário: Deposito com valor negativo ou igual a zero
	Dado Uma conta corrente ativa
	Quando Um valor for depositado
	E O valor é negativo ou igual a zero
	Então Receberei uma mensagem de falha na transacao

Cenário: Deposito acima do limite
	Dado Uma conta corrente ativa
	Quando Um valor for depositado
	E O valor é acima do limite do banco
		| Valor   |
		| 1000000 |
	Então Receberei uma mensagem de valor acima do limite
