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
Para o usuário logar no sistema, o mesmo terá que digitar o número da agência, número da conta e senha.

Pesquise os dados digitados na lista de usuários cadastrados e valide se os dados estão corretos.

Login com sucesso: redirecione o usuário para o menu da segunda tela.

Login com Falha: Retorne a mensagem: “Agencia/Conta/Senha inválido, verifique os dados e tente novamente” e peça para o usuário digitar os dados novamente.

