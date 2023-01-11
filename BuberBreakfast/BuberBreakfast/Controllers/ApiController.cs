using Microsoft.AspNetCore.Mvc;
using ErrorOr;
namespace BuberBreakfast.Controllers;

[ApiController]
[Route("[controller]")]

public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        var firstError = errors[0];
        var statusCode = firstError.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode:statusCode, title:firstError.Description);
    }

    
}