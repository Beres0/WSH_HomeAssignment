using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WSH_HomeAssignment.Api.Filters
{
    public class ErrorDto
    {
        public int HttpErrorCode { get; set; }
        public int? ErrorCode { get; set; }
        public string? Message { get; set; }
    }
}
