namespace BankingDigio.Models
{
    public class Layout
    {
        private static List<ContaBancaria> contasBancarias = new();
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
                Console.WriteLine("1 - Fazer Login");
                Console.WriteLine("2 - Fazer Registro");
                Console.WriteLine("3 - Fechar Sistema");

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
                        Thread.Sleep(1000);
                        Console.Clear();
                        TelaPrincipal();
                        break;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Ocorreu um erro: {erro.Message}");
                Thread.Sleep(1000);
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
            if (nome == "") throw new Exception("Campo Nome é obrigatório");

            Console.WriteLine("\nDigite seu CPF: ");
            string cpf = Console.ReadLine();
            if (cpf == "") throw new Exception("Campo CPF é obrigatório");

            Console.WriteLine("\nDigite sua senha: ");
            string senha = Console.ReadLine();
            if (senha == "") throw new Exception("Campo Senha é obrigatório");

            ContaBancaria contaBancaria = new();
            contaBancaria.Nome = nome;
            contaBancaria.CPF = cpf;
            contaBancaria.Senha = senha;

            contasBancarias.Add(contaBancaria);

            Console.WriteLine("\nCadastro realizado com sucesso.\n");
            Console.WriteLine($"Número da agência: {contaBancaria.NumeroAgencia}");
            Console.WriteLine($"Número da conta: {contaBancaria.NumeroConta}");

            Thread.Sleep(1500);

            TelaLogado(contaBancaria);
        }

        private static void TelaLogin()
        {
            BancoDigital();
            Console.WriteLine("Faça o seu login abaixo:\n");

            Console.WriteLine("Digite o número da agência: ");
            string numeroAgencia = Console.ReadLine();
            if (numeroAgencia == "") throw new Exception("Campo Número de Agência obrigatório");

            Console.WriteLine("Digite número da conta: ");
            string numeroConta = Console.ReadLine();
            if (numeroConta == "") throw new Exception("Campo Número de Agência obrigatório");

            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
            if (senha == "") throw new Exception("Campo Número de Agência obrigatório");

            ContaBancaria contaBancaria = contasBancarias.FirstOrDefault(x => x.NumeroAgencia == numeroAgencia && x.NumeroConta == numeroConta && x.Senha == senha);

            if (contaBancaria != null)
            {
                TelaLogado(contaBancaria);
            }
            else
            {
                Console.WriteLine("Agencia/Conta/Senha inválido, verifique os dados e tente novamente");
                Thread.Sleep(2000);
                Console.Clear();
                TelaPrincipal();
            }
        }

        private static void Perfil(ContaBancaria contaBancaria)
        {
            Console.WriteLine($"{contaBancaria.Nome} | CPF: {contaBancaria.CPF} | Agência: {contaBancaria.NumeroAgencia} | Conta: {contaBancaria.NumeroConta}\n");
        }

        private static void TelaLogado(ContaBancaria contaBancaria)
        {
            try
            {
                BancoDigital();
                Perfil(contaBancaria);

                Console.WriteLine("Digite a opção desejada: \n");
                Console.WriteLine("1 - Realizar um Deposito");
                Console.WriteLine("2 - Realizar um Saque");
                Console.WriteLine("3 - Consultar Saldo");
                Console.WriteLine("4 - Realizar Transferência");
                Console.WriteLine("5 - Sair");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        TelaDeposito(contaBancaria);
                        break;
                    case 2:
                        TelaSaque(contaBancaria);
                        break;
                    case 3:
                        TelaSaldo(contaBancaria);
                        break;
                    case 4:
                        TelaTransferencia(contaBancaria);
                        break;
                    case 5:
                        Console.Clear();
                        TelaPrincipal();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        Thread.Sleep(1000);
                        TelaLogado(contaBancaria);
                        break;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Ocorreu um erro: {erro.Message}");
                Thread.Sleep(1000);
                Console.Clear();
                TelaLogado(contaBancaria);
            }
        }

        public static void TelaDeposito(ContaBancaria contaBancaria)
        {
            BancoDigital();
            Perfil(contaBancaria);

            Console.WriteLine("Digite o valor do deposito: ");
            double valor = double.Parse(Console.ReadLine());
            
            if(valor <= 1000)
            {
                contaBancaria.Deposito(valor);

                Console.WriteLine("Deposito realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("O valor limite para deposito é R$ 1.000,00");
            }
            
            Thread.Sleep(1000);
            Console.Clear();

            TelaLogado(contaBancaria);
        }
        public static void TelaSaque(ContaBancaria contaBancaria)
        {
            BancoDigital();
            Perfil(contaBancaria);

            Console.WriteLine("Digite o valor do saque: ");
            double valor = double.Parse(Console.ReadLine());

            bool okSaque = contaBancaria.Saque(valor);

            if (okSaque)
            {
                Console.WriteLine("Saque realizando com sucesso!");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente!");
            }

            Thread.Sleep(1000);
            Console.Clear();
            TelaLogado(contaBancaria);
        }

        public static void TelaSaldo(ContaBancaria contaBancaria)
        {
            BancoDigital();
            Perfil(contaBancaria);

            Console.WriteLine($"Seu saldo é: R${contaBancaria.ConsultaSaldo()}");

            Thread.Sleep(2000);
            TelaLogado(contaBancaria);
        }

        private static void TelaTransferencia(ContaBancaria contaBancaria)
        {
            BancoDigital();
            Perfil(contaBancaria);

            Console.Write("Digite o número da agência de destino: ");
            string numeroAgencia = Console.ReadLine();
            if (numeroAgencia == "") throw new Exception("Campo obrigatório");

            Console.Write("Digite o número da conta de destino: ");
            string numeroConta = Console.ReadLine();
            if (numeroConta == "") throw new Exception("Campo obrigatório");

            var contaDestino = contasBancarias.Where(x => x.NumeroAgencia == numeroAgencia && x.NumeroConta == numeroConta).FirstOrDefault();

            if (contaDestino == null)
            {
                throw new Exception("Conta de destino não encontrada.");
            }

            if(numeroConta == contaBancaria.NumeroConta)
            {
                throw new Exception("Não é possivel fazer transferência para própria conta.");
            }

            Console.WriteLine("Digite o valor da transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            if (valorTransferencia <= contaBancaria.Saldo && valorTransferencia > 0)
            {
                contaBancaria.Transferir(contaDestino, valorTransferencia);

                Console.WriteLine($"Transferência realizada com sucesso!");
            }
            else
            {
                throw new Exception("O valor da transferência está inválida, verifique seu saldo!");
            }

            Thread.Sleep(2000);
            TelaLogado(contaBancaria);
        }
    }
}