using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukuBacktracking.Exceptions
{
    public class InvalidGridException: Exception
    {
        public InvalidGridException(): base(){}

        public InvalidGridException(string message):base(message){}
    }
}
