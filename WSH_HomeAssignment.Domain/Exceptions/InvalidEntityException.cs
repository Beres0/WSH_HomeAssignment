using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WSH_HomeAssignment.Domain.Exceptions
{
    public class InvalidEntityException:Exception
    {
        public InvalidEntityException(string? message):base(message)
        {
        }
        public static void CheckNullOrWhiteSpace(string argument, [CallerArgumentExpression(nameof(argument))] string? expression = default)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new InvalidEntityException($"{expression} is required.");
            }
        }
            public static void CheckNull(object argument, [CallerArgumentExpression(nameof(argument))] string? expression = default)
        {
            if (argument == null)
            {
                throw new InvalidEntityException($"{expression} is required.");
            }
        }
 
        public static void CheckMinLength(string? argument, int min, [CallerArgumentExpression(nameof(argument))] string? expression = default)
        {
            if(argument is null)
            {
                return;
            }

            if (argument.Length < min)
            {
                throw new InvalidEntityException($"{expression} length must be at least {min} characters.");
            }

        }
        public static void CheckMaxLength(string? argument, int max, [CallerArgumentExpression(nameof(argument))] string? expression = default)
        {
            if(argument is null)
            {
                return;
            }

            if (argument.Length > max)
            {
                throw new InvalidEntityException($"{expression} length must be at most {max} characters.");
            }
        }

        public static void CheckMin<T>(T argument, T min,[CallerArgumentExpression(nameof(argument))] string? expression = default)
                where T :IComparable<T>
        {
            if(argument is null)
            {
                return;
            }
            if (argument.CompareTo(min) < 0)
            {
                throw new InvalidEntityException($"{expression} must be greater than or equal to {min}.");
            }

           
        }
        public static void CheckMax<T>(T argument, T max, [CallerArgumentExpression(nameof(argument))] string? expression = default)
                where T :IComparable<T>
        {
            if (argument is null)
            {
                return;
            }
            if (argument.CompareTo(max) > 0)
            {
                throw new InvalidEntityException($"{expression} must be less than or equal to {max}.");
            }

        }
    }
}
