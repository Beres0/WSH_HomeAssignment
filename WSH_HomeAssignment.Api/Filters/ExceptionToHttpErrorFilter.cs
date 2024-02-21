using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WSH_HomeAssignment.Domain.Authentication;
using WSH_HomeAssignment.Domain.Repositories;

namespace WSH_HomeAssignment.Api.Filters
{
    public class ExceptionToHttpErrorFilter : ExceptionFilterAttribute
    {
        private static readonly Dictionary<Type, int> map = new Dictionary<Type, int>()
        {
            {typeof(AuthenticationException),StatusCodes.Status401Unauthorized},
            {typeof(EntityNotFoundException),StatusCodes.Status404NotFound},
            {typeof(EntityAlreadyExistsException),StatusCodes.Status403Forbidden},
            {typeof(InvalidArgumentException),StatusCodes.Status400BadRequest},
        };

      
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var loggerFactory=context.HttpContext.RequestServices.GetService<ILoggerFactory>();
            loggerFactory!.CreateLogger(context.RouteData.ToString()!).LogError(context.Exception,context.Exception.Message);
            var type = context.Exception.GetType();
            if (map.TryGetValue(type, out int value))
            {
                var statusCode = value;
                context.Result = new ObjectResult(context.Exception.ToDto(statusCode)) { StatusCode = statusCode };
            }
            else
            {
                var internalServerError = context.Exception.ToSomethingWentWrongDto();
                context.Result = new ObjectResult(internalServerError){ StatusCode=internalServerError.HttpErrorCode};
            }
            return base.OnExceptionAsync(context);
        }
    }
}