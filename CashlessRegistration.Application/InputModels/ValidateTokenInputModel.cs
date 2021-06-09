namespace CashlessRegistration.Application.InputModels
{
    public class ValidateTokenInputModel
    {
        public int CustomerId { get; set; }
        public int CardId { get; set; }
        public long Token { get; set; }
        public int CVV { get; set; }
    }
}