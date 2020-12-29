using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    class AbsentDataException : Exception
    {
        public AbsentDataException(string message)
        : base(message)
        { }
    }
}
