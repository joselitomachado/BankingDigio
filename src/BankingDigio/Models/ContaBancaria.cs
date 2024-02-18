namespace BankingDigio.Models
{
    public class ContaBancaria
    {
        public ContaBancaria()
        {
            NumeroAgencia = "1";
            ContaBancaria.NumeroSequencial++;
            this.NumeroConta = $"{ContaBancaria.NumeroSequencial}";
        }

        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string NumeroAgencia { get; set; }
        public string NumeroConta { get; set; }
        public static int NumeroSequencial { get; private set; }
        public double Saldo { get; private set; }


        public double ConsultaSaldo()
        {
            return this.Saldo;
        }

        public void Deposito(double valor)
        {
            this.Saldo += valor;
        }

        public bool Saque(double valor)
        {
            if (valor > this.ConsultaSaldo())
            {
                return false;
            }

            this.Saldo -= valor;
            return true;
        }

        public bool Transferir(ContaBancaria contaDestino, double valor)
        {
            if (valor <= Saldo)
            {
                Saque(valor);
                contaDestino.Deposito(valor);
                return true;
            }

            return false;
        }
    }
}