# Desafio BankingDigio

### Descrição do problema

Mariana é dona do banco “Banking Digio” e precisa criar um sistema onde seus clientes possam:
- Se cadastrar
- Fazer login
- Visualizar seus dados
- Visualizar saldo
- Realizar saques
- Transferências
- Depósitos.

### Requisitos obrigatórios

**É obrigatório que o sistema tenha duas telas:**

  - A primeira tela terá um menu com 3 opções: 
    - Cadastrar; 
    - Logar;
    - Fechar Sistema;
      
- A segunda tela terá outro menu, contendo as opções:
    - Perfil
    - Depositar
    - Saldo
    - Sacar
    - Transferir
    - Deslogar.

*OBS: Cada opção descritas para os menus das duas telas terá seu método (função) exclusivo.*

### Requisito - Logar

- Para o usuário logar no sistema, o mesmo terá que digitar o número da agência, número da conta e senha.
- Pesquise os dados digitados na lista de usuários cadastrados e valide se os dados estão corretos.
- Login com sucesso: redirecione o usuário para o menu da segunda tela.
- Login com Falha: Retorne a mensagem: “Agencia/Conta/Senha inválido, verifique os dados e tente novamente” e peça para o usuário digitar os dados novamente.

### Requisito – Fechar Sistema
- Ao escolher essa opção, feche o sistema completamente.

### Requisito - Perfil
- Para esta opção, retorne os dados do usuário logado, exceto SALDO e SENHA.

### Requisito - Depositar

- Para esta opção o limite de deposito será de 1.000,00 por vez, ou seja, o usuário só poderá depositar 1.000,00 por depósito.
- Receba como parâmetro o valor a ser depositado.
- Após isso, verifique se o valor a ser depositado é menor ou igual a 1.000,00.
- Se o valor for menor ou igual a 1.000, adicione este valor ao saldo da conta do usuário logado e retorne a mensagem: Depósito efetuado com sucesso.
- Caso contrário, retorne a mensagem: “O valor limite para deposito é R$ 1.000,00”

### Requisito - Saldo
- Para esta opção, retorne o saldo do usuário juntamente com a mensagem: “Seu saldo é: R$ ...”

### Requisito - Sacar

- Para utilizar esta função, peça para o usuário informar o valor que ele deseja sacar.
- Após isso, verifique o saldo dele e faça a validação se o valor que ele quer sacar é menor ou igual o valor do saldo.
- Se o valor do saldo for menor ou igual o valor que ele quer sacar, subtraia o valor a ser sacado do saldo do usuário logado e retorne a mensagem: “Saque efetuado com sucesso, seu novo saldo é: R$ ...”.
- Caso contrário, retorne a informação: “Seu saldo é insuficiente para realizar esta operação”.

### Requisito - Transferir

- Para utilizar esta função, peça para o usuário informar o número da agência, número da conta e o valor que ele quer transferir.
- Após isso, verifique se o usuário logado tem saldo suficiente para ser transferido
- Verifique também na lista de contas cadastradas se a conta que ele quer transferir realmente existe.
- Subtraia o valor a ser transferido do saldo da conta do usuário logado e acrescente ao saldo da conta de destino.

### Requisito - Deslogar

- Ao escolher esta opção, retorne para as opções do menu da  primeira tela.

### Considerações finais

- Os requisitos tem que ser 100% feitos e estão todos bem explicados, caso queira acrescentar algo a mais fica a seu critério utilizando sua criatividade.
- Qualquer dúvidas sobre os requisitos do desafio, estarei disponível nas minhas redes sociais ou discord.
- Abraços.
