using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryManagmentSystem.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var status = 500;
        var message = "Internal server error";

        if (context.Exception is KeyNotFoundException)
        {
            status = 404;
            message = context.Exception.Message;
        }
        else if (context.Exception is ArgumentException || context.Exception is ArgumentNullException)
        {
            status = 400;
            message = context.Exception.Message;
        }

        var errorResponse = new
        {
            status,
            type = context.Exception.GetType().Name,
            message,
            timestamp = DateTime.UtcNow
        };

        context.Result = new ObjectResult(errorResponse)
        {
            StatusCode = status
        };
        
        context.ExceptionHandled = true;
    }
}