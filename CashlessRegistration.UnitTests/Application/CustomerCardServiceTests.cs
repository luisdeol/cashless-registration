using System.Threading.Tasks;
using Moq;
using Xunit;
using CashlessRegistration.Application.InputModels;
using CashlessRegistration.Core.DomainServices;
using CashlessRegistration.Application.Services;
using CashlessRegistration.Core.Repositories;
using CashlessRegistration.Core.Entities;

namespace CashlessRegistration.UnitTests.Application
{
    public class CustomerCardServiceTests
    {
        [Fact]
        public async Task CardDataIsOk_SaveIsCalled_CustomerCardViewModelReturned() {
            // Arrange
            var tokenDomainServiceMock = new Mock<ITokenDomainService>();
            var customerCardRepositoryMock = new Mock<ICustomerCardRepository>();
            var customerCardInputModel = new CustomerCardInputModel {
                CustomerId = 1,
                CardNumber = 123123123,
                CVV = 123
            };
            var mockToken = 12312321;

            tokenDomainServiceMock.Setup(t => t.Generate(It.IsAny<long>(), It.IsAny<int>())).Returns(mockToken);

            var customerCardService = new CustomerCardService(customerCardRepositoryMock.Object, tokenDomainServiceMock.Object);

            // Act
            var result = await customerCardService.Save(customerCardInputModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(mockToken, result.Token);
            customerCardRepositoryMock.Verify(ccr => ccr.Add(It.IsAny<CustomerCard>()), Times.Once);
        }
    }
}