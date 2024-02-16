using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSH_HomeAssignment.Domain.Entities
{

    public static class DomainConstants
    {
        public static DateOnly DateMin => new DateOnly(1900, 1, 1);
        public const int NoteMaxLength= 100;
        public const int CurrencyMaxLength = 10;
        public const int UnitMin = 1;
        public const double ValueMin = 0;
        public const int PasswordRequiredLength = 6;
    }
}
