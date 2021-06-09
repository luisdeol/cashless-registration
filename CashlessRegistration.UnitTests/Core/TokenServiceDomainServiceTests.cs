using Xunit;
using CashlessRegistration.Core.DomainServices;
using CashlessRegistration.Core.Entities;

namespace CashlessRegistration.UnitTests.Core
{
    public class TokenServiceDomainServiceTests
    {
        // Testing situation for Validate: Correct combination - CVV 121, TOKEN 2123
        private const int CORRECT_CVV = 121;
        private const int WRONG_CVV = 120;
        private const long CORRECT_TOKEN = 2123;
        private const long WRONG_TOKEN = 2122;
        private const long CARD_NUMBER = 1231231232;

        [Fact]
        public void CustomerCardOk_GenerateIsCalled_TokenReturned() {
            // Arrange
            var expectedToken = CORRECT_TOKEN;

            var tokenDomainService = new TokenDomainService();

            // Act
            var result = tokenDomainService.Generate(CARD_NUMBER, CORRECT_CVV);

            // Assert
            Assert.Equal(expectedToken, result);
        }

        [Fact]
        public void CustomerCardTokenCvvOk_ValidateIsCalled_TrueReturned() {
            // Arrange
            var customerCardMock = new CustomerCard(1, CARD_NUMBER);
            var tokenDomainService = new TokenDomainService();

            // Act
            var result = tokenDomainService.Validate(customerCardMock, CORRECT_TOKEN, CORRECT_CVV);
            
            // Assert
            Assert.True(result);
        }

        public void CustomerCardTokenOkButCvvWrong_ValidateIsCalled_TrueReturned() {
            // Arrange
            var customerCardMock = new CustomerCard(1, CARD_NUMBER);

            var tokenDomainService = new TokenDomainService();

            // Act
            var result = tokenDomainService.Validate(customerCardMock, CORRECT_TOKEN, WRONG_CVV);
            
            // Assert
            Assert.False(result);
        }

        public void CustomerCardCvvOkWrongToken_ValidateIsCalled_TrueReturned() {
            // Arrange
            var customerCardMock = new CustomerCard(1, CARD_NUMBER);

            var tokenDomainService = new TokenDomainService();

            // Act
            var result = tokenDomainService.Validate(customerCardMock, CORRECT_TOKEN, CORRECT_CVV);
            
            // Assert
            Assert.False(result);
        }
    }
}