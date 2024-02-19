using WSH_HomeAssignment.Domain;

namespace WSH_HomeAssignment.Api.Filters
{
    public static class ErrorDtoMapper
    {
        public static ErrorDto ToDto(this Exception exception, int httpErrorCode)
        {
            int? errorCode = null;
            if (exception is DomainException dEx)
            {
                errorCode = dEx.ErrorCode;
            }
            return new ErrorDto()
            {
                ErrorCode = errorCode,
                Message = exception.Message,
                HttpErrorCode = httpErrorCode
            };
        }

        public static ErrorDto ToSomethingWentWrongDto(this Exception exception)
        {
            return new ErrorDto()
            {
                Message = "something went wrong",
                HttpErrorCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}