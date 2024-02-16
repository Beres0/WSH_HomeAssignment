using System.Runtime.CompilerServices;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Domain.Repositories
{
    public class RepositoryException : Exception
    {

        public RepositoryException(string? message) : base(message)
        {
        }
    }
    public class EntityNotFoundException<T> : RepositoryException
    {
        public EntityNotFoundException(string? message) : base(message)
        {
        }

        public static void CheckResult(object? result, params object[] keys)
        {
            if (result is null)
            {
                throw new EntityNotFoundException<T>($"{typeof(T).Name}[{string.Join(", ", keys)}] is not found.");
            }
        }
    }
    public class EntityAlreadyExistsException<T> : RepositoryException
    {
        public static void CheckResult(object? result, params object[] keys)
        {
            if (result is not null)
            {
                throw new EntityAlreadyExistsException<T>($"{typeof(T).Name}[{string.Join(", ", keys)}] is already exists.");
            }
        }
        public EntityAlreadyExistsException(string? message) : base(message)
        {
        }
    }
}
