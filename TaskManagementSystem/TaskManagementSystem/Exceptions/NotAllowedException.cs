using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Exceptions
{
    public class NotAllowedException : ApplicationException
    {
        public NotAllowedException(string message)
            : base(message)
        {
        }
    }
}
