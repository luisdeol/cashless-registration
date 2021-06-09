using System;

namespace CashlessRegistration.Application.ViewModels
{
    public class CustomerCardViewModel
    {
        public CustomerCardViewModel(DateTime registrationDate, long token, int cardId)
        {
            RegistrationDate = registrationDate;
            Token = token;
            CardId = cardId;
        }
        
        public DateTime RegistrationDate { get; private set; }
        public long Token { get; private set; }
        public int CardId { get; private set; }
    }
}