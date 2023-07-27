namespace Course_Assembly.Services
{
    internal class BrazilTaxService        // serviço de imposto /  é um serviço que retorna a quantidade de imposto de uma determinada quantia (no brasil)
    {
        public double Tax(double amount)   // IMPOSTO
        {
            if (amount <= 100.0)           // para quantias até 100.0, o imposto é 20% = 0.2
            {
                return amount * 0.2;       // 20% 
            }
            else
            {                              // maior do que 100.0, o imposto é 15% = 0.15
                return amount * 0.15;      // 15%
            }
        }
    }
}
