using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukuBacktracking.Exceptions
{
    public class UnSolvableException : Exception
    {
        public UnSolvableException() { }
        public UnSolvableException(string message) : base(message) { }
    }
}
