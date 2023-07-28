using Course_Assembly.Entities;

namespace Course_Assembly.Services
{
    internal class RentalService                                                     // serviço de aluguel
    {
        public double PricePerHour { get; private set; }                            // private = restrição de acesso aos valores
        public double PricePerDay { get; private set; }

        private ITaxService _taxService;                                            // tirar a instanciação de sua dependencia e apenas receber e atribuir se chama = inversão de controle por meio de injeção de dependência.

        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental)     // processamento da fatura      // implementar a operação p/ processar um carRental e gerar a nota de pagamento dele // invoice = fatura
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);                 // tirando a diferença entre o momento de devolução e o momento de retirada do carro

            double basicPayment = 0.0;                                                      // assim se calcula o pagamento básico
            if (duration.TotalHours <= 12.0)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);            // ceiling = teto; ele arredonda o valor pra cima.
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _taxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);                             // pronto. isso é processar o invoice
        }
    }
}
