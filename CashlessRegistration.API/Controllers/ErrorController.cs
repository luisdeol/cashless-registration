using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;

namespace CashlessRegistration.API.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        [HttpGet]
        public IActionResult Error([FromServices] IWebHostEnvironment webHostEnvironment) {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            var stackTrace = context.Error.StackTrace;
            var errorMessage = context.Error.Message;

            if (webHostEnvironment.EnvironmentName == "Development") {
                return Problem(detail: stackTrace, title: errorMessage);
            }

            return BadRequest("An error ocurred.");
        }
    }
}