using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    class AbsentIdException : Exception
    {
        public AbsentIdException(string message)
        : base(message)
        { }
    }
}
