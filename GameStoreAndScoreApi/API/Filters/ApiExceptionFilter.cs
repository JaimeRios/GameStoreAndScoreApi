using GameStoreAndScoreApi.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GameStoreAndScoreApi.API.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is UserAlreadyExistsException ex)
            {
                context.Result = new ConflictObjectResult(new ProblemDetails
                {
                    Title = "User already exists",
                    Detail = ex.Message,
                    Status = StatusCodes.Status409Conflict
                });

                context.ExceptionHandled = true;
                return;
            }
        }
    }
}
