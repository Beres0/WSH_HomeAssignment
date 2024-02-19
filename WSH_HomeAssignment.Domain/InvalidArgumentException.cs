using System.Runtime.CompilerServices;
using WSH_HomeAssignment.Domain;

namespace WSH_HomeAssignment
{
    public class InvalidArgumentException : DomainException
    {
        public InvalidArgumentException(string? message) : base(message)
        {
            ErrorCode = 1000;
        }

        public static void CheckNullOrWhiteSpace(string argument, [CallerArgumentExpression(nameof(argument))] string? expression = default)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new InvalidArgumentException($"{expression} is required.");
            }
        }

        public static void CheckNull(object argument, [CallerArgumentExpression(nameof(argument))] string? expression = default)
        {
            if (argument == null)
            {
                throw new InvalidArgumentException($"{expression} is required.");
            }
        }

        public static void CheckMinLength(string? argument, int min, [CallerArgumentExpression(nameof(argument))] string? expression = default)
        {
            if (argument is null)
            {
                return;
            }

            if (argument.Length < min)
            {
                throw new InvalidArgumentException($"{expression} length must be at least {min} characters.");
            }
        }

        public static void CheckMaxLength(string? argument, int max, [CallerArgumentExpression(nameof(argument))] string? expression = default)
        {
            if (argument is null)
            {
                return;
            }

            if (argument.Length > max)
            {
                throw new InvalidArgumentException($"{expression} length must be at most {max} characters.");
            }
        }

        public static void CheckMin<T>(T argument, T min, [CallerArgumentExpression(nameof(argument))] string? expression = default)
                where T : IComparable<T>
        {
            if (argument is null)
            {
                return;
            }
            if (argument.CompareTo(min) < 0)
            {
                throw new InvalidArgumentException($"{expression} must be greater than or equal to {min}.");
            }
        }

        public static void CheckMax<T>(T argument, T max, [CallerArgumentExpression(nameof(argument))] string? expression = default)
                where T : IComparable<T>
        {
            if (argument is null)
            {
                return;
            }
            if (argument.CompareTo(max) > 0)
            {
                throw new InvalidArgumentException($"{expression} must be less than or equal to {max}.");
            }
        }
    }
}