namespace BankingDigio.Models
{
    public class Layout
    {
        private static List<Conta> contas = new();
        private static int opcao = 0;

        private static void BancoDigital()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("\nBanking Digio - BANCO DIGITAL\n");
        }

        public static void TelaPrincipal()
        {
            try
            {
                BancoDigital();

                Console.WriteLine("Digite a opção desejada: \n");
                Console.WriteLine("[1] - Login");
                Console.WriteLine("[2] - Criar Conta");
                Console.WriteLine("[3] - Sair");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        TelaLogin();
                        break;
                    case 2:
                        TelaCriarConta();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        Thread.Sleep(2000);
                        Console.Clear();
                        TelaPrincipal();
                        break;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                Thread.Sleep(2000);
                Console.Clear();
                TelaPrincipal();
            }
        }

        private static void TelaCriarConta()
        {
            BancoDigital();
            Console.WriteLine("Faça o seu cadastro abaixo:\n");

            Console.WriteLine("Digite seu nome: ");
            string nome = Console.ReadLine();
            if (string.IsNullOrEmpty(nome)) throw new Exception("Campo Nome é obrigatório");

            Console.WriteLine("\nDigite seu CPF: ");
            string cpf = Console.ReadLine();
            if (string.IsNullOrEmpty(cpf)) throw new Exception("Campo CPF é obrigatório");

            Console.WriteLine("\nDigite sua senha: ");
            string senha = Console.ReadLine();
            if (string.IsNullOrEmpty(senha)) throw new Exception("Campo Senha é obrigatório");

            Conta conta = new()
            {
                Nome = nome,
                CPF = cpf,
                Senha = senha
            };

            contas.Add(conta);

            Console.WriteLine("\nCadastro realizado com sucesso.\n");
            Console.WriteLine($"Número da agência: {conta.NumeroAgencia}");
            Console.WriteLine($"Número da conta: {conta.NumeroConta}");

            Thread.Sleep(2000);

            TelaLogado(conta);
        }

        private static void TelaLogin()
        {
            BancoDigital();
            Console.WriteLine("Faça o seu login abaixo:\n");

            Console.WriteLine("Digite o número da agência: ");
            string numeroAgencia = Console.ReadLine();
            if (string.IsNullOrEmpty(numeroAgencia)) throw new Exception("Campo Número de Agência obrigatório");

            Console.WriteLine("Digite número da conta: ");
            string numeroConta = Console.ReadLine();
            if (string.IsNullOrEmpty(numeroConta)) throw new Exception("Campo Número de Agência obrigatório");

            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
            if (string.IsNullOrEmpty(senha)) throw new Exception("Campo Número de Agência obrigatório");

            var conta = contas.FirstOrDefault(x => x.NumeroAgencia == numeroAgencia && x.NumeroConta == numeroConta && x.Senha == senha);

            if (conta != null)
            {
                TelaLogado(conta);
            }
            else
            {
                Console.WriteLine("Agencia/Conta/Senha inválido, verifique os dados e tente novamente");
                Thread.Sleep(2000);
                Console.Clear();
                TelaPrincipal();
            }
        }

        private static void Perfil(Conta conta)
        {
            Console.WriteLine($"{conta.Nome} | CPF: {conta.CPF} | Agência: {conta.NumeroAgencia} | Conta: {conta.NumeroConta}\n");
        }

        private static void TelaLogado(Conta conta)
        {
            try
            {
                BancoDigital();
                Perfil(conta);

                Console.WriteLine("Digite a opção desejada: \n");
                Console.WriteLine("[1] - Realizar um Deposito");
                Console.WriteLine("[2] - Realizar um Saque");
                Console.WriteLine("[3] - Realizar Transferência");
                Console.WriteLine("[4] - Consultar Saldo");
                Console.WriteLine("[5] - Extrato");
                Console.WriteLine("[6] - Sair");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        TelaDeposito(conta);
                        break;
                    case 2:
                        TelaSaque(conta);
                        break;
                    case 3:
                        TelaTransferencia(conta);
                        break;
                    case 4:
                        TelaSaldo(conta);
                        break;
                    case 5:
                        TelaExtrato(conta);
                        break;
                    case 6:
                        Console.Clear();
                        TelaPrincipal();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        Thread.Sleep(2000);
                        TelaLogado(conta);
                        break;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                Thread.Sleep(2000);
                Console.Clear();
                TelaLogado(conta);
            }
        }

        private static void TelaDeposito(Conta conta)
        {
            BancoDigital();
            Perfil(conta);

            Console.WriteLine("Digite o valor do deposito: ");
            double valor = double.Parse(Console.ReadLine());

            if (valor <= 1000)
            {
                conta.Deposito(valor);

                Console.WriteLine("Deposito realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("O valor limite para deposito é R$ 1.000,00");
            }

            OpcaoVoltarTela(conta);
        }

        private static void TelaSaque(Conta conta)
        {
            BancoDigital();
            Perfil(conta);

            Console.WriteLine("Digite o valor do saque: ");
            double valor = double.Parse(Console.ReadLine());

            bool okSaque = conta.Saque(valor);

            if (okSaque)
            {
                Console.WriteLine("Saque realizando com sucesso!");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente!");
            }

            OpcaoVoltarTela(conta);
        }

        private static void TelaSaldo(Conta conta)
        {
            BancoDigital();
            Perfil(conta);

            Console.WriteLine($"Seu saldo é: R${conta.ConsultaSaldo()}");

            OpcaoVoltarTela(conta);
        }

        private static void TelaTransferencia(Conta conta)
        {
            BancoDigital();
            Perfil(conta);

            Console.Write("Digite o número da agência de destino: ");
            string numeroAgencia = Console.ReadLine();
            if (string.IsNullOrEmpty(numeroAgencia)) throw new Exception("Campo obrigatório");

            Console.Write("Digite o número da conta de destino: ");
            string numeroConta = Console.ReadLine();
            if (string.IsNullOrEmpty(numeroConta)) throw new Exception("Campo obrigatório");

            var contaDestino = contas.Where(x => x.NumeroAgencia == numeroAgencia && x.NumeroConta == numeroConta).FirstOrDefault();

            if (contaDestino == null)
            {
                throw new Exception("Conta de destino não encontrada.");
            }

            if (numeroConta == conta.NumeroConta)
            {
                throw new Exception("Não é possível realizar transferência para a própria conta.");
            }

            Console.WriteLine("Digite o valor da transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());


            if (valorTransferencia <= conta.ConsultaSaldo() && valorTransferencia > 0)
            {
                conta.Transferencia(contaDestino, valorTransferencia);

                Console.WriteLine($"Transferência realizada com sucesso!");
            }
            else
            {
                throw new Exception("Saldo insuficiente para realizar a transferência.");
            }

            OpcaoVoltarTela(conta);
        }

        private static void TelaExtrato(Conta conta)
        {
            BancoDigital();
            Perfil(conta);

            if (conta.Extrato().Any())
            {
                double total = conta.Extrato().Sum(x => x.Valor);

                foreach (Extrato extrato in conta.Extrato())
                {
                    Console.WriteLine($"\nData: {extrato.Data.ToString("dd/MM/yyyy HH:mm:ss")}");
                    Console.WriteLine($"Tipo de Movimentação: {extrato.Descricao}");
                    Console.WriteLine($"Valor: R${extrato.Valor}");
                }

                Console.WriteLine($"\nSUB TOTAL: R${total}\n");
            }
            else
            {
                Console.WriteLine("Não há extrato a ser exibido!\n");
            }

            OpcaoVoltarTela(conta);
        }

        private static void OpcaoVoltarTela(Conta conta)
        {
            try
            {
                Console.WriteLine("\nEntre com uma opção abaixo: \n");
                Console.WriteLine("[1] - Voltar para minha conta");
                Console.WriteLine("[2] - Sair do aplicativo");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        TelaLogado(conta);
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Digite uma opção válida");
                        OpcaoVoltarTela(conta);
                        break;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                OpcaoVoltarTela(conta);
            }
        }
    }
}