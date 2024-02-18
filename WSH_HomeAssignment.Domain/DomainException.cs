﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSH_HomeAssignment.Domain
{
    public abstract class DomainException:Exception
    {
        public int ErrorCode { get; protected set; }
        public DomainException(string? message,Exception? innerException=null):base(message,innerException)
        {
        }
    }
}
