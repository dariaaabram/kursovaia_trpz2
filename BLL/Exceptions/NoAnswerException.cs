using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    class NoAnswerException:Exception
    { 
       public NoAnswerException(string message)
        : base(message)
        {

        }

    }
}
