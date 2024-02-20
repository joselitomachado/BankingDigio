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

        public static void Menu()
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
                        Login();
                        break;
                    case 2:
                        Cadastro();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Menu();
                        break;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                Thread.Sleep(2000);
                Console.Clear();
                Menu();
            }
        }

        private static void Cadastro()
        {
            BancoDigital();
            Console.WriteLine("Faça o seu cadastro abaixo:\n");

            Console.WriteLine("Digite seu nome: ");
            string nome = Console.ReadLine();
            if (string.IsNullOrEmpty(nome)) throw new Exception("Campo Nome é obrigatório");

            Console.WriteLine("\nDigite seu CPF: ");
            string cpf = Console.ReadLine();
            if (string.IsNullOrEmpty(cpf)) throw new Exception("Campo CPF é obrigatório");
            if (!Conta.ValidarCPF(cpf)) throw new Exception("CPF inválido");
            if (CPFCadastrado(cpf)) throw new Exception("CPF já cadastrado.");

            Console.WriteLine("\nDigite sua senha: ");
            string senha = Console.ReadLine();
            if (string.IsNullOrEmpty(senha)) throw new Exception("Campo Senha é obrigatório");
            if (!Conta.ValidarSenha(senha)) throw new Exception("A senha precisa ter no mínimo 6 e no máximo 16 dígitos");

            Conta conta = new()
            {
                Nome = nome,
                CPF = cpf,
                Senha = senha
            };

            contas.Add(conta);

            Console.WriteLine("\nCadastro realizado com sucesso.\n");

            Thread.Sleep(2000);
            Logado(conta);
        }

        private static bool CPFCadastrado(string cpf)
        {
            foreach (Conta conta in contas)
            {
                if (conta.CPF == cpf)
                {
                    return true;
                }
            }
            return false;
        }

        private static void Login()
        {
            BancoDigital();
            Console.WriteLine("Faça o seu login abaixo:\n");

            Console.WriteLine("Digite seu CPF: ");
            string cpf = Console.ReadLine();
            if (string.IsNullOrEmpty(cpf)) throw new Exception("Campo CPF é obrigatório");

            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
            if (string.IsNullOrEmpty(senha)) throw new Exception("Campo Senha é obrigatório");

            var conta = contas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);

            if (conta != null)
            {
                Logado(conta);
            }
            else
            {
                Console.WriteLine("CPF ou Senha inválida, tente novamente");
                Thread.Sleep(2000);
                Menu();
            }
        }

        private static void Perfil(Conta conta)
        {
            BancoDigital();
            Console.WriteLine($"{conta.Nome} | CPF: {conta.CPF} | Agência: {conta.NumeroAgencia} | Conta: {conta.NumeroConta}\n");
        }

        private static void Logado(Conta conta)
        {
            try
            {
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
                        Deposito(conta);
                        break;
                    case 2:
                        Saque(conta);
                        break;
                    case 3:
                        Transferencia(conta);
                        break;
                    case 4:
                        Saldo(conta);
                        break;
                    case 5:
                        Extrato(conta);
                        break;
                    case 6:
                        Menu();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        Thread.Sleep(2000);
                        Logado(conta);
                        break;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                Thread.Sleep(2000);
                Logado(conta);
            }
        }

        private static void Deposito(Conta conta)
        {
            Perfil(conta);

            Console.WriteLine("Digite o valor do deposito: ");
            double valor = double.Parse(Console.ReadLine());

            if (valor <= 1000)
            {
                conta.Deposito(valor);

                Console.WriteLine($"Deposito realizado com sucesso, seu novo saldo é: R${conta.ConsultaSaldo()}");
            }
            else
            {
                Console.WriteLine("O valor limite para deposito é R$ 1.000,00");
            }

            OpcaoVoltar(conta);
        }

        private static void Saque(Conta conta)
        {
            Perfil(conta);

            Console.WriteLine("Digite o valor do saque: ");
            double valor = double.Parse(Console.ReadLine());

            bool okSaque = conta.Saque(valor);

            if (okSaque)
            {
                Console.WriteLine($"Saque realizando com sucesso, seu novo saldo é: R${conta.ConsultaSaldo()}");
            }
            else
            {
                Console.WriteLine("Seu saldo é insuficiente para realizar esta operação");
            }

            OpcaoVoltar(conta);
        }

        private static void Saldo(Conta conta)
        {
            Perfil(conta);

            Console.WriteLine($"Seu saldo é: R${conta.ConsultaSaldo()}");

            OpcaoVoltar(conta);
        }

        private static void Transferencia(Conta conta)
        {
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

                Console.WriteLine($"Transferência realizada com sucesso, seu novo saldo é: R${conta.ConsultaSaldo()}");
            }
            else
            {
                throw new Exception("Saldo insuficiente para realizar a transferência.");
            }

            OpcaoVoltar(conta);
        }

        private static void Extrato(Conta conta)
        {
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

            OpcaoVoltar(conta);
        }

        private static void OpcaoVoltar(Conta conta)
        {
            try
            {
                Console.WriteLine("\n[1] - Voltar para conta");
                Console.WriteLine("[2] - Sair da conta");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Logado(conta);
                        break;
                    case 2:
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Digite uma opção válida");
                        OpcaoVoltar(conta);
                        break;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                OpcaoVoltar(conta);
            }
        }
    }
}