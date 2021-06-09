using System;
using System.Text;
using CashlessRegistration.Core.Entities;

namespace CashlessRegistration.Core.DomainServices
{
    public class TokenDomainService : ITokenDomainService
    {
        private const int NUMBER_DIGITS = 4;
        private const int AMOUNT_MINUTES_EXPIRATION = 30;
        public long Generate(long cardNumber, int cvv) {
            return GenerateToken(cardNumber, cvv);
        }

        public bool Validate(CustomerCard customerCard, long token, int cvv) {
            var minutesAgo = (DateTime.UtcNow - customerCard.RegistrationDate).TotalMinutes;

            if (minutesAgo > AMOUNT_MINUTES_EXPIRATION) {
                return false;
            }

            if (customerCard == null) {
                return false;
            }

            Console.WriteLine(customerCard.CardNumber);

            var cardNumberString = customerCard.CardNumber.ToString();
            var lastFourDigits = cardNumberString.Substring(cardNumberString.Length - NUMBER_DIGITS);

            var rotatedLastFourDigitsString = RotateString(lastFourDigits, cvv);
            var rotatedLastFourDigits = long.Parse(rotatedLastFourDigitsString);

            Console.WriteLine(cardNumberString);

            return  token == rotatedLastFourDigits;
        }

          private long GenerateToken(long cardNumber, int cvv) {
            var cardNumberString = cardNumber.ToString();
            var numberOfDigits = cardNumberString.Length;
            
            var lastFourDigits = cardNumberString.Substring(numberOfDigits - NUMBER_DIGITS);

            lastFourDigits = RotateString(lastFourDigits, cvv);

            return long.Parse(lastFourDigits);
        }

        private string RotateString(string lastFourDigits, int numberOfRotations) {
            var rotatedStringArray = new char[lastFourDigits.Length];
            numberOfRotations = numberOfRotations % lastFourDigits.Length;

            for (var i = 0; i < lastFourDigits.Length; i++) {;
                if (i + numberOfRotations < lastFourDigits.Length) {
                    rotatedStringArray[i + numberOfRotations] = lastFourDigits[i];
                } else {
                    rotatedStringArray[i + numberOfRotations - lastFourDigits.Length] = lastFourDigits[i];
                }
            }

            return new string(rotatedStringArray);
        }
    }
}