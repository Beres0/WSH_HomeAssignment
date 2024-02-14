using System.Runtime.CompilerServices;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Domain.Exceptions
{
    public class RepositoryException : Exception
    {
        public static void CheckResult<T>(object? result,params object[] keys)
        {
            if(result is null)
            {
                throw new RepositoryException($"{typeof(T).Name}[{string.Join(", ", keys)}] is not found.");
            }
        }

        public RepositoryException(string? message) : base(message)
        {
        }
    }
}
