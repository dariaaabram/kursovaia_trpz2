using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    class NegativeNumberException:Exception
    {
        public NegativeNumberException(string message)
        : base(message)
        { }

    }
}
