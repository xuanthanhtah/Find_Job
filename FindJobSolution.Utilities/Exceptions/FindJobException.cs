using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Utilities.Exceptions
{
    public class FindJobException : Exception
    {
        public FindJobException() { }

        public FindJobException(string message)
            : base(message) { }

        public FindJobException(string message, Exception inner)
            : base(message, inner) { }
    }
}
