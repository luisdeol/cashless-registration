using CashlessRegistration.Application.InputModels;
using CashlessRegistration.Application.ViewModels;
using System.Threading.Tasks;

namespace CashlessRegistration.Application.Services
{
    public interface ICustomerCardService
    {
        Task<CustomerCardViewModel> Save(CustomerCardInputModel customerCardInputModel);
        Task<ValidateTokenViewModel> Validate(ValidateTokenInputModel validateTokenViewModel);
    }
}