namespace BankingDigio.Models
{
    public class Conta
    {
        public Conta()
        {
            this.NumeroAgencia = "1";
            Conta.NumeroSequencial++;
            this.NumeroConta = $"{Conta.NumeroSequencial}";
            this.Movimentacoes = new List<Extrato>();
        }

        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string NumeroAgencia { get; set; }
        public string NumeroConta { get; set; }
        public double Saldo { get; private set; }
        public static int NumeroSequencial { get; private set; }
        private List<Extrato> Movimentacoes;

        public double ConsultaSaldo()
        {
            return this.Saldo;
        }

        public void Deposito(double valor)
        {
            DateTime dataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(dataAtual, "Deposito", valor));
            this.Saldo += valor;
        }

        public bool Saque(double valor)
        {
            if (valor > this.ConsultaSaldo())
            {
                return false;
            }

            DateTime dataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(dataAtual, "Saque", -valor));

            this.Saldo -= valor;
            return true;
        }

        public bool Transferencia(Conta contaDestino, double valor)
        {
            if (valor > Saldo)
            {
                return false;
            }

            DateTime dataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(dataAtual, "Transferência", -valor));

            this.Saldo -= valor;
            contaDestino.Saldo += valor;
            return true;
        }

        public List<Extrato> Extrato()
        {
            return this.Movimentacoes;
        }

        public static bool ValidarCPF(string cpf)
        {
            return cpf.Length == 11;
        }

        public static bool ValidarSenha(string senha)
        {
            return senha.Length >= 6 && senha.Length <= 16;
        }
    }
}