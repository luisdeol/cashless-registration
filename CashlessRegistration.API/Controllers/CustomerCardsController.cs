using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CashlessRegistration.Application.Services;
using CashlessRegistration.Application.ViewModels;
using CashlessRegistration.Application.InputModels;
using Microsoft.AspNetCore.Http;

namespace CashlessRegistration.API.Controllers
{
    [Route("api/[controller]")]
    public class CustomerCardsController : ControllerBase
    {
        private readonly ICustomerCardService _customerCardService;
        public CustomerCardsController(ICustomerCardService customerCardService)
        {
            _customerCardService = customerCardService;
        }

        /// <summary>
        /// Save a customer card and generate a Token
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// {
        ///     "customerId": 1,
        ///     "cardNumber": 1231231232,
        ///     "cvv": 1
        /// }
        /// </remarks>
        /// <param name="customerCardInputModel">Customer card data.</param>
        /// <returns>Token and customer card saved data.</returns>
        /// <response code="200">Customer card and token successfully generated and saved.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] CustomerCardInputModel customerCardInputModel) {
            var addedCustomerCard = await _customerCardService.Save(customerCardInputModel);

            return Ok(addedCustomerCard);
        }

        /// <summary>
        /// Validate Token and Customer Card data
        /// </summary>
        /// <param name="id">Customer Card Id </param>
        /// <param name="validateTokenInputModel">Customer Card and Token data.</param>
        /// <returns>Validation result.</returns>
        /// <response code="200">Customer card and token validate (success or fail).</response>
        [HttpGet("{id}/validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Validate(int id, [FromQuery] ValidateTokenInputModel validateTokenInputModel) {
            validateTokenInputModel.CardId = id;

            var validationResult = await _customerCardService.Validate(validateTokenInputModel);

            return Ok(validationResult);
        }
    }
}