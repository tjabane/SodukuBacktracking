using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukuBacktracking.Exceptions
{
    public class InvalidSodukuValue: Exception
    {
        public InvalidSodukuValue() : base() { }

        public InvalidSodukuValue(string message) : base(message) { }
    }
}
