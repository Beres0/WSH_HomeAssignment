namespace WSH_HomeAssignment.Domain.Repositories
{
    public class RepositoryException : DomainException
    {
        public Type Type { get; }

        public RepositoryException(Type type, string? message) : base(message)
        {
            Type = type;
            ErrorCode = 2000;
        }
    }

    public class EntityNotFoundException : RepositoryException
    {
        public static void Check<T>(object? result, params object[] keys)
        {
            if (result is null)
            {
                throw new EntityNotFoundException(typeof(T), $"{typeof(T).Name}[{string.Join(", ", keys)}] is not found.");
            }
        }

        public EntityNotFoundException(Type type, string? message) : base(type, message)
        {
            ErrorCode = 2001;
        }
    }

    public class EntityAlreadyExistsException : RepositoryException
    {
        public EntityAlreadyExistsException(Type type, string? message) : base(type, message)
        {
            ErrorCode = 2002;
        }

        public static void Check<T>(object? result, params object[] keys)
        {
            if (result is not null)
            {
                throw new EntityAlreadyExistsException(typeof(T), $"{typeof(T).Name}[{string.Join(", ", keys)}] is already exists.");
            }
        }
    }
}