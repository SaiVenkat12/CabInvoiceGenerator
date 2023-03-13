using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    internal class CabInvoiceCustomException : Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            INVALID_DISTANCE,
            INVALID_TIME,
        }
        public CabInvoiceCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
