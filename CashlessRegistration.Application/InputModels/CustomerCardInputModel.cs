namespace CashlessRegistration.Application.InputModels
{
    public class CustomerCardInputModel
    {
        public int CustomerId { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }
    }
}